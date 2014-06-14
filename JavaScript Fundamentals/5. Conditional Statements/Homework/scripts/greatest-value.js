/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Seven
 * 
 * Write a script that finds the greatest of given 5 variables.
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
            },
            numberFour: {
                required: true,
                number: true
            },
            numberFive: {
                required: true,
                number: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var numberOne = parseFloat(document.getElementById('numberOne').value),
                numberTwo = parseFloat(document.getElementById('numberTwo').value),
                numberThree = parseFloat(document.getElementById('numberThree').value),
                numberFour = parseFloat(document.getElementById('numberFour').value),
                numberFive = parseFloat(document.getElementById('numberFive').value),
                numbersArray,
                sortedNumbersArray;

            numbersArray = [numberOne, numberTwo, numberThree, numberFour, numberFive];
            // Clone array
            sortedNumbersArray = numbersArray.slice(0);
            // Sort numbers (numerically and descending)
            sortedNumbersArray.sort(function (a, b) { return b - a; });

            jsConsole.writeLine('The greatest number of ' + numbersArray.join(', ') + ' is ' + sortedNumbersArray[0]);
        }
    });
});
