var game = (function () {
    var SnakeGame = (function () {
        var SIZE = 10,
            refreshIntervalId,
            canvas,
            context,
            width,
            height,
            highScore,
            currentScore,
            redrawMilliseconds,
            snake,
            apple;

        function handleKey(e) {
            e = e || event;
            switch (e.keyCode) {
                case 37:
                    if (snake.directionX === 0) {
                        snake.directionX = -snake.size;
                        snake.directionY = 0;
                    }

                    break;
                case 38:
                    if (snake.directionY === 0) {
                        snake.directionX = 0;
                        snake.directionY = -snake.size;
                    }

                    break;
                case 39:
                    if (snake.directionX === 0) {
                        snake.directionX = snake.size;
                        snake.directionY = 0;
                    }

                    break;
                case 40:
                    if (snake.directionY === 0) {
                        snake.directionX = 0;
                        snake.directionY = snake.size;
                    }

                    break;
            }
        };

        function checkForEndOfTheGame() {
            // Check for end
            if (snake.snakeWidth === (width / snake.size) * (height / snake.size)) {
                alert('You win!');
                clearInterval(refreshIntervalId);
                return true;
            }
        }


        function checkCollision() {
            // Food collision
            var index;

            if (snake.x === apple.x && snake.y === apple.y) {
                currentScore += 5;
                snake.x += snake.directionX;
                snake.y += snake.directionY;
                snake.snakePath.unshift([snake.x, snake.y]);
                snake.gotFoodX = apple.x;
                snake.gotFoodY = apple.y;
                snake.gotFood = true;
                apple.hasFood = false;
            }

            // Wall collision
            if (snake.x < 0 || snake.x + snake.size > width) {
                alert('Game over! You hit a wall.');
                clearInterval(refreshIntervalId);
                return true;
            }

            if (snake.y < 0 || snake.y + snake.size > height) {
                alert('Game over! You hit a wall.');
                clearInterval(refreshIntervalId);
                return true;
            }

            // Self collision
            for (index = 1; index < snake.snakePath.length; index += 1) {
                if (snake.x === snake.snakePath[index][0] && snake.y === snake.snakePath[index][1]) {
                    alert('Game over! You bite yourself.');
                    clearInterval(refreshIntervalId);
                    return true;
                }
            }
        }

        function update() {
            if (!(checkForEndOfTheGame() || checkCollision()))
            {
				snake.move();
				apple.generateFood(width, height, snake.snakePath);
                paint();
            }}


        function paint() {
            var tail = snake.snakePath.pop(),
                path;

            highScore = parseInt(document.getElementById('high-score').innerText, 10);

            if (highScore < currentScore) {
                highScore = currentScore;
            }

            document.getElementById('high-score').innerText = highScore.toString();
            document.getElementById('score').innerText = currentScore.toString();

            context.fillStyle = '#3A4719';
            context.fillRect(tail[0], tail[1], snake.size, snake.size);

            if (snake.gotFood) {
                context.fillStyle = '#3A4719';
                context.beginPath();
                context.rect( snake.gotFoodX,  snake.gotFoodY,  apple.size, apple.size);
                context.fill();
                snake.gotFood = false;
            }

            context.fillStyle = 'red';
            context.beginPath();
            context.rect(apple.x, apple.y, apple.size, apple.size);
            context.fill();

            for (path in snake.snakePath) {
                context.fillStyle = '#B0D101';
                context.beginPath();
                context.rect(snake.snakePath[path][0], snake.snakePath[path][1], snake.size, snake.size);
                context.fill();
            }

        }

        function SnakeGame() {
            canvas = document.getElementById('the-canvas');
            context = canvas.getContext('2d');
            width = canvas.width;
            height = canvas.height;
            highScore = parseInt(document.getElementById('high-score').innerText, 10);
            currentScore = 0;
            redrawMilliseconds = 100;
            context.fillStyle = '#3A4719';
            context.fillRect(0, 0, width, height);
            snake = new hero.Snake(SIZE);
            apple = new food.Apple(SIZE);
            document.onkeydown = handleKey;
        }

        SnakeGame.prototype.start = function() {
            context.fillStyle = '#3A4719';
            context.fillRect(0, 0, width, height);
            snake.snakePath = [];
            snake.snakePath.push([0, 0]);
            snake.directionX = snake.size;
            snake.directionY = 0;
            currentScore = 0;
            snake.hasFood = false;

            refreshIntervalId = setInterval(update, redrawMilliseconds);
        }

        SnakeGame.prototype.stop = function() {
            clearInterval(refreshIntervalId);
        }

        return SnakeGame;
    }());


    return {
        SnakeGame: SnakeGame
    };
}());