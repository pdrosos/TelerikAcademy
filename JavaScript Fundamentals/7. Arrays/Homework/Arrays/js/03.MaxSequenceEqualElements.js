/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
    function EqualElementsMaxSubsequence(numberArray) {
        var currentSequenceLength = 1,
            currentSequenceStartIndex = 0,
            maxSequenceLength = 0,
            maxSequenceStartIndex = 0,
            m,
            maxSequenceSubarray = [];

        for (m = 0; m < numberArray.length - 1; m += 1) {
            if (numberArray[m + 1] === numberArray[m]) {
                currentSequenceLength += 1;
                continue;
            }

            if (currentSequenceLength > maxSequenceLength) {
                maxSequenceLength = currentSequenceLength;
                maxSequenceStartIndex = currentSequenceStartIndex;
            }
            currentSequenceLength = 1;
            currentSequenceStartIndex = m + 1;
        }

        if (currentSequenceLength > maxSequenceLength) {
            maxSequenceLength = currentSequenceLength;
            maxSequenceStartIndex = currentSequenceStartIndex;
        }

        maxSequenceSubarray = numberArray.slice(maxSequenceStartIndex, maxSequenceStartIndex + maxSequenceLength);
        return maxSequenceSubarray;
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
            maxSequence = new EqualElementsMaxSubsequence(numbers);

        jsConsole.writeLine("{" + numbers.join(", ") + "}" + " -&gt; {" + maxSequence.join(", ") + "}");
    };
}());