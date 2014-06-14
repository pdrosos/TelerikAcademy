/*jslint browser: true*/
/*global jsConsole*/

(function () {
    'use strict';

    /**
     * Task One
     * 
     * Assign all the possible JavaScript literals to different variables.
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

    objectLiteral.toString = function () {
        return 'Name: ' + this.name + ', ' +
               'Age: ' + this.age;
    };

    jsConsole.writeLine('Integer literal: ' + intLiteral);
    jsConsole.writeLine('Float literal: ' + floatLiteral);
    jsConsole.writeLine('Bool literal: ' + boolLiteral);
    jsConsole.writeLine('String literal: ' + stringLiteral);
    jsConsole.writeLine('Object literal: ' + objectLiteral.toString());
    jsConsole.writeLine('Array literal: ' + arrayLiteral.join(', '));
    jsConsole.writeLine('Function literal: ' + functionLiteral.call());
}());