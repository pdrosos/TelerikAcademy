/*jslint browser: true*/
/*global jsConsole*/

(function () {
    'use strict';

    function isElementBiggerThanNeighbors(numbers, position) {
        if (position === 0 || position === numbers.length - 1) {
            return -1;
        }
        if (numbers[position] > numbers[position - 1]
                && numbers[position] > numbers[position + 1]) {
            return 1;
        }
        return -1;
    }

    function getFirstElementBiggerThanNeighborsIndex(numbers) {
        var index = -1,
            i;

        for (i = 0; i < numbers.length; i += 1) {
            if (isElementBiggerThanNeighbors(numbers, i) === 1) {
                index = i;
                break;
            }
        }
        return index;
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

        var numbers,
            resultIndex;

        numbers = fillArrayWithNumbers(jsConsole.read("#number-seq"));

        resultIndex = getFirstElementBiggerThanNeighborsIndex(numbers);

        if (resultIndex >= 0) {
            jsConsole.writeLine("First element bigger than its neighbors index: " + resultIndex);
        } else {
            jsConsole.writeLine("There is no element bigger than its two neighbors");
        }

    };

}());