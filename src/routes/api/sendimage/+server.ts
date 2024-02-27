import {type RequestEvent} from "@sveltejs/kit";

interface ImageRequestJson {
    img: string
}

export async function POST(event: RequestEvent): Promise<Response> {
    event.cookies.delete("server_data", {path: "/results"});
    const {img} = await event.request.json() as ImageRequestJson;
    const str = img.split(",")[1];
    const decoder = new TextDecoder();
    const res = await fetch('http://localhost:81/dino', {
        method: "POST",
        headers: {
            "Content-Type": "text/plain; charset=utf-8",
        },
        body: str,
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
    event.cookies.set("server_data", responseString, {path: "/results"});
    //event.cookies.set("prev_image", img, {path: "/results"});

    return new Response(null, {
        status: 200
    });
}
