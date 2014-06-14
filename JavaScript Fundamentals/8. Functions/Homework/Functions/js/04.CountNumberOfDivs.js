/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    function countDivsNumber() {
        var divs = document.getElementsByTagName("div");
        return divs.length;
    }

    jsConsole.writeLine("Divs number on current webpage: " + countDivsNumber());

}());