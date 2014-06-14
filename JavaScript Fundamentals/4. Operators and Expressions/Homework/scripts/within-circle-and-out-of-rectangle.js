/*jslint browser: true*/
/*global jsConsole, $, jQuery*/

/**
 * Task Nine
 * 
 * Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
 * and out of the rectangle R(top=1, left=-1, width=6, height=2).
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
     * Check if point is within rectangle
     */
    function isPointWithinRectangle(upperLeftX, upperLeftY, height, width, pointX, pointY) {
        if ((upperLeftX <= pointX && pointX <= upperLeftX + width) &&
                (upperLeftY - height <= pointY && pointY <= upperLeftY)) {
            return true;
        }

        return false;
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
                circleCenterX = 1,
                circleCenterY = 1,
                circleRadius = 3,
                rectangleUpperLeftX = -1,
                rectangleUpperLeftY = 1,
                rectangleHeight = 2,
                rectangleWidth = 6,
                isWithinCircle,
                isWithinRectangle,
                pointString,
                cirleString,
                rectangleString;

            isWithinCircle = isPointWithinCircle(circleCenterX, circleCenterY, circleRadius, pointX, pointY);
            isWithinRectangle = isPointWithinRectangle(rectangleUpperLeftX, rectangleUpperLeftY, rectangleHeight, rectangleWidth, pointX, pointY);

            pointString = 'Point(' + pointX + ', ' + pointY + ')';
            cirleString = 'cirle((' + circleCenterX + ', ' + circleCenterY + '), ' + circleRadius + ')';
            rectangleString = 'rectangle(top = ' + rectangleUpperLeftY + ', left = ' + rectangleUpperLeftX +
                ', width = ' + rectangleWidth + ', height = ' + rectangleHeight + ')';

            if (isWithinCircle && isWithinRectangle) {
                jsConsole.writeLine(pointString + ' is within ' + cirleString + ' and within ' + rectangleString);
            } else if (isWithinCircle) {
                jsConsole.writeLine(pointString + ' is within ' + cirleString + ' and out of ' + rectangleString);
            } else if (isWithinRectangle) {
                jsConsole.writeLine(pointString + ' is out of ' + cirleString + ' and within ' + rectangleString);
            } else {
                jsConsole.writeLine(pointString + ' is out of ' + cirleString + ' and out of ' + rectangleString);
            }
        }
    });
});