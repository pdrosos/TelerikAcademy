define(['courses/student'], function(Student) {
    'use strict';

    var Course;
    Course = (function(){
        function Course(name, totalScoreFormula) {
            this._name = name;
            this._totalScoreFormula = totalScoreFormula;

            this._students = [];
        }

        Course.prototype.addStudent = function(student) {
            if(!(student instanceof Student)){
                throw {
                    message: student + ' is not a student'
                };
            }

            this._students.push(student);

            return this;
        };

        Course.prototype.calculateResults = function() {
            var self = this;

            this._students.forEach(function(student) {
                student.totalScore = self._totalScoreFormula(student);
            });
        };

        Course.prototype.getTopStudentsByExam = function(count) {
            return getTopStudents(this._students, count, 'exam');
        };

        Course.prototype.getTopStudentsByTotalScore = function(count) {
            return getTopStudents(this._students, count, 'totalScore');
        };

        function getTopStudents(students, count, sortBy) {
            students.sort(function(first, second) {
                return second[sortBy] - first[sortBy];
            });

            return students.slice(0, count);
        }

        return Course;
    }());

    return Course;
});