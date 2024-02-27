import {type RequestEvent} from "@sveltejs/kit";

interface ChatRequestJson {
    session: string,
    message: string
}

export async function POST(event: RequestEvent): Promise<Response> {
    // console.log(event.request.text());
    const {session, message} = await event.request.json() as ChatRequestJson;
    const decoder = new TextDecoder();
    console.log("session: " + session + " message " + message);
    const res = await fetch('http://localhost:81/chat', {
        method: "GET",
        headers: {
            session: session,
            message: message
        }
    });
    let responseString: string | undefined = "";
    let reader = res.body?.getReader()
    const responseBody = await reader?.read();
    reader?.releaseLock();
    responseString = decoder.decode(responseBody?.value);
    if (!responseString) {
        return new Response(res.body, {
            status: 400
        });
    }
    return new Response(responseString, {
        status: 200
    });
}
