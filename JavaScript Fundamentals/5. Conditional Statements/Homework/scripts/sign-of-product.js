/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Two
 * 
 * Write a script that shows the sign (+ or -) of the product of three real numbers 
 * without calculating it. Use a sequence of if statements.
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
                productSign;

            if ((numberOne > 0 && numberTwo > 0 && numberThree > 0) ||
                    (numberOne < 0 && numberTwo < 0 && numberThree > 0) ||
                    (numberOne < 0 && numberThree < 0 && numberTwo > 0) ||
                    (numberTwo < 0 && numberThree < 0 && numberOne > 0)) {
                productSign = '+';
            } else if (numberOne !== 0 && numberTwo !== 0 && numberThree !== 0) {
                productSign = '-';
            }

            if (productSign !== undefined) {
                jsConsole.writeLine('The product of ' + numberOne + ', ' + numberTwo + ' and ' + numberThree +
                    ' has a sign ' + productSign);
            } else {
                jsConsole.writeLine('The product of ' + numberOne + ', ' + numberTwo + ' and ' + numberThree +
                    ' has no sign (it is equal to 0)');
            }
        }
    });
});
