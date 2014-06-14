/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';

    function isElementBiggerThanNeighbors(numbers, position) {
        if (position === 0 || position === numbers.length - 1) {
            return 0;
        }
        if (numbers[position] > numbers[position - 1]
                && numbers[position] > numbers[position + 1]) {
            return 1;
        }
        return -1;
    }

    function fillArrayWithNumbers(inputString) {
        var spaces,
            numbers,
            index;

        spaces = /\s*,\s*/;
        numbers = inputString.split(spaces);
        for (index = 0; index < numbers.length; index += 1) {
            numbers[index] = Number(numbers[index]);
        }
        return numbers;
    }

    document.getElementById("process").onclick = function () {

        var position,
            numbers,
            result;

        position = jsConsole.readInteger("#position");
        numbers = fillArrayWithNumbers(jsConsole.read("#number-seq"));

        if (isInputValid("int", "position") && position >= 0 && position < numbers.length) {

            result = isElementBiggerThanNeighbors(numbers, position);

            if (result === 1) {
                jsConsole.writeLine("Element " + numbers[position] + " at position "
                    + position + " IS bigger than its neighbors.");
            }

            if (result === -1) {
                jsConsole.writeLine("Element " + numbers[position] + " at position "
                    + position + " is NOT bigger than its neighbors.");
            }

            if (result === 0) {
                jsConsole.writeLine("The element has just one neighbor.");
            }

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };
}());