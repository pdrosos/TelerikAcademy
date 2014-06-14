/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Three
 * 
 * Write an expression that calculates rectangle’s area by given width and height.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Calculate rectangle area
     */
    function calculateRectangleArea(width, height) {
        return width * height;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            width: {
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
            var width = parseFloat(document.getElementById('width').value),
                height = parseFloat(document.getElementById('height').value);

            jsConsole.writeLine('Rectangle area is ' + calculateRectangleArea(width, height));
        }
    });
});
