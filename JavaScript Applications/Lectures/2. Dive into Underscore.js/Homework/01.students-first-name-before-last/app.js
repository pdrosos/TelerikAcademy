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
            $filteredStudentsHeading = $("<h2></h2>").html("Students with first name before last:"),
            students;

            $allStudents.append($allStudentsHeading);
            $filteredStudents.append($filteredStudentsHeading);

            students = [
                {firstName: "Petar", lastName: "Petrov"},
                {firstName: "Ivan", lastName: "Donchev"},
                {firstName: "Galia", lastName: "Dimitrova"},
                {firstName: "Todor", lastName: "Hristov"},
                {firstName: "Maria", lastName: "Getova"},
                {firstName: "Dimitar", lastName: "Genkov"},
                {firstName: "Petya", lastName: "Velkova"},
                {firstName: "Evgeny", lastName: "Zhekov"},
                {firstName: "Maria", lastName: "Yancheva"},
                {firstName: "Petar", lastName: "Chorbadzhiev"},
            ];

        for (var i = 0; i < students.length; i++) {
            $("<p></p>")
                .html(students[i].firstName + " " + students[i].lastName)
                .appendTo($allStudents);
        }

        $("body").append($allStudents);

        var filtered = _.filter(students, function (student) {
            return student.firstName < student.lastName;
        });

        var filteredAndSorted = _.sortBy(filtered, function (student) { 
            return student.firstName + " " + student.lastName;
        }).reverse();

        for (var i = 0; i < filtered.length; i++) {
            $("<p></p>")
                .html(filteredAndSorted[i].firstName + " " + filteredAndSorted[i].lastName)
                .appendTo($filteredStudents);
        }

        $("body").append($filteredStudents);

    });
}());