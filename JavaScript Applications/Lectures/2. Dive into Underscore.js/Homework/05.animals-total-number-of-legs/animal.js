define(function () {
    var Animal; 
    
    Animal = (function() {
        
        function Animal(popularName, species, legs) {
            this.popularName = popularName;
            this.species = species;
            this.legs = validateLegsNumber(legs);
        }

        function validateLegsNumber(legsNumber) {
            var legsEnum = {
                "2": 2,
                "4": 4,
                "6": 6, 
                "8": 8, 
                "10": 10
            },
                islegsNumberCorrect = false,
                i,
                len;

            for (var prop in legsEnum) {
                if (legsNumber.toString() === prop) {
                    return legsNumber;
                }
            }
            if (!islegsNumberCorrect) {
                throw new TypeError("The legs number is incorrect!");
            }
        }

        Animal.prototype.toString = function() {
            var animalString = "";
            animalString += 
                "Popular name: " + this.popularName 
                + " , Species: " + this.species 
                + " , Legs: " + this.legs;

            return animalString; 
        }
        return Animal;
    })();

    return Animal;
});