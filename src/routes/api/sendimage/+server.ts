import type { RequestEvent } from "@sveltejs/kit";

interface ImageRequestJson {
	img: string
};

export async function POST(event: RequestEvent): Promise<Response> {
	const { img } = await event.request.json() as ImageRequestJson;
	const res = await fetch('http://100.76.201.27:81/dino', {
		method: "POST",
		mode: "cors",
		body: btoa(img).split(",")[1],
	});
	console.log(res);
	return new Response("ok", {
		status: 200,
	})
}
