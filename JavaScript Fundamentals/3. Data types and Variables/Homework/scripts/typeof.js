/*jslint browser: true*/
/*global jsConsole*/

(function () {
    'use strict';

    /**
     * Task Three
     * 
     * Try typeof on all variables you created.
     */
    var intLiteral = 6,
        floatLiteral = 6.55,
        boolLiteral = true,
        stringLiteral = 'Hi JavaScript',
        objectLiteral = {
            name: 'Пешо',
            age: 30
        },
        arrayLiteral = [1, 2, 3],
        functionLiteral = function () {
            return 'Function called';
        };

    jsConsole.writeLine('Typeof integer literal: ' + typeof intLiteral);
    jsConsole.writeLine('Typeof float literal: ' + typeof floatLiteral);
    jsConsole.writeLine('Typeof Bool literal: ' + typeof boolLiteral);
    jsConsole.writeLine('Typeof string literal: ' + typeof stringLiteral);
    jsConsole.writeLine('Typeof object literal: ' + typeof objectLiteral);
    jsConsole.writeLine('Typeof array literal: ' + typeof arrayLiteral);
    jsConsole.writeLine('Typeof function literal: ' + typeof functionLiteral);
}());