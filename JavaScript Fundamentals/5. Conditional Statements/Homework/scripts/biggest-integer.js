/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Three
 * 
 * Write a script that finds the biggest of three integers using nested if statements.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Find the biggest of three integers
     */
    function findMax(numberOne, numberTwo, numberThree) {
        if (numberOne >= numberTwo) {
            if (numberOne >= numberThree) {
                return numberOne;
            }
        }

        if (numberTwo > numberOne) {
            if (numberTwo > numberThree) {
                return numberTwo;
            }
        }

        return numberThree;
    }

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
            },
            integerThree: {
                required: true,
                integer: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var numberOne = parseInt(document.getElementById('integerOne').value, 10),
                numberTwo = parseInt(document.getElementById('integerTwo').value, 10),
                numberThree = parseInt(document.getElementById('integerThree').value, 10);

            jsConsole.writeLine('The biggest number of ' + numberOne + ', ' + numberTwo + ' and ' + numberThree +
                ' is ' + findMax(numberOne, numberTwo, numberThree));
        }
    });
});
