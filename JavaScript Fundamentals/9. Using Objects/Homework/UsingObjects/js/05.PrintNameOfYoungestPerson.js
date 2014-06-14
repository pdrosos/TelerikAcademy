/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    function findYoungestPerson(persons) {
        var i,
            lowestAge = Number.MAX_VALUE,
            youngestPerson;

        for (i = 0; i < persons.length; i += 1) {
            if (persons[i].age < lowestAge) {
                youngestPerson = persons[i];
            }
        }
        return youngestPerson.firstname + " " + youngestPerson.lastname;
    }

    var persons = [
        { firstname : 'Georgi', lastname: 'Petrov', age: 32 },
        { firstname: 'Dimitar', lastname: 'Hristov', age: 25 },
        { firstname: 'Pencho', lastname: 'Popadinski', age: 21 }
    ],
        i;

    jsConsole.writeLine("Persons List:");

    for (i = 0; i < persons.length; i += 1) {
        jsConsole.writeLine(persons[i].firstname + " " + persons[i].lastname
            + ", Age: " + persons[i].age);
    }

    jsConsole.writeLine("Youngest person: " + findYoungestPerson(persons));

}());