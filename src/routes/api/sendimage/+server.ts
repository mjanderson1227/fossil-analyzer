import type { RequestEvent } from "@sveltejs/kit";

interface ImageRequestJson {
	img: string
};

export async function POST(event: RequestEvent): Promise<Response> {
	const { img } = await event.request.json() as ImageRequestJson;
	const str = btoa(img);
	const res = await fetch('http://100.76.201.27:81/dino', {
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

	responseString = new TextDecoder().decode(responseBody?.value);
	if (!responseString) {
		return new Response(res.body, {
			status: 400
		});
	}
	
	return new Response(responseString, {
		status: res.status
	});
}
