/*jslint browser: true*/
/*jslint bitwise: true */
/*jshint bitwise: false*/
/*global jsConsole, $, jQuery*/

/**
 * Task One
 * 
 * Write an if statement that examines two integer variables and exchanges their values
 * if the first one is greater than the second one.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            integerOne: {
                required: true,
                integer: true
            },
            integerTwo: {
                required: true,
                integer: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var numberOne = parseInt(document.getElementById('integerOne').value, 10),
                numberTwo = parseInt(document.getElementById('integerTwo').value, 10);

            if (numberOne > numberTwo) {
                // bitwise exchange of the values of two integeres using xor
                numberOne = numberOne ^ numberTwo;
                numberTwo = numberOne ^ numberTwo;
                numberOne = numberOne ^ numberTwo;
            }

            jsConsole.writeLine("First number: " + numberOne);
            jsConsole.writeLine("Second number: " + numberTwo);
        }
    });
});
