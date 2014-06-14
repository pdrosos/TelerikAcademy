/*jslint browser: true*/
/*global jsConsole, isInputValid*/

(function () {
    'use strict';
    var numbers;

    function findIndexBinarySearch(integers, key, minIndex, maxIndex) {

        var middleIndex;

        // test if array is empty
        if (maxIndex < minIndex) {
            // set is empty, so return value showing not found
            return "Element not found";
        }

        // calculate midpoint to cut set in half
        middleIndex = parseInt((maxIndex + minIndex) / 2, 10);

        // three-way comparison
        if (integers[middleIndex] > key) {
            // key is in lower subset
            return findIndexBinarySearch(integers, key, minIndex, middleIndex - 1);
        }
        if (integers[middleIndex] < key) {
            // key is in upper subset
            return findIndexBinarySearch(integers, key, middleIndex + 1, maxIndex);
        }

        // key has been found
        return middleIndex;
    }

    numbers = [1, 2, 4, 5, 7, 9, 10];
    jsConsole.writeLine("Initial sorted array: " + numbers.join(", "));

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "arrElement")) {

            var element,
                minIndex,
                maxIndex,
                elementIndex;

            element = jsConsole.readInteger("#arrElement");
            minIndex = 0;
            maxIndex = numbers.length - 1;
            elementIndex = findIndexBinarySearch(numbers, element, minIndex, maxIndex);

            jsConsole.writeLine("The element index is: " + elementIndex);

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };

}());