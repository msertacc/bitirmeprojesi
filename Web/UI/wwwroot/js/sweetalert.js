function myAlert(title, description, iconType, timer, footText) {
	Swal.fire({
		icon: iconType,
		title: title,
		text: description,
		timer: timer,
		footer: footText,
		timerProgressBar: true,
	}).then((result) => {
		if (result.dismiss === Swal.DismissReason.timer) {
			location.href = "Index";
		}
	});
}