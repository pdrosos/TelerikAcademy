/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    //Deep copies object
    function clone(obj) {

        var copy,
            i,
            attr;

        // Handle the 3 simple types, and null or undefined
        if (obj === null || typeof obj !== "object") {
            return obj;
        }

        // Handle Date
        if (obj instanceof Date) {
            copy = new Date();
            copy.setTime(obj.getTime());
            return copy;
        }

        // Handle Array
        if (obj instanceof Array) {
            copy = [];
            for (i = 0; i < obj.length; i += 1) {
                copy[i] = clone(obj[i]);
            }
            return copy;
        }

        // Handle Object
        if (obj instanceof Object) {
            copy = {};
            for (attr in obj) {

                if (obj.hasOwnProperty(attr)) {
                    copy[attr] = clone(obj[attr]);
                }
            }
            return copy;
        }

        throw new Error("Unable to copy obj! Its type isn't supported.");
    }

    var integer = 5,
        numbers = [1, 4, 3, 2, 5],
        copiedNumber,
        copiedArray = [];

    jsConsole.writeLine("Primitive types:");

    jsConsole.writeLine("The initial number: " + integer);

    jsConsole.writeLine("Performing deep copy of the initial number...");
    copiedNumber = clone(integer);

    jsConsole.writeLine("Adding 1 to the copied number...");

    copiedNumber += 1;

    jsConsole.writeLine("The modified copied number: " + copiedNumber);

    jsConsole.writeLine("The initial number: " + integer + "<br />");

    jsConsole.writeLine("Reference types:");

    jsConsole.writeLine("The initial array: " + numbers.join(", "));

    jsConsole.writeLine("Performing deep copy of the initial array...");
    copiedArray = clone(numbers);

    jsConsole.writeLine("Changing the copied array 2nd element value to 17 ...");
    copiedArray.splice(2, 1, 17);

    jsConsole.writeLine("The modified copied array: " + copiedArray.join(", "));

    jsConsole.writeLine("The initial array: " + numbers.join(", "));

}());