/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
    var mostFrequentNumberOccurrences = 1;

    function getMostFrequentNumber(numbers) {
        var i,
            numbersCloned,
            mostFrequentNumber,
            occurrences = 1,
            previousOccurrences = 0;

        numbersCloned = numbers.slice(0);
        numbersCloned.sort(function (a, b) { return a - b; });

        for (i = 0; i < numbersCloned.length - 1; i += 1) {

            if (numbersCloned[i] < numbersCloned[i + 1]) {

                if (occurrences > previousOccurrences) {
                    mostFrequentNumber = numbersCloned[i];
                    mostFrequentNumberOccurrences = occurrences;
                }

                previousOccurrences = occurrences;
                occurrences = 0;
            }

            if (i === numbersCloned.length - 2) {
                occurrences += 1;
                if (occurrences > previousOccurrences) {
                    mostFrequentNumber = numbersCloned[i];
                    mostFrequentNumberOccurrences = occurrences;
                }
            }

            occurrences += 1;
        }
        return mostFrequentNumber;
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
        mostFrequentNumberOccurrences = 1;
        var numbers = fillArrayWithNumbers(jsConsole.read("#number-seq")),
            mostFrequent = getMostFrequentNumber(numbers);

        jsConsole.writeLine("{" + numbers.join(", ") + "}" + " -&gt; " + mostFrequent
            + " (" + mostFrequentNumberOccurrences + " times)");
    };
}());