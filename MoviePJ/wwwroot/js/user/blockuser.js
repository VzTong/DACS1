$(document).on("click", ".js-block", (ev) => {
	$('#modal-block').html("");
	var id = $(ev.currentTarget).attr("data-id");
	$.get("/Admin/User/_BlockUser/" + id, (ev) => {
		$('#modal-block').append(ev);
	})
})
$(document).on("click", ".js-succes-block", () => {
	var id = $(".id-user").html();
	var blocktodate = $(".js-date").val();
	var permanentblock = $('.js-check').is(":checked")
	var data = {
		id: id,
		blockedTo: blocktodate,
		permanentblock: permanentblock,
	}
	if (blocktodate == "" && permanentblock == false) {
		$(".js-message").html("Must select 1 of 2 items to perform locking")
	}
	else {
		$.post("/Admin/User/_BlockUser", data, (ev) => {
			window.location.reload(true);
		})
    }
})