
$(document).ready(function () {
	$('.btn-elfinder').click(function (e) {
		let buttons = $(this);
		let group = buttons.closest(".group-container");
		let image = group.find(".selectedImages");
	
		let imgThumbnailPath = $(e.target).attr("data-imgthumbnailpath");
		let imgPath = $(e.target).attr("data-imgpath");
		let button = $(".position-relative");
		//let image = button.find(".selectedImages");
		var fm = $('<div/>').dialogelfinder({
			url: '/file-manager/connector',
			baseUrl: "/lib/elfinder/",
			lang: 'vi',
			width: 840,
			height: 450,
			destroyOnClose: false,
			getFileCallback: function (files, fm) {
				var host = window.location.host;
				let resultPath = files.url.split(host)[1];
				let thumbnailPath = resultPath;
				if (files.tmb) {
					thumbnailPath = files.tmb.split(host)[1];
				}
				if (imgPath != "" && imgThumbnailPath != "") {
					$(image).html(`<img class="image-review" src ="${resultPath}" />`);
				}
				if (files.mime != 'directory') {
					$(imgThumbnailPath).val(thumbnailPath);
					$(imgPath).val(resultPath)
					fm.destroy();
					return false;
				}
			},
			commandsOptions: {
				getfile: {
					oncomplete: 'close',
					folders: false
				}
			}
		}).dialogelfinder('instance');
		console.log(fm)
	});
});
