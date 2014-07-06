var food = (function () {

    var Apple = (function () {
        function Apple(foodSize, x, y) {
            this.hasFood = false;
            this.x = x;
            this.y = y;
            this.size = foodSize;
        }

        Apple.prototype.generateFood = function (width, height, snakePath) {
            var index,
                unique = true;

            if (!this.hasFood) {
                this.hasFood = true;

                while (true) {
                    this.x = parseInt(Math.floor(Math.random() * width), 10) / this.size;
                    this.x = Math.floor(this.x) * this.size;
                    this.y = parseInt(Math.floor(Math.random() * height), 10) / this.size;
                    this.y = Math.floor(this.y) * this.size;

                    for (index in snakePath) {
                        if (this.x === snakePath[index][0] && this.y === snakePath[index][1]) {
                            unique = false;
                            break;
                        }
                    }

                    if (unique) {
                        break;
                    }
                    else {
                        unique = true;
                    }
                }
            }
        }

        return Apple;
    }());

    return {
        Apple: Apple
    };

}());

