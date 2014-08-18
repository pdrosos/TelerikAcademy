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
            $studentWithHighestMarks = $("<div></div>"),
            $studentWithHighestMarksHeading = $("<h2></h2>").html("Student with highest marks:"),
            students;

            $allStudents.append($allStudentsHeading);
            $studentWithHighestMarks.append($studentWithHighestMarksHeading);

        students = [
            {firstName: "Petar", lastName: "Petrov", marks: {CSharp: 60, HTML: 40, Java: 80}},
            {firstName: "Ivan", lastName: "Donchev", marks: {PHP: 90, ASPNET: 70, Python: 100}},
            {firstName: "Galia", lastName: "Dimitrova", marks: {CSharp: 60, HTML: 40, Java: 80, WebApps: 70}},
            {firstName: "Todor", lastName: "Hristov", marks: {CSharp: 40, HTML: 40, CSS: 80}},
            {firstName: "Maria", lastName: "Getova", marks: {VB: 60, Ruby: 20, JavaScript: 40}},
            {firstName: "Dimitar", lastName: "Genkov", marks: {CSharp: 60, HTML: 40, Photoshop: 60}},
            {firstName: "Petya", lastName: "Velkova", marks: {HTML: 40, CSharp: 60}},
            {firstName: "Evgeny", lastName: "Zhekov", marks: {CompScience: 90, Java: 80}},
            {firstName: "Maria", lastName: "Yancheva", marks: {Algorithms: 85, CSS: 45, CPlusPlus: 80}},
            {firstName: "Petar", lastName: "Chorbadzhiev", marks: {HTML: 100, Java: 80}},
        ];

        for (var i = 0; i < students.length; i++) {
            $("<p></p>")
                .html(students[i].firstName + " " + students[i].lastName)
                .appendTo($allStudents);
        }

        $("body").append($allStudents);

        var studentWithHighestGrades = getStudentWithHighestGrades(students);

        $studentWithHighestMarks.append(
            "<p>" 
            + studentWithHighestGrades.firstName 
            + " "
            + studentWithHighestGrades.lastName
            + " , Marks average: "
            + getStudentMarksAverage(studentWithHighestGrades.marks) 
            + "</p>"
        );

         $("body").append($studentWithHighestMarks);

        function getStudentWithHighestGrades(students) {
            var highestMarksAverage = -1,
                sudentWithHighestMarksIndex = 0;

            _.each(students, function (student, index) {

                var currentMarksAverage = getStudentMarksAverage(student.marks);

                if (highestMarksAverage < currentMarksAverage) {
                    highestMarksAverage = currentMarksAverage;
                    sudentWithHighestMarksIndex = index;
                }
            });

            return students[sudentWithHighestMarksIndex];
        }

        function getStudentMarksAverage(marks) {
            var currentMarksSum = 0,
                currentMarksAverage;

            _.each(marks, function (mark) {
                currentMarksSum += mark;
            });
            currentMarksAverage = currentMarksSum / Object.keys(marks).length;
            return currentMarksAverage;
        }
    });
}());