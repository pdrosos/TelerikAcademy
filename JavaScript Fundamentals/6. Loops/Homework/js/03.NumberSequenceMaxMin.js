/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
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

    function getMaxValue(numbersArray) {

        var maxValue = -Number.MAX_VALUE,
            i;
        for (i = 0; i < numbersArray.length; i += 1) {
            if (maxValue < numbersArray[i]) {
                maxValue = numbersArray[i];
            }
        }
        return maxValue;
    }

    function getMinValue(numbersArray) {

        var minValue = Number.MAX_VALUE,
            i;

        for (i = 0; i < numbersArray.length; i += 1) {
            if (minValue > numbersArray[i]) {
                minValue = numbersArray[i];
            }
        }
        return minValue;
    }

    document.getElementById("process").onclick = function () {

        var numbers = [],
            index;

        numbers = fillArrayWithNumbers(jsConsole.read("#number-seq"));

        for (index in numbers) {
            if (numbers[index] !== null && numbers[index] !== undefined) {
                jsConsole.writeLine(numbers[index]);
            }
        }

        jsConsole.writeLine("Max number: " + getMaxValue(numbers));
        jsConsole.writeLine("Min number: " + getMinValue(numbers));
    };
}());