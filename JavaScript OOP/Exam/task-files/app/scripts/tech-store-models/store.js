define(['tech-store-models/item'], function (Item) {
    var Store = (function () {
        // Private constants
        var MIN_ITEM_LENGTH = 6,
            MAX_ITEM_LENGTH = 30;

        // Validate methods
        function isValidName(itemName) {
            var nameLength = itemName.length,
                isValid = false;

            if (MIN_ITEM_LENGTH <= nameLength && nameLength <= MAX_ITEM_LENGTH) {
                isValid = true;
            }

            return isValid;
        }

        function isItem(item) {
            var isValid = false;

            if (item instanceof Item) {
                isValid = true;
            }

            return isValid;
        }

        function isValidType(type) {
            var prop,
                hasType = false;

            for (prop in Item.types) {
                if (Item.types[prop] === type) {
                    hasType = true;
                    break;
                }
            }

            return hasType;
        }

        function validateOptions(options) {
            options = options || {};
            options.min = options.min ? options.min : 0;
            options.max = options.max || Number.MAX_VALUE;

            return options;
        }

        // Sort methods
        function sortByName (item1, item2) {
            return item1['name'].localeCompare(item2['name']);
        }

        function sortByPrice (item1, item2) {
            return item1['price'] - item2['price'];
        }

        function sortItems(sortBy) {
            var sortedItems = this.slice(0);

            sortedItems.sort(sortBy);

            return sortedItems;
        }

        // Select elements methods
        function getAllItemsOfType() {
            var itemsOfType = [],
                itemsLength,
                i,
                j,
                types = arguments;

            for (i = 0, itemsLength = this._items.length; i < itemsLength; i += 1) {
                for (j in types) {
                    if (this._items[i].type === types[j]) {
                        itemsOfType.push(this._items.slice(i, i + 1)[0]);
                    }
                }
            }

            return itemsOfType;
        }

        function isInRange(range) {
            var isValid = false;

            if (range.min <= this.price && this.price <= range.max) {
                isValid = true;
            }

            return isValid;
        }

        // Constructor
        function Store(name) {
            if (!isValidName(name)) {
                throw  new TypeError("Item's name should be between " + MIN_ITEM_LENGTH + " and " + MAX_ITEM_LENGTH + " !");
            }

            this._items = [];

            return this;
        }

        // Methods
        Store.prototype.addItem = function (item) {
            if (!isItem(item)) {
                throw new TypeError('Invalid item argument!');
            }

            this._items.push(item);

            return this;
        };

        Store.prototype.getAll = function () {
            return sortItems.call(this._items, sortByName);
        };

        Store.prototype.getSmartPhones = function () {
            var smartPhones = getAllItemsOfType.call(this, Item.types['smart-phone']);
            return sortItems.call(smartPhones, sortByName);
        };

        Store.prototype.getMobiles = function () {
            var mobiles = getAllItemsOfType.call(this, Item.types['smart-phone'], Item.types['tablet']);
            return sortItems.call(mobiles, sortByName);
        };

        Store.prototype.getComputers = function () {
            var computers = getAllItemsOfType.call(this, Item.types['pc'], Item.types['notebook']);
            return sortItems.call(computers, sortByName);
        };

        Store.prototype.filterItemsByType = function (filterType) {
            var filtered;

            if (!isValidType(filterType)) {
                throw new TypeError(filterType + ' is not a valid type!');
            }

            filtered = getAllItemsOfType.call(this, Item.types[filterType]);
            return sortItems.call(filtered, sortByName);
        };

        Store.prototype.filterItemsByPrice = function (options) {
            var elementsInRange = [],
                i,
                length;

             options = validateOptions(options);

            for (i = 0, length = this._items.length; i < length; i += 1) {

                if (isInRange.call(this._items[i], options)) {
                    elementsInRange.push(this._items.slice(i, i + 1)[0]);
                }
            }

            return sortItems.call(elementsInRange, sortByPrice);
        };

        Store.prototype.countItemsByType = function () {
            var typesCount = [],
                i,
                itemsFromType;

            for (i in Item.types) {
                itemsFromType = getAllItemsOfType.call(this, Item.types[i]);

                if (itemsFromType.length !== 0) {
                    typesCount[Item.types[i]] = itemsFromType.length;
                }
            }

            return typesCount;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var filteredItems = [],
                i,
                length,
                indexOfPart;

            for (i = 0, length = this._items.length; i < length; i += 1) {
                indexOfPart = this._items[i].name.toLowerCase().indexOf(partOfName.toLowerCase());

                if (indexOfPart >= 0) {
                    filteredItems.push(this._items.slice(i, i + 1)[0]);
                }
            }

            return sortItems.call(filteredItems, sortByName);
        };


        return Store;
    }());

    return Store;
});
