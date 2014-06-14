/*jslint browser: true*/

(function () {
    'use strict';
    document.querySelector('input[type=color]').onchange = function () {
        document.body.style.background = document.getElementById('colorField').value;
    };
}());