import {type RequestEvent} from "@sveltejs/kit";

interface ImageRequestJson {
    session: string
}

export async function POST(event: RequestEvent): Promise<Response> {
    // console.log(event.request.text());
    const {session} = await event.request.json() as ImageRequestJson;
    const res = await fetch('http://localhost:81/image', {
        method: "GET",
        headers: {
            session: session
        }
    });
    const responseBody = await res.arrayBuffer();
    //  console.log("web server got "+responseBody.byteLength)
    return new Response(responseBody);
}
