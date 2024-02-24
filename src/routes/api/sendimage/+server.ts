import type { RequestEvent } from "@sveltejs/kit";

interface ImageRequestJson {
	img: string
};

export async function POST(event: RequestEvent) {
	const { img } = await event.request.json() as ImageRequestJson;
	const res = await fetch('http://myIpOrSomething.com/dino', {
		method: "POST",
		mode: "cors",
		body: img
	});
	console.log(res);
}
