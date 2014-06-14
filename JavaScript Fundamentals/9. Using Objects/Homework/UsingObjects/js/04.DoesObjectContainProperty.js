/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    //simulates Person class
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    Person.prototype.toString = function () {
        return this.firstName + " " + this.lastName + ", " + "Age: " + this.age;
    };

    //function hasProperty(obj, searchedProperty) {

    //    var prop;
    //    for (prop in obj) {
    //        if (prop === searchedProperty) {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //checks if a object (obj) has property (searchedProperty)
    function hasProperty(obj, searchedProperty) {
        if (obj.hasOwnProperty(searchedProperty)) {
            return true;
        }
        return false;
    }

    var person = new Person("Ivan", "Petrov", "23"),
        searchedProperty,
        hasProp;

    searchedProperty = 'firstName';

    hasProp = hasProperty(person, searchedProperty);

    jsConsole.writeLine("Object: '" + person + "' has property '" + searchedProperty + "': " + hasProp);

}());