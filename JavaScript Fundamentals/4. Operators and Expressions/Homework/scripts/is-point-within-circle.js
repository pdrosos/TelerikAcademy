/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Six
 *  
 * Write an expression that checks if given print (x,  y) is within a circle K(O, 5).
 */
$(document).ready(function () {
    'use strict';

    /**
     * Check if point is within circle
     */
    function isPointWithinCircle(circleCenterX, circleCenterY, circleRadius, pointX, pointY) {
        // Pythagorean theorem
        return Math.pow((pointX - circleCenterX), 2) + Math.pow((pointY - circleCenterY), 2) <= Math.pow(circleRadius, 2);
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            pointX: {
                required: true,
                number: true
            },
            pointY: {
                required: true,
                number: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var pointX = parseFloat(document.getElementById('pointX').value),
                pointY = parseFloat(document.getElementById('pointY').value),
                circleCenterX = 0,
                circleCenterY = 0,
                circleRadius = 5;

            if (isPointWithinCircle(circleCenterX, circleCenterY, circleRadius, pointX, pointY)) {
                jsConsole.writeLine('Point(' + pointX + ', ' + pointY + ') is within a cirle((' +
                    circleCenterX + ', ' + circleCenterY + '), ' + circleRadius + ')');
            } else {
                jsConsole.writeLine('Point(' + pointX + ', ' + pointY + ') is outside a cirle((' +
                    circleCenterX + ', ' + circleCenterY + '), ' + circleRadius + ')');
            }
        }
    });
});