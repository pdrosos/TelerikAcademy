/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Five
 * 
 * Write script that asks for a digit and depending on the input shows the name of that digit (in English) 
 * using a switch statement.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Get digit name in English
     */
    function digitNameEn(digit) {
        var name;

        switch (digit) {
        case 0:
            name = "zero";
            break;
        case 1:
            name = "one";
            break;
        case 2:
            name = "two";
            break;
        case 3:
            name = "three";
            break;
        case 4:
            name = "four";
            break;
        case 5:
            name = "five";
            break;
        case 6:
            name = "six";
            break;
        case 7:
            name = "seven";
            break;
        case 8:
            name = "eight";
            break;
        case 9:
            name = "nine";
            break;
        }

        return name;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            digit: {
                required: true,
                digits: true,
                min: 0,
                max: 9
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var digit = parseInt(document.getElementById('digit').value, 10);

            jsConsole.writeLine('The English name of ' + digit + ' is ' + digitNameEn(digit));
        }
    });
});
