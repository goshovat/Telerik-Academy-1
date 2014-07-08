define(function () {

    var Item = (function () {
        // Private constants
        var MIN_ITEM_LENGTH = 6,
            MAX_ITEM_LENGTH = 40;

        // Validate methods
        function isValidType(itemType) {
            var prop,
                isType = false;

            for (prop in Item.types) {
                if (Item.types[prop] === itemType) {
                    isType = true;
                    break;
                }
            }

            return isType;
        }

        function isValidName(itemName) {
            var nameLength = itemName.length,
                isValid = false;

            if (MIN_ITEM_LENGTH <= nameLength && nameLength <= MAX_ITEM_LENGTH) {
                isValid = true;
            }

            return isValid;
        }

        function isValidPrice(itemPrice) {
            var parsedPrice = parseFloat(itemPrice),
                isValid = false;

            if (parsedPrice && parsedPrice > 0.0) {
                isValid = true;
            }

            return isValid;
        }

        // Constructor
        function Item(type, name, price) {
            if (!isValidType(type)) {
                throw  new TypeError('Invalid type: ' + type);
            }

            this.type = type;

            if (!isValidName(name)) {
                throw  new TypeError("Item's name should be between " + MIN_ITEM_LENGTH + " and " + MAX_ITEM_LENGTH + " !");
            }

            this.name = name;

            if (!isValidPrice(price)) {
                throw  new TypeError('Price must be a positive floating point number!');
            }

            this.price = price;

            return this;
        }

        // Static property (enumeration)
        Item.types = {
            'accessory': 'accessory',
            'smart-phone': 'smart-phone',
            'notebook': 'notebook',
            'pc': 'pc',
            'tablet': 'tablet'
        };

        return Item;
    }());

    return Item;
});