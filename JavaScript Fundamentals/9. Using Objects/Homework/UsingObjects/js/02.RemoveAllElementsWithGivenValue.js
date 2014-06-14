/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    Array.prototype.remove = function (element) {
        var i;
        for (i = 0; i < this.length; i += 1) {
            if (this[i] === element) {
                this.splice(i, 1);
            }
        }
    };

    var array = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    jsConsole.writeLine("The initial array: " + array.join(", "));

    array.remove(1);

    jsConsole.writeLine("The result array: " + array.join(", "));

}());