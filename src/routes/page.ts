import { redirect } from "@sveltejs/kit";

export default async function handleImageSubmit(files: FileList | null) {
	if (!files)
		return;
	const image = files[0];
	let reader = new FileReader();
	reader.readAsDataURL(image);
	reader.onload = async (e: ProgressEvent<FileReader>) => {
		const image = e.target?.result?.toString();

		if (!image) {
			// Fail and throw an error to the frontend.
			return
		}

		const res = await fetch('/api/sendimage', {
			method: "POST",
			body: JSON.stringify({
				img: image
			})
		});

		const reader = res.body?.getReader();

		if (!reader) {
			// Fail and throw an error to the frontend.
			return;
		}

		let jsonString = (await reader.read()).value?.toString();
		if (!jsonString) {
			// Fail and throw an error to the frontend.
			return;
		}

		window.localStorage.setItem("server_data", jsonString);
		redirect(307, '/results');
	};
}
