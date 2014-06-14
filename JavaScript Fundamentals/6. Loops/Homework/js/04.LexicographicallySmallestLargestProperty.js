/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    var objects = [window, document, navigator],
        property,
        properties,
        index,
        count;

    for (index = 0; index < objects.length; index += 1) {

        properties = [];
        count = 0;

        for (property in objects[index]) {
            properties[count] = property;
            count += 1;
        }

        properties.sort();

        jsConsole.writeLine(objects[index] + " (lexicographically smallest): " + properties[0]);
        jsConsole.writeLine(objects[index] + " (lexicographically largest): " + properties[properties.length - 1]);
    }
}());