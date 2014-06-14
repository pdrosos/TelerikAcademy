/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Two
 * 
 * Write a boolean expression that checks for given integer 
 * if it can be divided (without remainder) by 7 and 5 in the same time.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Check if a number is divisible without reminder
     */
    function isDivisible(number, divisorOne, divisorTwo) {
        if (number % divisorOne === 0 && number % divisorTwo === 0) {
            return true;
        }

        return false;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            integer: {
                required: true,
                integer: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var number = parseInt(document.getElementById('integer').value, 10),
                divisorOne = 5,
                divisorTwo = 7;

            if (isDivisible(number, divisorOne, divisorTwo)) {
                jsConsole.writeLine(number + ' is divisible by ' + divisorOne + ' and ' + divisorTwo);
            } else {
                jsConsole.writeLine(number + ' is not divisible by ' + divisorOne + ' and ' + divisorTwo);
            }
        }
    });
});
