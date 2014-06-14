/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';
    function compareCharArraysLexicographically(chars01, chars02) {
        var partiallyEqual = true,
            minLength = chars01.length < chars02.length ? chars01.length : chars02.length,
            i;

        for (i = 0; i < minLength; i += 1) {
            if (chars01[i] < chars02[i]) {
                partiallyEqual = false;
                return 1;
            }
            if (chars01[i] > chars02[i]) {
                partiallyEqual = false;
                return -1;
            }
        }

        if (partiallyEqual && chars01.length === chars02.length) {
            return 0;
        }

        return partiallyEqual && (chars01.length < chars02.length) ? 1 : -1;
    }

    function convertInputToStringArray(inputString) {
        var regex,
            strings;

        //regular expression for splitting string by udefined number of spaces containing comma
        regex = /\s*,\s*/;
        strings = inputString.split(regex);
        return strings;
    }

    document.getElementById("process").onclick = function () {

        var chars01 = [],
            chars02 = [],
            result;

        chars01 = convertInputToStringArray(jsConsole.read("#chars01"));
        chars02 = convertInputToStringArray(jsConsole.read("#chars02"));

        result = compareCharArraysLexicographically(chars01, chars02);

        switch (result) {
        case 1:
            jsConsole.writeLine("Array 01 precedes Array 02 lexicographically");
            break;
        case -1:
            jsConsole.writeLine("Array 02 precedes Array 01 lexicographically");
            break;
        case 0:
            jsConsole.writeLine("Array 01 and Array 02 are lexicographically equal");
            break;
        default:
            jsConsole.writeLine("Not defined");
        }
    };
}());