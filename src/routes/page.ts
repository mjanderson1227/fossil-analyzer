export default async function handleImageSubmit(event: InputEvent) {
	let target = event.target as HTMLInputElement;
	let image = target.files?.item(0) as File;
	let reader = new FileReader();
	reader.readAsDataURL(image);
	reader.onload = (e: ProgressEvent<FileReader>) => {
		const image = e.target?.result?.toString();
		if (!image)
			return
		fetch('/api/sendimage', {
			method: "POST",
			body: image
		});
	};
}
