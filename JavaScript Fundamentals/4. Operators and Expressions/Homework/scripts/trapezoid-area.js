/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Eight
 * 
 * Write an expression that calculates trapezoid's area by given sides a and b and height h.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Calculate trapezoid area
     */
    function calculateTrapezoidArea(sideA, sideB, height) {
        return ((sideA + sideB) / 2) * height;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            sideA: {
                required: true,
                number: true,
                min: 0
            },
            sideB: {
                required: true,
                number: true,
                min: 0
            },
            height: {
                required: true,
                number: true,
                min: 0
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var sideA = parseFloat(document.getElementById('sideA').value),
                sideB = parseFloat(document.getElementById('sideB').value),
                height = parseFloat(document.getElementById('height').value);

            jsConsole.writeLine('Trapezoid area is ' + calculateTrapezoidArea(sideA, sideB, height));
        }
    });
});
