/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task One
 * 
 * Write an expression that checks if given integer is odd or even.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Check if a number is even
     */
    function isEven(number) {
        if (number % 2 === 0) {
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
            var number = parseInt(document.getElementById('integer').value, 10);

            if (isEven(number)) {
                jsConsole.writeLine(number + ' is even');
            } else {
                jsConsole.writeLine(number + ' is odd');
            }
        }
    });
});
