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
    if (fromBoxChecked()) {
        $('#fromLocationForm').css('display', 'inline-block');
    } else {
        $('#fromLocationForm').hide();
    }
}

function setToVisibility() {
    if (toBoxChecked()) {
        $('#toLocationForm').css('display', 'inline-block');
    } else {
        $('#toLocationForm').hide();
    }
}

function setAtVisibility() {
    if (toBoxChecked()) {
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

function initiateRadiosAndCheckBoxes() {
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


$(function () {
    initiateRadiosAndCheckBoxes();

    /* This is basic - uses default settings */

    $("a#single_image").fancybox();

    /* Using custom settings */

    $(".fancyBoxButton").fancybox({
        'hideOnContentClick': true
    });

    /* Apply fancybox to multiple items */

    $("a.group").fancybox({
        'transitionIn': 'elastic',
        'transitionOut': 'elastic',
        'speedIn': 600,
        'speedOut': 200,
        'overlayShow': false
    });

});