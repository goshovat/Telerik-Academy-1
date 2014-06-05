/*global document, setInterval*/
var canvas = document.getElementById('the-canvas'),
    context = canvas.getContext('2d'),
    width = canvas.width,
    height = canvas.height,
    directionX = 1,
    directionY = 1,
    positionX = 30,
    positionY = 20,
    radius = 10,
    redrawMilliseconds = 5;

function paint() {
    context.fillStyle = 'black';
    context.fillRect(0, 0, width, height);

    context.fillStyle = 'yellow';
    context.beginPath();
    context.arc(positionX, positionY, radius, 0, 2 * Math.PI);
    context.fill();
}

function start() {
    function move() {
        if (positionX + radius === width || positionX - radius === 0) {
            directionX *= -1;
        }

        if (positionY + radius === height || positionY - radius === 0) {
            directionY *= -1;
        }

        positionX += directionX;
        positionY += directionY;
        paint();
    }

    setInterval(move, redrawMilliseconds);

}
start();