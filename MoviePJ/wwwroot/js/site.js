$(function () {
    // Tự động ẩn cảnh báo sau 5.5 giây
    $(".alert.js-alert").delay(5500).slideUp(300, function () {
        $(this).alert('close');
    });

    $(".bs-autocomplete").bsautocomplete();

    // ẩn menu cha nếu không có menu con
    $(".nav-treeview").each(function (i, item) {
        item = $(item);
        if (item.find(".nav-item").length == 0) {
            item.closest(".nav-item").hide();
        }
    });
});


$(document).on("click", ".js-delete-confirm", function (ev) {
    ev.preventDefault();
    let btnDelete = $(this);
    let msg = btnDelete.data('msg');
    let mode = btnDelete.data('mode');
    if (!msg) {
        msg = 'Confirm deletion?';
    }

    confirm(msg, () => {
        if (mode == "submit") {
            let form = btnDelete.closest("form");
            if (form.valid()) {
                form.submit();
            }
        }
        else {
            location.href = $(this).attr("href");
        }
    });
});

// Các hàm liên quan xóa nhiều
$("#chkAll").click(function () {
    var isCheckAll = $(this).prop('checked');
    // Tránh trường hợp count sai
    $('td.js-col-checkbox > input').each(function (i, item) {
        var statusBefore = item.checked;
        item.checked = isCheckAll;
        if (item.checked != statusBefore) {
            $(item).change();
        }
    });
});


$("#chkAllowBulkDel").change(function (ev) {
    var isCheck = $(this).is(":checked");
    if (isCheck) {
        $(".js-col-checkbox").removeClass("d-none");
        $("#btnBulkDel").removeClass("d-none");
    } else {
        $(".js-col-checkbox").addClass("d-none");
        $("#btnBulkDel").addClass("d-none");
    }
});

var chkCount = $("td.js-col-checkbox > input").length;
$("td.js-col-checkbox > input").change(function (ev) {
    var isCheck = $(this).is(":checked");
    var delCountEle = $("#delCount");
    var delCountVal = Number(delCountEle.text());
    if (isCheck) {
        delCountVal++;
    } else {
        delCountVal--;
    }
    delCountEle.text(delCountVal);
    $("#chkAll").prop('checked', delCountVal == chkCount);
});

$("#btnBulkDel").click(function (ev) {
    var delCountEle = $("#delCount");
    var delCountVal = Number(delCountEle.text());
    var keyword = $(this).data("keyword");
    var url = $(this).data("url");
    if (!delCountVal) {
        alert(`Unselected ${keyword} to delete`);
        return;
    }
    confirm(`Confirm bulk deletion ${delCountVal} ${keyword}?`, function () {
        var ids = $("td.js-col-checkbox > input:checked").toArray().map(function (i) {
            return i.getAttribute("data-id");
        });
        url = url + "?ids=" + ids.join("&ids=");
        location.assign(url);
    });
});

// Cập nhật danh mục sp ngay khi thay đổi
$(document).on("change", "select[name^=devCateId]", function (ev) {
    var newCateId = this.value;
    var parent = $(this).closest("div");
    var id = parent.attr("data-id");
    var name = parent.attr("data-name");

    var url = "/Admin/Products/UpdateCateId";
    $.get(url, { productId: id, cateId: newCateId }).then(function (res) {
        if (res == true) {
            Toast.info("Đã cập nhật sản phẩm " + name + " (" + id + ")");
        } else {
            Toast.danger(res);
        }
    }).catch(function (err) {
        Toast.danger("Lỗi rồi đại vương ơi :(");
    });
});

// Chế độ cập nhật nhanh danh mục sản phẩm ở index
$("#chkCateUpdate").change(function () {
    var url = $(this).closest("a").attr("data-url");
    location.href = url;
});