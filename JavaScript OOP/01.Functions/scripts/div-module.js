(function(){
    var movingShapes = (function(){
        var self,
            types = ['rect', 'ellipse'],
            rectangularDivTemplate = {
                div: document.createElement('div'),
                startX: 0,
                startY: 0,
                currentX: 0,
                currentY: 0,
                maxMoveStepX: 0,
                maxMoveStepY: 0,
                moveSpeedX: 1,
                moveSpeedY: 0,
                move: moveRectangular
            },
            circularDivTemplate = {
                div: document.createElement('div'),
                x: 0,
                y: 0,
                radius: 0,
                angle: 0,
                move: moveCircular
            };

        function generateRandomColor() {
            var red = (Math.random() * 256) | 0;
            var green = (Math.random() * 256) | 0;
            var blue = (Math.random() * 256) | 0;

            return 'rgb(' + red + ',' + green + ',' + blue + ')';
        }

        function generateRandomNumber(max){
            var number = (Math.random() * max) | 0;
            return number;
        }

        function moveRectangular(item) {
            function moveRectangularPermanently() {
                if (item.moveSpeedX === 1) {
                    if (item.startX + item.maxMoveStepX === item.currentX) {
                        item.moveSpeedX = 0;
                        item.moveSpeedY = 1;
                    }
                } else if (item.moveSpeedY === 1) {
                    if (item.startY + item.maxMoveStepY === item.currentY) {
                        item.moveSpeedX = -1;
                        item.moveSpeedY = 0;
                    }
                } else if (item.moveSpeedX === -1) {
                    if (item.startX === item.currentX) {
                        item.moveSpeedX = 0;
                        item.moveSpeedY = -1;
                    }
                } else if (item.moveSpeedY === -1) {
                    if (item.startY === item.currentY) {
                        item.moveSpeedX = 1;
                        item.moveSpeedY = 0;
                    }
                }

                item.currentX += item.moveSpeedX;
                item.currentY += item.moveSpeedY;

                item.div.style.left = item.currentX + 'px';
                item.div.style.top = item.currentY + 'px';
            }

            setInterval(moveRectangularPermanently, 10);
        }

        function moveCircular(item) {
            function moveCircularPermanently() {
                var posY,
                    posX;

                item.angle += 0.05;
                posY = item.y + item.radius * Math.PI * Math.sin(item.angle);
                posX = item.x + item.radius * Math.PI * Math.cos(item.angle);
                item.div.style.top = posY + 'px';
                item.div.style.left = posX + 'px';
            }

            setInterval(moveCircularPermanently, 10);
        }

        function randomizeCSS(item) {
            item.div.style.backgroundColor = generateRandomColor();
            item.div.style.color = generateRandomColor();
            item.div.style.border = generateRandomNumber(10) + 'px solid ' + generateRandomColor();
            item.div.style.position = 'absolute';
            item.div.style.left = item.startX + 'px';
            item.div.style.top = item.startY + 'px';
            item.div.style.width = generateRandomNumber(90) + 10 + 'px';
            item.div.style.height = generateRandomNumber(90) + 10 + 'px';
            item.div.textContent = 'div';
            return item;
        }

        function randomizeRectangularDiv(item){
            item.startX = generateRandomNumber(600);
            item.startY = generateRandomNumber(600);
            item.currentX = item.startX;
            item.currentY = item.startY;
            item.maxMoveStepX = generateRandomNumber(100) + 10;
            item.maxMoveStepY = generateRandomNumber(100) + 10;

            randomizeCSS(item);
            return item;
        }

        function randomizeCircularDiv(item){
            item.x = generateRandomNumber(600);
            item.y = generateRandomNumber(600);
            item.radius = generateRandomNumber(40) + 10;

            randomizeCSS(item);
            return item;
        }

        function cloneDiv(item) {
            var clonedDiv = {},
                i;

            for (i in item) {
                if (i === 'div') {
                    clonedDiv[i] = item[i].cloneNode(true);
                } else {
                    clonedDiv[i] = item[i];
                }
            }

            return clonedDiv;
        }

        function add(movingType) {
            var div;
            if(movingType === types[0]) {
                div = randomizeRectangularDiv(cloneDiv(rectangularDivTemplate));
            } else if(movingType === types[1]){
                div = randomizeCircularDiv(cloneDiv(circularDivTemplate));
            } else {
                throw {
                    name: 'InvalidMovingTypeError',
                    message: movingType + 'is not a valid moving type'
                }
            }

            document.body.appendChild(div.div);
            div.move(div);
        }


        self = {
            add: add
        };

        return self;
    }());

    function createRectangularDiv() {
        movingShapes.add('rect');
    }

    function createCircularDiv() {
        movingShapes.add('ellipse');
    }

    document.getElementById('rectangular-move').addEventListener('click', createRectangularDiv);
    document.getElementById('circular-move').addEventListener('click', createCircularDiv);

}());