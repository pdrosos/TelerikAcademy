/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Six
 * 
 * Write a script that enters the coefficients a, b and c of a quadratic equation
 * a*x2 + b*x + c = 0
 * and calculates and prints its real roots. 
 * Note that quadratic equations may have 0, 1 or 2 real roots.
 */
$(document).ready(function () {
    'use strict';

    function solveQuadraticEquation(a, b, c) {
        var roots = [],
            discriminant;

        discriminant = b * b - 4 * a * c;

        if (discriminant > 0) {
            //two roots
            roots[0] = (-b + Math.sqrt(discriminant)) / (2 * a);
            roots[1] = (-b - Math.sqrt(discriminant)) / (2 * a);
        } else if (discriminant === 0) {
            //one double root
            roots[0] = -b / (2 * a);
            roots[1] = -b / (2 * a);
        }

        return roots;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            coefficientA: {
                required: true,
                integer: true
            },
            coefficientB: {
                required: true,
                integer: true
            },
            coefficientC: {
                required: true,
                integer: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var coefficientA = parseInt(document.getElementById('coefficientA').value, 10),
                coefficientB = parseInt(document.getElementById('coefficientB').value, 10),
                coefficientC = parseInt(document.getElementById('coefficientC').value, 10),
                equationString,
                roots;

            roots = solveQuadraticEquation(coefficientA, coefficientB, coefficientC);

            equationString = 'Equation ' + coefficientA + 'x<sup>2</sup> + ' + coefficientB + 'x + ' + coefficientC + ' = 0';

            if (roots.length > 0) {
                jsConsole.writeLine(equationString + ' has roots ' + roots[0] + ' and ' + roots[1]);
            } else {
                jsConsole.writeLine(equationString + ' has no real roots');
            }
        }
    });
});
