jQuery(document).ready(function ($) {
    var students = [],
        studentsTable;

    students.push(createStudent('Peter', 'Ivanov', 3));
    students.push(createStudent('Milena', 'Grigorova', 6));
    students.push(createStudent('Gergana', 'Borisova', 12));
    students.push(createStudent('Boyko', 'Petrov', 7));

    studentsTable = $('<table>');
    appendTableHeader(studentsTable, ['First name', 'Last name', 'Grade']);
    appendTableBody(studentsTable, students);

    $('#container').append(studentsTable);

    function appendTableHeader(table, columnsNames) {
        var headerRow;

        headerRow = $('<tr>');
        $(table).append($('<thead>').append(headerRow));

        for (var i = 0; i < columnsNames.length; i++) {
            $(headerRow).append($('<th>').html(columnsNames[i]));
        }

        return table;
    }

    function appendTableBody(table, students) {
        var tBody,
            studentRow;

        tBody = $('<tbody>');

        for (var i = 0; i < students.length; i++) {
            studentRow = $('<tr>');

            $(studentRow).append($('<td>').html(students[i].firstName));
            $(studentRow).append($('<td>').html(students[i].lastName));
            $(studentRow).append($('<td>').html(students[i].grade));

            $(tBody).append(studentRow);
        }

        $(table).append(tBody);

        return table;
    }

    function createStudent(firstName, lastName, grade) {
        return {
            firstName: firstName,
            lastName: lastName,
            grade: grade
        }
    }
});