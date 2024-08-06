var isCancelled = false; // Biến trạng thái để theo dõi việc nhấn 'Cancel'
var originalValue = $("#yearPicker").val(); // Lưu giá trị ban đầu của input

// Khởi tạo datepicker với các tùy chọn cấu hình
$("#yearPicker").datepicker({
    dateFormat: 'yy',
    changeYear: true,
    showButtonPanel: true,
    yearRange: '1700:', // Bắt đầu từ năm 1700 và không có giới hạn năm lớn nhất

    // Hàm được gọi trước khi datepicker hiển thị
    beforeShow: function (input) {
        $(".ui-datepicker-calendar").hide(); // Ẩn bảng lịch
        $(".ui-datepicker-month").hide(); // Thêm dòng này để ẩn lựa chọn tháng
        // Lưu giá trị hiện tại của input vào biến originalValue
        originalValue = $(this).val();
    },

    // Hàm được gọi khi người dùng thay đổi năm hoặc tháng
    // Dùng khi select thì phần ở input cũng sẽ thay đôi theo
    onChangeMonthYear: function (year, month, inst) {
        // Cập nhật giá trị vào input khi thay đổi năm hoặc tháng
        $(this).val(new Date(year, month - 1).getFullYear());
    },

    // Hàm được gọi khi datepicker đóng lại
    onClose: function (dateText, inst) {
        if (!isCancelled) {
            // Nếu không nhấn 'Cancel', cập nhật giá trị mới
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            if (year) {
                $(this).datepicker('setDate', new Date(year, 1));
            }
        }
        // Đặt lại trạng thái
        isCancelled = false;
    },

    // Hàm quyết định xem ngày nào sẽ hiển thị trong datepicker
    beforeShowDay: function (date) {
        return [false]; // Không hiển thị bất kỳ ngày nào
    }
}).on("input", function () {
    // Sự kiện input được gọi mỗi khi giá trị của input thay đổi
    var inputYear = $(this).val();
    var yearRange = $(this).datepicker("option", "yearRange").split(":");
    var minYear = parseInt(yearRange[0], 10);
    var maxYear = new Date().getFullYear(); // Hoặc giá trị tối đa nếu bạn đã đặt

    // Kiểm tra xem giá trị nhập vào có nằm trong khoảng yearRange không
    if (inputYear >= minYear && inputYear <= maxYear) {
        // Nếu có, cập nhật datepicker với năm nhập vào
        $(this).datepicker('setDate', new Date(inputYear, 1));
        // Đặt lại trạng thái isCancelled để nút 'Done' có thể hoạt động đúng
        isCancelled = false;
        updateButtonPane();
    }
}).focus(function () {
    var buttonPane = $(this).datepicker("widget").find(".ui-datepicker-buttonpane");

    // Thay đổi nhãn nút 'Today' thành 'ToYear' và cập nhật hành động của nó
    buttonPane.find(".ui-datepicker-current")
        .text("ToYear")
        .off("click") // Gỡ bỏ sự kiện click mặc định
        .on("click", function () {
            $("#yearPicker").datepicker('setDate', new Date(new Date().getFullYear(), 1));
        });

    // Kiểm tra và thêm nút 'Done' nếu chưa có
    if (buttonPane.find(".ui-datepicker-close").length == 0) {
        $("<button>", {
            text: "Done",
            class: "ui-datepicker-close",
            click: function () {
                // Đặt trạng thái là không nhấn 'Cancel' và lưu giá trị đã chọn
                isCancelled = false;
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                if (year) {
                    $("#yearPicker").datepicker('setDate', new Date(year, 1));
                }
                $("#yearPicker").datepicker("hide");
            }
        }).appendTo(buttonPane); // Thêm nút 'Done' vào cuối
    }

    // Thêm nút 'Cancel' nếu chưa có
    if (buttonPane.find(".btn-cancel").length == 0) {
        $("<button>", {
            text: "Cancel",
            class: "btn-cancel",
            click: function () {
                // Đặt trạng thái là đã nhấn 'Cancel'
                isCancelled = true;
                $("#yearPicker").datepicker("hide");
            }
        }).appendTo(buttonPane); // Thêm nút 'Cancel' vào cuối
    }
}).blur(function () {
    // Khi input mất focus mà không nhấn 'Cancel', phục hồi giá trị ban đầu
    if (!isCancelled) {
        $(this).val(originalValue);
        updateButtonPane();
    }
});


// Hàm để cập nhật hoặc thêm nút 'ToYear' và 'Cancel'
function updateButtonPane() {
    var buttonPane = $(".ui-datepicker-buttonpane");

    // Cập nhật nút 'ToYear'
    if (buttonPane.find(".ui-datepicker-current").length === 0) {
        // Tạo nút mới với các thuộc tính và hành động cụ thể
        $("<button>", {
            text: "ToYear",
            class: "ui-datepicker-current ui-state-default ui-priority-secondary ui-corner-all",
            click: function () {
                var currentYear = new Date().getFullYear();
                $("#yearPicker").datepicker('setDate', new Date(currentYear, 1));
            }
        }).appendTo(buttonPane);
    } else {
        buttonPane.find(".ui-datepicker-current").text("ToYear");
    }

    // Thêm nút 'Cancel' nếu chưa có
    if (buttonPane.find(".btn-cancel").length === 0) {
        $("<button>", {
            text: "Cancel",
            class: "btn-cancel ui-state-default ui-priority-secondary ui-corner-all",
            click: function () {
                isCancelled = true;
                $("#yearPicker").datepicker("hide");
            }
        }).appendTo(buttonPane);
    }
}