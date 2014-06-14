/*global jsConsole, isInputValid, testCountNumberOccurrences*/
/*jslint browser: true*/

(function () {
    "use strict";
    function countNumberOccurrences(numbersArray, number) {
        var i,
            count = 0;

        for (i = 0; i < numbersArray.length; i += 1) {
            if (numbersArray[i] === number) {
                count += 1;
            }
        }

        return count;
    }

    function testCountNumberOccurrences() {
        var numberArrays,
            searchedNumbers,
            valuesExpected,
            output = '',
            i;

        numberArrays = [
            [4, 1, 4, -2, 6, 7, 4],
            [2, 1, 5, 7, 8, 7, 2]
        ];

        searchedNumbers = [4, 7];
        valuesExpected = [3, 2];

        for (i = 0; i < numberArrays.length; i += 1) {

            if (countNumberOccurrences(numberArrays[i], searchedNumbers[i]) === valuesExpected[i]) {
                output += "Test " + (i + 1) + " Passed!" + "<br />";
            } else {
                output += "Test " + (i + 1) + " Failed!" + "<br />";
            }
        }

        return output;
    }

    function fillArrayWithNumbers(inputString) {
        var pattern,
            numbers,
            index;

        pattern = /\s*,\s*/;
        numbers = inputString.split(pattern);
        for (index = 0; index < numbers.length; index += 1) {
            numbers[index] = Number(numbers[index]);
        }
        return numbers;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "number")) {

            var stringArray,
                number,
                numbersArray,
                occurrences;

            stringArray = jsConsole.read("#number-seq");
            number = jsConsole.readInteger("#number");

            numbersArray = fillArrayWithNumbers(stringArray);
            occurrences = countNumberOccurrences(numbersArray, number);

            jsConsole.writeLine("[" + numbersArray.join(", ") + "] -&gt; "
                + number + " (" + occurrences + " time" + (occurrences > 1 ? "s" : "") + ")");

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };

    document.getElementById("unitTest").onclick = function () {

        jsConsole.writeLine(testCountNumberOccurrences());
    };

}());