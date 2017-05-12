function setLoadState() {
    $('#atLocation').hide();
    $('#fromLocation').hide();
    $('#toLocation').hide();
}

function setMonthDropDowns() {
    $('.monthDropDown')
        .each(function () {
            for (var month = 1; month < 13; month++) {
                $(this).append('<option value="' + addZeroBeforeDate(month) + '">' + month + '</option>');
            }
        });
}

function setDayDropDowns() {
    $('.dayDropDown')
        .each(function () {
            for (var day = 1; day < 32; day++) {
                $(this).append('<option value="' + addZeroBeforeDate(day) + '">' + day + '</option>');
            }
        });
}

function setYearDropDowns() {
    $('.yearDropDown')
        .each(function () {
            for (var year = 1900; year < 2101; year++) {
                $(this).append('<option value="' + year + '">' + year + '</option>');
            }
            $(this).val(2010); //Note(Olle): set standard value
        });
}

function setDropDowns() {
    setDayDropDowns();
    setMonthDropDowns();
    setYearDropDowns();
}

function addZeroBeforeDate(monthOrDay) {
    if (monthOrDay < 10)
        return 0 + "" + monthOrDay;
    else
        return monthOrDay;
}

function setBetweenLocation() {
    var fadeDuration = 600;
    $('#atLocation').hide();
    $('#fromLocation').fadeIn(fadeDuration);
    $('#toLocation').fadeIn(fadeDuration);
}

function setAtLocation() {
    var fadeDuration = 600;
    $('#atLocation').fadeIn(fadeDuration);
    $('#fromLocation').hide();
    $('#toLocation').hide();
}

function setLocationVisibilityOnClick() {
    $('input:radio').click(function() {
        if ($('#cpMainContent_atRadioButton').is(':checked')) {
            setAtLocation();
        } else if ($('#cpMainContent_betweenRadioButton').is(':checked')) {
            setBetweenLocation();
        }
    });
}

function setLocationVisibility() {
    if ($('#cpMainContent_atRadioButton').is(':checked')) {
        setAtLocation();
    } else if ($('#cpMainContent_betweenRadioButton').is(':checked')) {
        setBetweenLocation();
    }
}

//Note(Olle): run scripts at startup and on updatepanel update
$(function () {
    setLoadState();
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_pageLoaded(panelLoaded);
});

function panelLoaded(sender, args) {
    setDropDowns();
    setLocationVisibility();
    setLocationVisibilityOnClick();
}