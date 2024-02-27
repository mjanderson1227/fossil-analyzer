<script lang="ts">
    import type {ChatResponse, ModelResponse} from "./types";


    export let listData: ModelResponse;
    export let chatData: ChatResponse;

    function delay(ms: number) {
        return new Promise(res => setTimeout(res, ms));
    }

    const values: any = Object.values(listData).slice(0, 3);
    sendChatRequest(listData.session, "hello");
    sendPicRequest(listData.session);
    let setSumm = false;
    let setQues = false;
    let setAnswer = false;


    async function sendPicRequest(session: string) {
        if (!session)
            return;
        let waiting = await fetch("/api/generatepic", {
            method: "POST",
            body: JSON.stringify({
                session: session
            })
        });
        const reader = waiting.body?.getReader();
        let receivedLength = 0;
        const chunks = [];

        while (reader) {
            const {done, value} = await reader.read();
            if (done) {
                break;
            }
            chunks.push(value);
            receivedLength += value.length;
        }

        const completeData = new Uint8Array(receivedLength);
        let position = 0;
        for (const chunk of chunks) {
            completeData.set(chunk, position);
            position += chunk.length;
        }
        //    console.log("web client got "+receivedLength);
        const blob = new Blob([completeData], {type: 'image/png'});
        let htmlPic: HTMLImageElement = document.getElementsByClassName("bonePic")[0] as HTMLImageElement;
        htmlPic.src = URL.createObjectURL(blob);
    }

    async function sendChatRequest(token: string | null, message: string | null) {
        console.log(token + " : " + message);
        await delay(500);
        if (!token || !message)
            return;
        let waiting = await fetch("/api/sendchat", {
            method: "POST",
            body: JSON.stringify({
                session: token,
                message: message
            })
        });
        const decoder = new TextDecoder();
        let msg = decoder.decode((await (waiting.body?.getReader().read()))?.value);
        let chatMsg: ChatResponse = JSON.parse(msg);
        chatData = chatMsg;
        if (chatMsg.summary === "Generating…" || chatMsg.followup0 === "Generating…") {
            await delay(1000);
            await sendChatRequest(token, "hello");
        }
        if (!setSumm && chatMsg.summary !== "Generating…") {
            setSumm = true;
            document.getElementsByClassName("aiWords")[0].textContent = chatData.summary;
        }
        if (!setQues && chatMsg.followup0 !== "Generating…") {
            setQues = true;
            document.getElementsByClassName("followup0")[0].textContent = chatData.followup0;
            document.getElementsByClassName("followup1")[0].textContent = chatData.followup1;
            document.getElementsByClassName("followup2")[0].textContent = chatData.followup2;
        }
        if (!setAnswer && chatMsg.answer !== "Generating…") {
            setAnswer = true;
            document.getElementsByClassName("aiWords")[0].textContent = chatData.answer;
        }
    }

    async function clickReplyBtn(id: number) {
        let mytext = document.getElementsByClassName("followup" + id)[0].textContent;
        if (mytext !== "✨ Generating…") {
            sendChatRequest(listData.session, mytext);
            document.getElementsByClassName("aiWords")[0].textContent = "✨ Generating…";
            document.getElementsByClassName("replies")[0].remove();
        }
    }
</script>

<div class="book">
    <div class="page">
        <img SRC="src/lib/img/loadingplaceholder.png" class="bonePic"/>
        <div class="dinoName">{values[0].species} {values[0].bone}</div>
    </div>
    <div class="page">
        <div class="aiWords">✨ Generating…</div>
        <ul class="replies">
            <li class="followup0"
                on:click={async () => {
                await clickReplyBtn(0);
                 }}
            >✨ Generating…
            </li>
            <li class="followup1"
                on:click={async () => {
                await clickReplyBtn(1);
                 }}
            >✨ Generating…
            </li>
            <li class="followup2"
                on:click={async () => {
                await clickReplyBtn(2);
                 }}
            >✨ Generating…
            </li>
        </ul>
    </div>
</div>


<style>
    .book {
        display: flex;
        justify-content: center;
    }

    .bonePic {
        max-width: 80%;
        margin-left: 4.5%;
        margin-bottom: 20%;
    }

    .page {
        max-width: 35%;
        margin-left: 12%;
    }

    .dinoName {
        margin-bottom: 10%;
        text-align: center;
        margin-left: -9%;
        font-family: 'Delicious Handrawn';
        font-size: 4.5vh;
    }

    .aiWords {
        margin-top: -2%;
        margin-left: -25%;
        max-width: 85%;
        max-height: 60%;
        font-size: 3.25vh;
        font-family: 'Delicious Handrawn'
    }

    .replies {
        color: blue;
        font-size: 3.3vh;
        font-style: italic;
        font-family: 'Delicious Handrawn';
        margin-left: -25%;
        max-width: 80%;
    }

    .followup0:hover {
        color: red;
    }

    .followup1:hover {
        color: red;
    }

    .followup2:hover {
        color: red;
    }

</style>