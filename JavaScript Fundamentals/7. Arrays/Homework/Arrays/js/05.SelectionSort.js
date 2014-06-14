/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
    function selectionSort(numbers) {
        var i,
            j,
            smallestNumber,
            smallestNumberIndex,
            swap,
            numbersCloned;

        numbersCloned = numbers.slice(0);

        for (i = 0; i < numbersCloned.length; i += 1) {

            smallestNumber = numbersCloned[i];
            smallestNumberIndex = i;

            for (j = i; j < numbersCloned.length; j += 1) {
                if (numbersCloned[j] < smallestNumber) {
                    smallestNumber = numbersCloned[j];
                    smallestNumberIndex = j;
                }
            }

            swap = numbersCloned[i];
            numbersCloned[i] = numbersCloned[smallestNumberIndex];
            numbersCloned[smallestNumberIndex] = swap;
        }

        return numbersCloned;
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

        var numbers = fillArrayWithNumbers(jsConsole.read("#number-seq")),
            sorted = selectionSort(numbers);

        jsConsole.writeLine("{" + numbers.join(", ") + "}" + " -&gt; {" + sorted.join(", ") + "}");
    };
}());