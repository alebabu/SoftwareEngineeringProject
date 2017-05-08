function setMonthDropDowns() {
    $('.monthDropDown')
        .each(function () {
            for (var month = 1; month < 13; month++) {
                $(this).append('<option value="' + month + '">' + month + '</option>');
            }
        });
}

function setDayDropDowns() {
    $('.dayDropDown')
        .each(function () {
            for (var day = 1; day < 31; day++) {
                $(this).append('<option value="' + day + '">' + day + '</option>');
            }
        });
}

function setYearDropDowns() {
    $('.yearDropDown')
        .each(function () {
            for (var year = 1900; year < 2100; year++) {
                $(this).append('<option value="' + year + '">' + year + '</option>');
            }
            $(this).val(2000); //Note(Olle): set standard value
        });
}

function setDropDowns() {
    setDayDropDowns();
    setMonthDropDowns();
    setYearDropDowns();
}

$(function() {
    setDropDowns();
});