define(['tech-store-models/item'], function(Item) {
    'use strict';

    var Store;
    Store = (function() {
        /**
         * Create a new store
         *
         * @param name
         * @constructor
         */
        function Store(name) {
            // check if name is valid
            if (typeof name != 'string') {
                throw {
                    message: name + ' is not a valid string'
                };
            }

            if (name.length < this.nameMinLength || name.length > this.nameMaxLength) {
                throw {
                    message: name + ' must be between ' + this.nameMinLength + ' and ' + this.nameMaxLength + 'characters'
                };
            }

            this._name = name;

            this._items = [];
        }

        Store.prototype.nameMinLength = 6;
        Store.prototype.nameMaxLength = 30;

        /**
         * Add item
         *
         * @param item
         * @returns {Store}
         */
        Store.prototype.addItem = function(item) {
            if(!(item instanceof Item)){
                throw {
                    message: item + ' is not a valid item'
                };
            }

            this._items.push(item);

            return this;
        };

        /**
         * Get all items
         *
         * {Array}
         */
        Store.prototype.getAll = function() {
            this._items.sort(sortItemsAlphabeticallyCallback);

            return this._items.slice(0);
        };

        /**
         * Get smart phones
         *
         * @returns {Array}
         */
        Store.prototype.getSmartPhones = function() {
            var smartPhones = [];

            this._items.forEach(function(item) {
                if (item.type === 'smart-phone') {
                    smartPhones.push(item);
                }
            });

            smartPhones.sort(sortItemsAlphabeticallyCallback)

            return smartPhones.slice(0);
        };

        /**
         * Get mobiles
         *
         * @returns {Array}
         */
        Store.prototype.getMobiles = function() {
            var mobiles = [];

            this._items.forEach(function(item) {
                if (item.type === 'smart-phone' || item.type === 'tablet') {
                    mobiles.push(item);
                }
            });

            mobiles.sort(sortItemsAlphabeticallyCallback);

            return mobiles.slice(0);
        };

        /**
         * Get computers
         *
         * @returns {Array}
         */
        Store.prototype.getComputers = function() {
            var computers = [];

            this._items.forEach(function(item) {
                if (item.type === 'pc' || item.type === 'notebook') {
                    computers.push(item);
                }
            });

            computers.sort(sortItemsAlphabeticallyCallback);

            return computers.slice(0);
        };

        /**
         * Filter items by type
         *
         * @param filterTypeKey
         * @returns {Array}
         */
        Store.prototype.filterItemsByType = function(filterTypeKey) {
            var items = [];

            this._items.forEach(function(item) {
                if (item.type === filterTypeKey) {
                    items.push(item);
                }
            });

            items.sort(sortItemsAlphabeticallyCallback);

            return items.slice(0);
        };

        /**
         * Filter items by name
         *
         * @param partOfName
         * @returns {Array}
         */
        Store.prototype.filterItemsByName = function(partOfName) {
            var items = [],
                name;

            partOfName = partOfName.toLowerCase();

            this._items.forEach(function(item) {
                name = item.name.toLowerCase();

                if (name.indexOf(partOfName) > -1) {
                    items.push(item);
                }
            });

            items.sort(sortItemsAlphabeticallyCallback);

            return items.slice(0);
        };

        /**
         * Filter items by price
         *
         * @param options
         * @returns {Array}
         */
        Store.prototype.filterItemsByPrice = function(options) {
            var items = [],
                minPrice = 0,
                maxPrice = Number.MAX_VALUE;

            // if no price options - return all items sorted by price
            if (options === undefined) {
                this._items.sort(sortItemsByPriceCallback);

                return this._items.slice(0);
            }

            if (options.hasOwnProperty('min')) {
                minPrice = options.min;
            }

            if (options.hasOwnProperty('max')) {
                maxPrice = options.max;
            }

            this._items.forEach(function(item) {
                if (item.price >= minPrice && item.price <= maxPrice) {
                    items.push(item);
                }
            });

            items.sort(sortItemsByPriceCallback);

            return items.slice(0);
        };

        /**
         * Items count by type
         *
         * @returns {{}}
         */
        Store.prototype.countItemsByType = function() {
            var itemsByTypeCount = {};

            this._items.forEach(function(item) {
                if (itemsByTypeCount.hasOwnProperty(item.type)) {
                    itemsByTypeCount[item.type] += 1;
                } else {
                    itemsByTypeCount[item.type] = 1;
                }
            });

            return itemsByTypeCount;
        };

        /**
         * Sort items by name (case insensitive)
         *
         * @param first
         * @param second
         * @returns {number}
         */
        function sortItemsAlphabeticallyCallback(first, second) {
            // changing the case (to upper or lower) ensures a case insensitive sort
            var firstName = first.name.toUpperCase();
            var secondName = second.name.toUpperCase();

            return (firstName < secondName) ? -1 : (firstName > secondName) ? 1 : 0;
        }

        /**
         * Sort items by price
         *
         * @param first
         * @param second
         * @returns {number}
         */
        function sortItemsByPriceCallback(first, second) {
            return first.price - second.price;
        }

        return Store;
    }());

    return Store;
});