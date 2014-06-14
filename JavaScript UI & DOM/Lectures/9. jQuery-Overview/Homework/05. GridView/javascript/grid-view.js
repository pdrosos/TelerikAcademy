jQuery(document).ready(function ($) {
    var students = [],
        subjects,
        studentsGrid;

    students.push(createStudent('Peter', 'Ivanov', 3, []));
    subjects = [];
    subjects.push(createSubject('Math', 8));
    subjects.push(createSubject('IT', 10));
    students.push(createStudent('Milena', 'Grigorova', 6, subjects));
    students.push(createStudent('Gergana', 'Borisova', 12, []));
    subjects = [];
    subjects.push(createSubject('English', 6));
    subjects.push(createSubject('Biology', 4));
    students.push(createStudent('Boyko', 'Petrov', 7, subjects));

    studentsGrid = generateGrid(students);
    $('#container').append(studentsGrid);

    function generateGrid(data) {
        var grid,
            columnsNames;

        if (data.length == 0) {
            return false;
        }

        columnsNames = extractColumnsNames(data[0]);

        grid = $('<table>');
        appendGridHeader(grid, columnsNames);
        appendGridBody(grid, data);

        return grid;

        function extractColumnsNames(row) {
            var columnsNames = [];

            for (var propertyName in row) {
                if (!$.isArray(row[propertyName])) {
                    columnsNames.push(propertyName);
                }
            }

            return columnsNames;
        }

        function appendGridHeader(grid, columnsNames) {
            var headerRow;

            headerRow = $('<tr>');
            $(grid).append($('<thead>').append(headerRow));

            for (var i = 0; i < columnsNames.length; i++) {
                $(headerRow).append($('<th>').html(columnsNames[i]));
            }

            return grid;
        }

        function appendGridBody(grid, data) {
            var tBody,
                row,
                innerGrid,
                innerGridCell,
                innerGridData;

            tBody = $('<tbody>');

            for (var i = 0; i < data.length; i++) {
                innerGridData = null;
                row = $('<tr>');

                for (var propertyName in data[i]) {
                    if (!$.isArray(data[i][propertyName])) { // scalar data
                        $(row).append($('<td>').html(data[i][propertyName]));
                    } else if ($.isArray(data[i][propertyName]) && data[i][propertyName].length > 0) { // inner grid needed
                        innerGridData = data[i][propertyName];
                    }
                }

                if ($(row).children().length > 0) {
                    $(tBody).append(row);
                }

                // append inner grid here as inner table on a separate row
                if (innerGridData !== null) {
                    innerGridCell = $('<td>').attr('colspan', columnsNames.length);

                    innerGrid = $('<table>');
                    appendGridHeader(innerGrid, extractColumnsNames(innerGridData[0]));
                    appendGridBody(innerGrid, innerGridData);

                    $(innerGridCell).append(innerGrid);
                    $(tBody).append($('<tr>').append(innerGridCell));
                }
            }

            $(grid).append(tBody);

            return grid;
        }
    }

    function createStudent(firstName, lastName, grade, subjects) {
        return {
            'First name': firstName,
            'Last name': lastName,
            'Grade': grade,
            'Subjects': subjects
        }
    }

    function createSubject(name, weekHours) {
        return {
            'Name': name,
            'Week hours': weekHours
        }
    }
});