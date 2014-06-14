/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Seven
 * 
 * Write an expression that checks if given positive integer number n (n ≤ 100) is prime. 
 * E.g. 37 is prime.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Check if positive integer is prime
     */
    function isPrime(number) {
        var i;

        if (number <= 1 || (number > 2 && number % 2 === 0)) {
            return false;
        }

        for (i = 3; number >= i * i; i += 2) {
            if (number % i === 0) {
                return false;
            }
        }

        return true;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            integer: {
                required: true,
                digits: true,
                min: 1,
                max: 100
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var number = parseInt(document.getElementById('integer').value, 10);

            if (isPrime(number)) {
                jsConsole.writeLine(number + ' is a prime number');
            } else {
                jsConsole.writeLine(number + ' is not a prime number');
            }
        }
    });
});