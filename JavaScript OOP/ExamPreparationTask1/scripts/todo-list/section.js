define(['todo-list/item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._title = title;
            this._items = [];

            return this;
        }

        Section.prototype.add = function(item){
            if (!(item instanceof Item)) {
                throw new TypeError('You must put item.');
            }

            this._items.push(item);

            return this;
        };

        Section.prototype.getData = function () {
            var items = this._items.map(function(item) {
                    return item.getData();
                });

            return {
                title: this._title,
                items: items
            };
        };

        return Section;
    }());
    return Section;
});