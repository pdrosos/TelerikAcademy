/// <reference path="../libs/jquery.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/underscore.js" />
(function () {
    "use strict";
    require.config({
        paths: {
            "jquery": "../libs/jquery",
            "underscore": "../libs/underscore",
            "person": "person"
        }
    });

    require(["jquery", "underscore", "person"], function ($, _, Person) {

        var $peopleContainer = $("<div></div>"),
            $peopleHeading = $("<h2></h2>").html("People List:"),
            $mostUsedNamesHeading = $("<h2></h2>").html("Most used names:"),
            people;

            people = [
                new Person("Ivan", "Petrov"),
                new Person("Dimitar", "Hristov"),
                new Person("Maria", "Grebkova"),
                new Person("Veselin", "Chernev"),
                new Person("Petya", "Ivanova"),
                new Person("Dimitar", "Petrov"),
                new Person("Danail", "Vassilev"),
                new Person("Petur", "Vladimirov"),
                new Person("Venko", "Petrov"),
                new Person("Dimitar", "Ivanov")
            ];

            $peopleContainer.append($peopleHeading);
            addToContainer(people, $peopleContainer);
            $("body").append($peopleContainer);

            // var peopleGroupedByFirstName = _.groupBy(people, "firstName");

            var mostCommonFirstName =  _.chain(people)
                .groupBy("firstName")
                .sortBy(function(personsList) {
                    return personsList.length;
                })
                .last()
                .last()
                .value().firstName;


            var mostCommonLastName =  _.chain(people)
                .groupBy("lastName")
                .sortBy(function(personsList) {
                    return personsList.length;
                })
                .last()
                .last()
                .value().lastName;
                
            $("body").append($mostUsedNamesHeading);
            $("body").append($("<p></p>")
                        .html("Most common first name: " 
                                + mostCommonFirstName + " <br />"
                                + "Most common last name: "
                                + mostCommonLastName));

            function addToContainer(Persons, container) {
                for (var i = 0; i < Persons.length; i++) {
                    $("<p></p>").html(Persons[i].toString()).appendTo(container);
                }
            }
    });
}());