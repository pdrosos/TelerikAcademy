define(['todo-list/section'], function (Section) {
    'use strict';

    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function(section) {
            if(!(section instanceof Section)){
                throw {
                    message: section + ' is not a section'
                };
            }

            this._sections.push(section);

            return this;
        };

        Container.prototype.getData = function() {
           return this._sections.map(function(section) {
               return section.getData();
           });
        };

        return Container;
    }());

    return Container;
});