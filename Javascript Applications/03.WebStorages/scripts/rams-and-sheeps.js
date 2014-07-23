(function () {
    var number,
        button,
        buttonAddScore,
        buttonPlayAgain,
        rams = 0,
        sheeps = 0,
        score = 0;

    function getRandomDigit(min, max, array) {
        var digit,
            i,
            isNotDifferent = true;

        while (isNotDifferent) {
            digit = Math.floor(Math.random() * (max - min + 1)) + min;
            isNotDifferent = false;

            if (array) {
                for (i = 0; i < array.length; i += 1) {
                    if (digit === array[i]) {
                        isNotDifferent = true;
                        break;
                    }
                }
            }
        }

        return digit;
    }

    function generateNumber() {
        var number = '',
            digits = [],
            digit,
            i;

        digit = getRandomDigit(1, 9);
        digits.push(digit);
        number += digit;

        for (i = 0; i < 3; i++) {
            digit = getRandomDigit(0, 9, digits);
            digits.push(digit);
            number += digit;
        }

        return number;
    }

    function checkForEqualDigits(number) {
        var i,
            j,
            len;

        for (i = 0, len = number.length; i < len - 1; i += 1) {
            for (j = i + 1; j < len; j += 1) {
                if (number[i] === number[j]) {
                    return true;
                }
            }
        }

        return false;
    }

    function calculateRams(checker) {
        var i,
            len;

        for (i = 0, len = number.length; i < len; i += 1) {
            if (number[i] === checker[i]) {
                rams++;
            }
        }
    }

    function calculateSheeps(checker) {
        var i,
            j,
            len;

        for (i = 0, len = number.length; i < len; i += 1) {
            for (j = 0; j < len; j += 1) {
                if (i != j && number[i] === checker[j]) {
                    sheeps++;
                }
            }
        }
    }

    function showRams() {
        var ramImages = document.querySelectorAll('#result .ram'),
            i;

        for (i = 0; i < ramImages.length; i += 1) {
            ramImages[i].className = "ram invisible";
        }

        for (i = 0; i < rams; i += 1) {
            ramImages[i].className = 'ram';
        }
    }

    function showSheeps() {
        var sheepImages = document.querySelectorAll('#result .sheep'),
            i;

        for (i = 0; i < sheepImages.length; i += 1) {
            sheepImages[i].className = "sheep invisible";
        }

        for (i = 0; i < sheeps; i += 1) {
            sheepImages[i].className = 'sheep';
        }
    }

    function showAnswers() {
        var answerImages = document.querySelectorAll('#game .question'),
            i,
            guessedDigits = rams + sheeps;

        for (i = 0; i < guessedDigits; i += 1) {
            answerImages[i].src = 'images/answer.png';
        }

        for (i = guessedDigits; i < answerImages.length; i += 1) {
            answerImages[i].src = 'images/question.png';
        }
    }

    function compareNumbers() {
        var numberFromInput = document.getElementById('inputed-number').value;

        if (!numberFromInput || numberFromInput != parseInt(numberFromInput, 10)) {
            alert('You must enter a number!');
        } else if (numberFromInput.length !== 4) {
            alert('You must enter a number between 1000 and 9999!');
        } else if (checkForEqualDigits(numberFromInput)) {
            alert('You must enter a number with different digits!');
        } else {
            rams = 0;
            sheeps = 0;

            calculateRams(numberFromInput);
            calculateSheeps(numberFromInput);

            score += rams + sheeps;

            document.getElementById('points').textContent = score.toString();

            showRams();
            showSheeps();
            showAnswers();

            if (rams === 4) {
                document.getElementById('game-finish').className = '';
            }
        }
    }

    function fillScoreBoard(scoreboard) {
        var scoreBoardContainer = document.getElementById('score-board'),
            i,
            span = document.createElement('span'),
            br = document.createElement('br'),
            clonedBr,
            clonedSpan,
            scores = document.getElementById('scores');

        scores.innerHTML = '';
        scoreBoardContainer.className = '';

        for (i=0; i < scoreboard.length; i += 1) {
            clonedSpan = span.cloneNode(true);
            clonedBr = br.cloneNode(true);
            clonedSpan.textContent = (i + 1) + '. ' + scoreboard[i].name + ' - '
            + scoreboard[i].score + ' points';
            scores.appendChild(clonedSpan);
            scores.appendChild(clonedBr);
        }
    }

    function addScore() {
        var nickname = document.getElementById('nickname').value;
        var scoreboard = localStorage.getObject("scoreboard");
        var player = {
            name: nickname,
            score: score
        };
        var i;
        var isHighScore = false;

        if (!scoreboard) {
            localStorage.setObject("scoreboard", []);
        }

        scoreboard = localStorage.getObject("scoreboard");

        for (i = 0; i < scoreboard.length; i += 1) {
            if(player.score < scoreboard[i].score) {
                scoreboard.splice(i, 0, player);
                isHighScore = true;
                break;
            }
        }

        if (!isHighScore) {
            scoreboard.push(player);
        }

        localStorage.setObject('scoreboard', scoreboard);
        document.getElementById('game-finish').className = 'invisible';
        fillScoreBoard(scoreboard);
    }

    function startNewGame() {
        score = 0;
        rams = 0;
        sheeps = 0;
        generateNumber();
        showRams();
        showSheeps();
        showAnswers();

        document.getElementById('nickname').value = '';
        document.getElementById('inputed-number').value = '';
        document.getElementById('score-board').className = 'invisible';
    }

    number = generateNumber();

    button = document.getElementById('check');
    button.addEventListener('click', compareNumbers);

    buttonAddScore = document.getElementById('add-score');
    buttonAddScore.addEventListener('click', addScore);

    buttonPlayAgain = document.getElementById('play-again');
    buttonPlayAgain.addEventListener('click', startNewGame);
}());