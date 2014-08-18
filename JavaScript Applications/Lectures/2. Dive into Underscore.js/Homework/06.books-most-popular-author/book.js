define(function () {
    var Book; 
    
    Book = (function() {
        
        function Book(title, author, ISBN) {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
        }

        Book.prototype.toString = function() {
            var bookString = "";
            bookString += 
                "Title: " + this.title 
                + " , Author: " + this.author 
                + " , ISBN: " + this.ISBN;

            return bookString; 
        }
        return Book;
    })();

    return Book;
});