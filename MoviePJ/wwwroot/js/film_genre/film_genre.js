
var isAjaxFinish = true;
const ORDER_TIMEOUT = 200;
$('.js-btn-reorder').click(function (ev) {
	ev.stopPropagation();
	let ele = $(this);
	let row = ele.closest('.js-row');
	let id1 = row.attr('data-id');
	let id2 = 0;
	let type = ele.data("type");

	if (!isAjaxFinish) {
		Toast.warning("The operation is too fast, please wait a moment..");
		return;
	}

	if (type == "up") {
		// tìm row đứng trên nó
		let prevRow = row.prev();
		// dừng nếu là dòng đầu tiên (có data-header-flg = 1)
		if (prevRow.attr("data-header-flg") == "1") {
			return;
		}
		id2 = prevRow.attr('data-id');
		prevRow.slideUp(ORDER_TIMEOUT, "linear");
		setTimeout(function () {
			row.after(prevRow);
			prevRow.slideDown(ORDER_TIMEOUT, "linear");
		}, ORDER_TIMEOUT);
	} else if (type == "down") {
		let nextRow = row.next();
		// dừng nếu là dòng cuối cùng (có data-end-flg = 1)
		if (nextRow.attr("data-end-flg") == "1") {
			return;
		}
		id2 = nextRow.attr('data-id');
		nextRow.slideUp(ORDER_TIMEOUT, "linear");
		setTimeout(function () {
			row.before(nextRow);
			nextRow.slideDown(ORDER_TIMEOUT, "linear");
		}, ORDER_TIMEOUT);
	} else {
		return;
	}
	// chỉnh lại cột index khi sắp xếp
	reRenderIndex();

	// gọi ajax để cập nhật displayOrder
	if (isAjaxFinish) {
		isAjaxFinish = false;
		$.get(`/Admin/Genre/UpdateDisplayOrder?id1=${id1}&id2=${id2}`)
			.then(function (res) {
				if (!res) {
					alert("Invalid data, please refresh the page and try again");
				}
			}).catch(function (err) {
				alert("An error occurred during processing 🥲" + err);
			}).done(function () {
				isAjaxFinish = true;
			});
	}
});

function reRenderIndex() {
	setTimeout(function () {
		$(".js-row").each(function (i, item) {
			item = $(item);
			item.find(".js-index").text(i + 1);
		});
	}, ORDER_TIMEOUT * 1.2);
}