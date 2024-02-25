import { type Cookies, redirect } from "@sveltejs/kit";
import type { ModelResponse } from "./types";

interface LoadCookies {
	cookies: Cookies
};

export async function load({cookies}: LoadCookies): Promise<ModelResponse> {
	const cookieString = cookies.get('server_data');

	if (!cookieString) {
		redirect(303, "/");
	}

	return await JSON.parse(cookieString);
}
