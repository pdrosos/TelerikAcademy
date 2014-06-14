/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
    function maxIncreasingSequence(numberArray) {
        var index = 0,
            counter = 1,
            maxLength = 1,
            i;

        for (i = 1; i < numberArray.length; i += 1) {
            counter = numberArray[i - 1] < numberArray[i] ? counter + 1 : 1;

            if (counter > maxLength) {
                maxLength = counter;
                index = i - counter + 1;
            }
        }

        return numberArray.slice(index, index + maxLength);
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
            max = maxIncreasingSequence(numbers);

        jsConsole.writeLine("{" + numbers.join(", ") + "}" + " -&gt; {" + max.join(", ") + "}");
    };
}());