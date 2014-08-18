/// <reference path="../libs/jquery.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/underscore.js" />
(function () {
    "use strict";
    require.config({
        paths: {
            "jquery": "../libs/jquery",
            "underscore": "../libs/underscore",
            "book": "book"
        }
    });

    require(["jquery", "underscore", "book"], function ($, _, Book) {

        var $booksContainer = $("<div></div>"),
            $booksHeading = $("<h2></h2>").html("Books List:"),
            $mostPopularAuthorContainer = $("<div></div>"),
            $mostPopularAuthorHeading = $("<h2></h2>").html("Most popular author:"),
            $mostPopularAuthor = $("<p></p>"),
            books;

            books = [
                new Book("Rita Hayworth and Shawshank Redemption", "Stephen King", "978-0-670-27266-2"),
                new Book("The Da Vinci Code", "Dan Brown", "0-385-50420-9"),
                new Book("And Then There Were None", "Agatha Christie", "978-0-00-713683-4"),
                new Book("The Universe in a Nutshell", "Stephen Hawking", "0-553-80202-X"),
                new Book("The Murder of Roger Ackroyd", "Agatha Christie", "0-00-725061-4"),
                new Book("The Green Mile", "Stephen King", "978-0451190499"),
                new Book("Singularity Sky", "Charles Stross", "0-441-01072-5"),
                new Book("Nineteen Eighty-Four", "George Orwell", "978-0-14-118776-1"),
                new Book("Neuromancer", "William Gibson", "0-441-56956-0"),
                new Book("Digital Fortress", "Dan Brown", "0-312-18087-X"),
                new Book("Prey", "Michael Crichton", "0-00-715379-1"),
                new Book("Accelerando", "Charles Stross", "0-441-01284-1"),
                new Book("The Time Machine", "H. G. Wells", "N/A"),
                new Book("The Invisible Man","H. G. Wells", "N/A" ),
                new Book("The War of the Worlds","H. G. Wells", "N/A"),
                new Book("The First Men in the Moon","H. G. Wells", "N/A"),
                new Book("Space Odyssey","Arthur C. Clarke", "N/A" ),
                new Book("Rendezvous with Rama","Arthur C. Clarke", "0-575-01587-X"),
                new Book("Next","Michael Crichton", "0-06-087298-5"),
                new Book("Foundation series","Isaac Asimov", "0-385-23313-2")
            ];

            $booksContainer.append($booksHeading);
            addToContainer(books, $booksContainer);
            $("body").append($booksContainer);

            var booksGroupedByAuthor = _.groupBy(books, "author");
            var booksSortedByAuthorCount = _.sortBy(booksGroupedByAuthor, function(book) {
                return book.length;
            }).reverse();

            $mostPopularAuthorContainer.append($mostPopularAuthorHeading);

            $mostPopularAuthor.html(booksSortedByAuthorCount[0][0].author 
                + ", Number of books: " + booksSortedByAuthorCount[0].length);

            $mostPopularAuthorContainer.append($mostPopularAuthor);
            $("body").append($mostPopularAuthorContainer);

            function addToContainer(books, container) {
                for (var i = 0; i < books.length; i++) {
                    $("<p></p>").html(books[i].toString()).appendTo(container);
                }
            }
    });
}());