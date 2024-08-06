$("#qsearch").on("click", function myFunction() {
    $("#dropdown-values").addClass("show active");
});

$(document).click(function (e) {
    if (e.target.id != 'qsearch') {
        $("#dropdown-values").removeClass("show active");
    }
});
$(document).ready(function () {
    var listOption = $('#dropdown-values').find('.set-value-search');
    for (let i = 0; i < listOption.length; i++) {
        var click = $(listOption[i]).on('click', function () {
            $("#qsearch").val(listOption[i].innerText);
        });
    }
});