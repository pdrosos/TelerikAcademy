/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Four
 *  
 * Write an expression that checks for given integer if its third digit (right-to-left) is 7. 
 * E. g. 1732 -> true.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Get digit from integer number
     */
    function getDigit(number, digit) {
        return parseInt(number / Math.pow(10, digit - 1), 10) % 10;
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
                digitPosition = 3,
                digitValue = 7;

            if (getDigit(number, digitPosition) === digitValue) {
                jsConsole.writeLine('Digit ' + digitPosition + ' from ' + number + ' has value ' + digitValue);
            } else {
                jsConsole.writeLine('Digit ' + digitPosition + ' from ' + number + ' does not have value ' + digitValue);
            }
        }
    });
});