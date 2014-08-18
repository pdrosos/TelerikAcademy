define(function() {
    'use strict';

    var Item;
    Item = (function() {
        function Item(type, name, price) {
            this._allowedTypes = [
                'accessory',
                'smart-phone',
                'notebook',
                'pc',
                'tablet'
            ];

            this._nameMinLength = 6;
            this._nameMaxLength = 40; // 30 was corrected to 40 by Ivo Kenov

            if (this._allowedTypes.indexOf(type) == -1) {
                throw {
                    message: type + ' is not a valid type'
                };
            }

            this.type = type;

            // check if name is valid
            if (typeof name != 'string') {
                throw {
                    message: name + ' is not a valid string'
                };
            }

            if (name.length < this._nameMinLength || name.length > this._nameMaxLength) {
                throw {
                    message: name + ' must be between ' + this._nameMinLength + ' and ' + this._nameMaxLength + 'characters'
                };
            }

            this.name = name;

            // check if price is valid
            if (!isNumeric(price)) {
                throw {
                    message: price + ' is not a valid number'
                };
            }

            this.price = price;
        }

        function isNumeric(number) {
            return !isNaN(parseFloat(number)) && isFinite(number);
        }

        return Item;
    }());

    return Item;
});