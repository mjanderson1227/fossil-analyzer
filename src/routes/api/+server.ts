import type { RequestEvent, RequestHandler } from "@sveltejs/kit";

export async function POST(event: RequestEvent): RequestHandler {
	const { img } = await event.request.json();
}
