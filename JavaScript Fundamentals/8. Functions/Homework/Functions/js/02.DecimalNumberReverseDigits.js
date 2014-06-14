/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';

    function reverseDigits(inputString) {
        var i,
            reversed = "";

        for (i = 0; i < inputString.length; i += 1) {
            reversed += inputString[inputString.length - i - 1];
        }

        return reversed;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "number")) {
            var numberString = jsConsole.read("#number"),
                reversed = reverseDigits(numberString);

            jsConsole.writeLine(numberString + " -&gt; " + reversed);

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };
}());