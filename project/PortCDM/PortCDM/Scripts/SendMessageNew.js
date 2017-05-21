function toBoxChecked() {
    return $('#cpMainContent_toCheckBox').prop('checked');
}

function fromBoxChecked() {
    return $('#cpMainContent_fromCheckBox').prop('checked');
}

function atRadioChecked() {
    return $('#cpMainContent_atRadioButton').prop('checked');
}

function bothRadioChecked() {
    return $('#cpMainContent_betweenRadioButton').prop('checked');
}

function setFromVisibility() {
    if (fromBoxChecked() || bothRadioChecked()) {
        $('#fromLocationForm').css('display', 'inline-block');
    } else {
        $('#fromLocationForm').hide();
    }
}

function setToVisibility() {
    if (toBoxChecked() || bothRadioChecked()) {
        $('#toLocationForm').css('display', 'inline-block');
    } else {
        $('#toLocationForm').hide();
    }
}

function setAtVisibility() {
    if (toBoxChecked() || bothRadioChecked()) {
        $('#toLocationForm').css('display', 'inline-block');
    } else {
        $('#toLocationForm').hide();
    }
}

function setAtOrBothVisibility() {
    if (atRadioChecked()) {
        $('#atLocationForm').css('display', 'inline-block');
        $('#toLocationForm').hide();
        $('#fromLocationForm').hide();
    } else if (bothRadioChecked()) {
        $('#atLocationForm').hide();
        $('#toLocationForm').css('display', 'inline-block');
        $('#fromLocationForm').css('display', 'inline-block');
    }
}

function setVisibilities() {
    setAtOrBothVisibility();
    setAtVisibility();
    setFromVisibility();
    setToVisibility();
}

function initClickEvents() {
    $('#cpMainContent_betweenRadioButton')
    .click(function() {
        setAtOrBothVisibility();
    });
    $('#cpMainContent_atRadioButton')
        .click(function () {
            setAtOrBothVisibility();
        });

    $('#cpMainContent_fromCheckBox')
        .click(function() {
            setFromVisibility();
        });

    $('#cpMainContent_toCheckBox')
    .click(function () {
        setToVisibility();
    });
}

function panelLoaded(sender, args) {
    setVisibilities();

}

$(function () {
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_pageLoaded(panelLoaded);

    initClickEvents();

    /* This is basic - uses default settings */
    $("a#single_image").fancybox();

    /* Using custom settings */
    $(".fancyBoxButton").fancybox({
        'hideOnContentClick': true
    });

});