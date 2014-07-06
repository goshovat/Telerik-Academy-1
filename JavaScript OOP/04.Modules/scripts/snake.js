var hero = (function() {

    var Snake = (function () {

        function Snake(snakeSize) {
            this.x = 0;
            this.y = 0;
            this.directionX = snakeSize;
            this.directionY = 0;
            this.snakeWidth = 1;
            this.snakePath = [];
            this.gotFood = false;
            this.gotFoodX = 0;
            this.gotFoodY = 0;
            this.size = snakeSize;
        }

        Snake.prototype.move = function(){
            this.x += this.directionX;
            this.y += this.directionY;
            this.snakePath.unshift([this.x, this.y]);
        };

        return Snake;
    }());


    return {
        Snake: Snake
    };
}());