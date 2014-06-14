/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';

    document.getElementById("process").onclick = function () {

        //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
        if (isInputValid("int", "number")) {
            var n, i;
            n = jsConsole.readInteger("#number");

            for (i = 1; i <= n; i += 1) {
                jsConsole.writeLine(i);
            }
        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
        }
    };
}());