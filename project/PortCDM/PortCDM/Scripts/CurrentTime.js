function padTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

function currentTime() {
    var utc = new Date();
    var hours = padTime(utc.getUTCHours());
    var minutes = padTime(utc.getUTCMinutes());
    //var seconds = padTime(utc.getUTCSeconds());
    document.getElementById('currentTime').innerHTML =
        hours + ":" + minutes + " UTC";
    t = setTimeout(function () { currentTime() }, 1000);
}
currentTime();
