/// <reference path="../libs/jquery.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/underscore.js" />
(function () {
    "use strict";
    require.config({
        paths: {
            "jquery": "../libs/jquery",
            "underscore": "../libs/underscore"
        }
    });

    require(["jquery", "underscore"], function () {

        var $allStudents = $("<div></div>"),
            $allStudentsHeading = $("<h2></h2>").html("All students:"),
            $filteredStudents = $("<div></div>"),
            $filteredStudentsHeading = $("<h2></h2>").html("Students with age between 18 and 24:"),
            students;

            $allStudents.append($allStudentsHeading);
            $filteredStudents.append($filteredStudentsHeading);

        students = [
            {firstName: "Petar", lastName: "Petrov", age: 18},
            {firstName: "Ivan", lastName: "Donchev", age: 34},
            {firstName: "Galia", lastName: "Dimitrova", age: 17},
            {firstName: "Todor", lastName: "Hristov", age: 45},
            {firstName: "Maria", lastName: "Getova", age: 21},
            {firstName: "Dimitar", lastName: "Genkov", age: 52},
            {firstName: "Petya", lastName: "Velkova", age: 15},
            {firstName: "Evgeny", lastName: "Zhekov", age: 23},
            {firstName: "Maria", lastName: "Yancheva", age: 32},
            {firstName: "Petar", lastName: "Chorbadzhiev", age: 68},
        ];

        for (var i = 0; i < students.length; i++) {
            $("<p></p>")
                .html(students[i].firstName + " " + students[i].lastName)
                .appendTo($allStudents);
        }

        $("body").append($allStudents);
        
        var filtered = _.filter(students, function(student) { 
            return student.age >= 18 && student.age <= 24; 
        });

        var filteredAndSorted = _.sortBy(filtered, function (student) { 
            return student.firstName + " " + student.lastName;
        });

        for (var i = 0; i < filtered.length; i++) {
            $("<p></p>")
                .html(
                    filteredAndSorted[i].firstName 
                    + " " 
                    + filteredAndSorted[i].lastName 
                    + " , Age: "
                    + filteredAndSorted[i].age)
                .appendTo($filteredStudents);
        }

        $("body").append($filteredStudents);

    });
}());