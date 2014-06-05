/*global document, setInterval, alert, event, clearInterval*/
var canvas = document.getElementById('the-canvas'),
    context = canvas.getContext('2d'),
    width = canvas.width,
    height = canvas.height,
    directionX = 10,
    directionY = 0,
    highScore = 0,
    currentScore = 0,
    snakeWidth = 1,
    snakePath = [],
    gotFood = false,
    hasFood = false,
    gotFoodX = 0,
    gotFoodY = 0,
    foodX = 0,
    foodY = 0,
    radius = 10,
    redrawMilliseconds = 100;

context.fillStyle = 'black';
context.fillRect(0, 0, width, height);

document.onkeydown = function (e) {
    e = e || event;
    switch (e.keyCode) {
    case 37:
        if (directionX === 0) {
            directionX = -radius;
            directionY = 0;
        }

        break;
    case 38:
        if (directionY === 0) {
            directionX = 0;
            directionY = -radius;
        }

        break;
    case 39:
        if (directionX === 0) {
            directionX = radius;
            directionY = 0;
        }

        break;
    case 40:
        if (directionY === 0) {
            directionX = 0;
            directionY = radius;
        }

        break;
    }
};

function generateFood() {
    var index,
        unique = true;

    if (!hasFood) {
        hasFood = true;

        while (true)
        {
            foodX = parseInt(Math.floor(Math.random() * width), 10) / 10;
            foodX = Math.floor(foodX) * 10;
            foodY = parseInt(Math.floor(Math.random() * height), 10) / 10;
            foodY = Math.floor(foodY) * 10;

            for (index in snakePath) {
                if (foodX === snakePath[index][0] && foodY === snakePath[index][1]) {
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

function paint() {
    var tail = snakePath.pop(),
        path;

    highScore = parseInt(document.getElementById('highScore').innerText, 10);

    if (highScore < currentScore) {
        highScore = currentScore;
    }

    document.getElementById('highScore').innerText = highScore;
    document.getElementById('score').innerText = currentScore;

    context.fillStyle = 'black';
    context.fillRect(tail[0], tail[1], radius, radius);

    if (gotFood) {
        context.fillStyle = 'black';
        context.beginPath();
        context.rect(gotFoodX, gotFoodY, radius, radius);
        context.fill();
        gotFood = false;
    }

    context.fillStyle = 'red';
    context.beginPath();
    context.rect(foodX, foodY, radius, radius);
    context.fill();

    for (path in snakePath) {
        context.fillStyle = 'yellow';
        context.beginPath();
        context.rect(snakePath[path][0], snakePath[path][1], radius, radius);
        context.fill();
    }
   
}

function start() {
    var refreshIntervalId; 
    context.fillStyle = 'black';
    context.fillRect(0, 0, width, height);
    snakePath = [];
    snakePath.push([0, 0]);
    directionX = 10;
    directionY = 0;
    currentScore = 0;
    hasFood = false;

    function move() {
        // Check for end
        if (snakeWidth === (width / radius) * (height / radius)) {
            alert('You win');
            clearInterval(refreshIntervalId);
            return;
        }

        // Food collision
        var positionX = snakePath[0][0],
            positionY = snakePath[0][1],
            index;

        if (positionX === foodX && positionY === foodY) {
            currentScore += 5;
            positionX += directionX;
            positionY += directionY;
            snakePath.unshift([positionX, positionY]);
            gotFoodX = foodX;
            gotFoodY = foodY;
            gotFood = true;
            hasFood = false;
        }

        // Wall collision
        if (positionX < 0 || positionX + radius > width) {
            alert('game over');
            clearInterval(refreshIntervalId);
            return;
        }

        if (positionY < 0 || positionY + radius > height) {
            alert('game over');
            clearInterval(refreshIntervalId);
            return;
        }

        // Self collision
        for (index = 1; index < snakePath.length; index += 1) {
            if (positionX === snakePath[index][0] && positionY === snakePath[index][1]) {
                alert('game over');
                clearInterval(refreshIntervalId);
                return;
            }
        }

        positionX += directionX;
        positionY += directionY;
        snakePath.unshift([positionX, positionY]);
        generateFood();
        paint();
    }

    refreshIntervalId = setInterval(move, redrawMilliseconds);
}
