function myAlert(title, description, iconType, timer, footText) {
	Swal.fire({
		icon: iconType,
		title: title,
		text: description,
		timer: timer,
		footer: footText,
		timerProgressBar: true,
		didOpen: () => {
			Swal.showLoading()
			const b = Swal.getHtmlContainer().querySelector('b')
			timerInterval = setInterval(() => {
				b.textContent = Swal.getTimerLeft()
			}, 100)
		},
		willClose: () => {
			clearInterval(timerInterval)
		}
	}).then((result) => {
		if (result.dismiss === Swal.DismissReason.timer) {
			//location.href = "Home/Index";
		}
	});
}