(function () {
    var booksListItems,
        studentsListItems;

    booksListItems = {
        books: [
            { id: 1, title: 'JavaScript: The good parts'},
            { id: 2, title: 'Secrets of the JavaScript Ninja'},
            { id: 3, title: 'Core HTML5 Canvas: Graphics, Animation, and Game Development'},
            { id: 4, title: 'JavaScript Patterns'}
        ]
    };

    studentsListItems = {
        students: [
            { name: 'Petar Petrov', mark: 5.5 },
            { name: 'Stamat Georgiev', mark: 4.7 },
            { name: 'Maria Todorova', mark: 6 },
            { name: 'Georgi Geshov', mark: 3.7 },
            { name: 'Anna Hristova', mark: 4 }
        ]
    };

    $('#books-list').listView(booksListItems);
    $('#students-table-body').listView(studentsListItems);
    $('#div-students-table').listView(studentsListItems);
}());