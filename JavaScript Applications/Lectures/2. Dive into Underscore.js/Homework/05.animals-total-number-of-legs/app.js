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

        var $animalsContainer = $("<div></div>"),
            $animalsHeading = $("<h2></h2>").html("Animals list:"),
            $legsContainer = $("<div></div>"),
            $legsHeading = $("<h2></h2>").html("Total number of legs:"),
            animals,
            legsTotalNumber = 0;

            $animalsContainer.append($animalsHeading);
            $legsContainer.append($legsHeading);

            animals = [
                new Animal("Cat", "Felis catus", 4),
                new Animal("Dog", "Canis lupus familiaris", 4),
                new Animal("European fire ant", "Myrmica rubra", 6),
                new Animal("Giraffe", "Giraffa camelopardalis", 4),
                new Animal("Rock dove", "Columba livia", 2),
                new Animal("Carpenter ant", "Camponotus fellah", 6),
                new Animal("African forest elephant", "Loxodonta cyclotis", 4),
                new Animal("European crayfish", "Astacus astacus", 10),
                new Animal("Mexican red-kneed tarantula", "Brachypelma smithi", 8),
                new Animal("House sparrow", "Passer domesticus", 2),
                new Animal("American lobster", "Homarus americanus", 10)
            ];
            
            $("body").append($animalsContainer);

            addToContainer(animals, $animalsContainer);

            var $totalLegs = $("<p></p>").html(calculateAnimalsTotalLegs(animals));
            $legsContainer.append($totalLegs);

            $("body").append($legsContainer);

            function addToContainer(animals, container) {
                for (var i = 0; i < animals.length; i++) {
                    $("<p></p>").html(animals[i].toString()).appendTo(container);
                }
            }

            function calculateAnimalsTotalLegs(animals) {
                var totalLegsNumber = 0;

                _.each(animals, function (animal) {
                    totalLegsNumber += animal.legs;
                });
                return totalLegsNumber;
            }
    });
}());