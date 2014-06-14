/*jslint browser: true*/
/*jslint bitwise: true */
/*jshint bitwise: false*/
/*global jsConsole, $, jQuery*/

/**
 * Task Five
 *  
 * Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
 */
$(document).ready(function () {
    'use strict';

    /**
     * Get bit from integer number
     */
    function getBit(number, position) {
        if ((number & (1 << position)) === 0) {
            return 0;
        }

        return 1;
    }

    /**
     * Validation
     */
    $('#inputForm').validate({
        rules: {
            integer: {
                required: true,
                integer: true
            }
        },
        submitHandler: function () {
            // the form is valid - we solve the task here
            var number = parseInt(document.getElementById('integer').value, 10),
                bitPosition = 3;

            if (getBit(number, bitPosition) === 0) {
                jsConsole.writeLine('Bit ' + bitPosition + ' from ' + number +
                    ' (' + parseInt(number, 10).toString(2) + ') has value 0');
            } else {
                jsConsole.writeLine('Bit ' + bitPosition + ' from ' + number +
                    ' (' + parseInt(number, 10).toString(2) + ') has value 1');
            }
        }
    });
});