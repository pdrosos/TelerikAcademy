/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    function group(people, property) {
        var group = {};
        switch (property) {
        case "firstname":
            for (var i in people) {
                var firstname = people[i].firstname;
                group[firstname] = group[firstname] || [];
                group[firstname].push(people[i]);
            }
            break;
        case "lastname":
            for (var i in people) {
                var lastname = people[i].lastname;
                group[lastname] = group[lastname] || [];
                group[lastname].push(people[i]);
            }
            break;
        case "age":
            for (var i in people) {
                var age = people[i].age;
                group[age] = group[age] || [];
                group[age].push(people[i]);
            }
            break;
        default:
            return undefined;
        }
        return group;
    }

    var people = [
        { firstname: "Gosho", lastname: "Petrov", age: 27 },
        { firstname: "Dimitar", lastname: "Hristov", age: 45 },
        { firstname: "Dimitar", lastname: "Petkov", age: 56 },
        { firstname: "Gosho", lastname: "Hristov", age: 27 },
        { firstname: "Hristo", lastname: "Smirnenski", age: 34 },
        { firstname: "Jeliu", lastname: "Jelev", age: 56 },
        { firstname: "Grozdan", lastname: "Petrov", age: 45 }
    ];

    var groupedByFname,
        groupedByLname,
        groupedByAge;

    groupedByFname = group(people, "firstname");

    jsConsole.writeLine("By first name:");
    for (var i in groupedByFname) {
        jsConsole.writeLine("Group: " + i);
    }

    groupedByLname = group(people, "lastname");

    jsConsole.writeLine("By last name:");
    for (var i in groupedByLname) {
        jsConsole.writeLine("Group: " + i);
    }

    groupedByAge = group(people, "age");

    jsConsole.writeLine("By age:");
    for (var i in groupedByAge) {
        jsConsole.writeLine("Group: " + i);
    }

}());