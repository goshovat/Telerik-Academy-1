var snakeGame;

document.getElementById('start-button').addEventListener('click', function(e){
    if (snakeGame) {
        snakeGame.stop();
    }

    snakeGame = new game.SnakeGame();
    snakeGame.start();
});