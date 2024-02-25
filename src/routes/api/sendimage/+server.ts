import { redirect, type RequestEvent } from "@sveltejs/kit";

interface ImageRequestJson {
	img: string
};

export async function POST(event: RequestEvent): Promise<Response> {
	const { img } = await event.request.json() as ImageRequestJson;
	const str = btoa(img);
	const decoder = new TextDecoder();
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

	responseString = decoder.decode(responseBody?.value);
	if (!responseString) {
		return new Response(res.body, {
			status: 400
		});
	}
	event.cookies.delete("server_data",{path: "/results"});
	event.cookies.set("server_data", responseString, {path: "/results"});
	event.cookies.set("prev_image", img, {path: "/results"});

	return redirect(303, "/results");
}
