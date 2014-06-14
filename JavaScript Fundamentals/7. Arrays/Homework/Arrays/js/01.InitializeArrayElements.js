/*global jsConsole*/
/*jslint browser: true*/

(function () {
    "use strict";

    function initializeArray() {
        var numbers = [],
            length = 20,
            index;

        for (index = 0; index < length; index += 1) {
            numbers[index] = index * 5;
        }
        return numbers;
    }
    var integers = initializeArray();
    jsConsole.writeLine(integers.join(", "));

    document.getElementById("process").onclick = function () {
        integers = initializeArray();
        jsConsole.writeLine(integers.join(", "));
    };

}());