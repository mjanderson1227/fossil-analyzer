export default async function handleImageSubmit(files: FileList | null) {
	if (!files)
		return;
	const image = files[0];
	let reader = new FileReader();
	reader.readAsDataURL(image);
	reader.onload = (e: ProgressEvent<FileReader>) => {
		const image = e.target?.result?.toString();
		if (!image)
			return
		fetch('/api/sendimage', {
			method: "POST",
			body: JSON.stringify({
				img: image
			})
		});
	};
}
