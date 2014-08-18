define(function () {
    var Animal; 
    
    Animal = (function() {
        
        function Animal(popularName, species, legs) {
            this.popularName = popularName;
            this.species = species;
            this.legs = legs;
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