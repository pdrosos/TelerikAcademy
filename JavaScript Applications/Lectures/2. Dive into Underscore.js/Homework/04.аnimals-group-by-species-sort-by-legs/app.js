/// <reference path="../libs/jquery.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/underscore.js" />
(function () {
    "use strict";
    require.config({
        paths: {
            "jquery": "../libs/jquery",
            "underscore": "../libs/underscore",
            "animal": "animal"
        }
    });

    require(["jquery", "underscore", "animal"], function ($, _, Animal) {

        var $animalsInitial = $("<div></div>"),
            $animalsInitialHeading = $("<h2></h2>").html("All animals (initial):"),
            $animalsGroupedAndSorted = $("<div></div>"),
            $animalsGroupedAndSortedHeading = $("<h2></h2>").html("Animals (grouped and sorted):"),
            animals;

            $animalsInitial.append($animalsInitialHeading);
            $animalsGroupedAndSorted.append($animalsGroupedAndSortedHeading);

            animals = [
                new Animal("Cat", "Felis catus", 4),
                new Animal("Dog", "Canis lupus familiaris", 4),
                new Animal("Brown trout", "Salmo trutta", 0),
                new Animal("Giraffe", "Giraffa camelopardalis", 4),
                new Animal("Rock dove", "Columba livia", 2),
                new Animal("Brown centipede", "Lithobius forficatus", 100),
                new Animal("African forest elephant", "Loxodonta cyclotis", 4),
                new Animal("European crayfish", "Astacus astacus", 10),
                new Animal("House sparrow", "Passer domesticus", 2),
                new Animal("Cat", "Felis catus", 4),
                new Animal("Rock dove", "Columba livia", 2),
                new Animal("African forest elephant", "Loxodonta cyclotis", 4),
                new Animal("European crayfish", "Astacus astacus", 10),
                new Animal("Dog", "Canis lupus familiaris", 4),
                new Animal("Giraffe", "Giraffa camelopardalis", 4),
                new Animal("House sparrow", "Passer domesticus", 2),
                new Animal("Rock dove", "Columba livia", 2),
            ];

        for (var i = 0; i < animals.length; i++) {
            $("<p></p>")
                .html(animals[i].toString())
                .appendTo($animalsInitial);
        }

        $("body").append($animalsInitial);

        var animalsGroupedBySpecies = _.groupBy(animals, "species");
        var animalsGroupedBySpeciesSortedByLegs = _.sortBy(animalsGroupedBySpecies, function (animal) {
            return animal[0].legs;
        });

        appendGroupedAndSortedAnimalsTo($animalsGroupedAndSorted);
        $("body").append($animalsGroupedAndSorted);

        function appendGroupedAndSortedAnimalsTo(element) {
            var len = animalsGroupedBySpeciesSortedByLegs.length;

            for (var i = 0; i < len; i++) {

                var speciesCount = animalsGroupedBySpeciesSortedByLegs[i].length;
                for (var j = 0; j < speciesCount; j++) {
                    var animal = animalsGroupedBySpeciesSortedByLegs[i][j];
                    $("<p></p>")
                        .html(animal.toString())
                        .appendTo(element);
                }
            }
        }
    });
}());