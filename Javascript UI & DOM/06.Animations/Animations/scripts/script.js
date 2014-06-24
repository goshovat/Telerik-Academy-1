/// <reference path="kinetic-v5.1.0.min.js" />
/*global Kinetic, window*/
(function () {
    var stage = new Kinetic.Stage({
        container: 'the-container',
        width: 600,
        height: 400
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();
    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 150,
            y: 313,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                    205, 415, 22, 34,
                    232, 415, 23, 32,
                    261, 415, 24, 31,
                    289, 415, 25, 31,
                    319, 415, 25, 32,
                    350, 415, 25, 32,
                    381, 416, 23, 33,
                    412, 415, 22, 33,
                    442, 415, 29, 34,
                    206, 455, 18, 34,
                    234, 455, 16, 33,
                    258, 455, 18, 34,
                    289, 455, 16, 35,
                    316, 455, 17, 36,
                    341, 455, 18, 35,
                    363, 455, 22, 33,
                    389, 455, 24, 31,
                    417, 455, 25, 31,
                    202, 493, 26, 31,
                    231, 493, 24, 33,
                    257, 493, 24, 34,
                    287, 493, 24, 34,
                    318, 493, 23, 35,
                    350, 493, 20, 36
                ]
            },
            frameRate: 24,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();
    };

    imageObj.src = "./images/mario-sprite.png";
}());