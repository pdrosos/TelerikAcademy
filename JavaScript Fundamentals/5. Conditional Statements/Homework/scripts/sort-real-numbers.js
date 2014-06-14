/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Four
 * 
 * Sort 3 real values in descending order using nested if statements.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            numberOne: {
                required: true,
                number: true
            },
            numberTwo: {
                required: true,
                number: true
            },
            numberThree: {
                required: true,
                number: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var numberOne = parseFloat(document.getElementById('numberOne').value),
                numberTwo = parseFloat(document.getElementById('numberTwo').value),
                numberThree = parseFloat(document.getElementById('numberThree').value),
                numbersArray,
                sortedNumbersArray;

            // javaScript has built-in sort function, so I won't use nested if statements here
            numbersArray = [numberOne, numberTwo, numberThree];
            // Clone array
            sortedNumbersArray = numbersArray.slice(0);
            // Sort numbers (numerically and descending)
            sortedNumbersArray.sort(function (a, b) { return b - a; });

            jsConsole.writeLine('The descending sorted sequence of ' + numbersArray.join(', ') + ' is ' + sortedNumbersArray.join(', '));
        }
    });
});
