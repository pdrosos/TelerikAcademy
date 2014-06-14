/*jslint browser: true*/

(function () {
    'use strict';

    function onCheckIsMozillaClick() {
        var browserName,
            isMozilla;

        browserName = window.navigator.appCodeName;
        isMozilla = browserName === "Mozilla";

        if (isMozilla) {
            alert("Yes");
        } else {
            alert("No");
        }
    }

    document.getElementById('checkIsMozilla').addEventListener('click', onCheckIsMozillaClick);
}());
