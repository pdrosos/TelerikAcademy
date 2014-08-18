define(function () {
    var Person; 
    
    Person = (function() {
        
        function Person(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        Person.prototype.toString = function() {
            return this.firstName + " " + this.lastName;
        }
        return Person;
    })();

    return Person;
});