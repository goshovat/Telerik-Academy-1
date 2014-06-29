var CanvasModule = (function (){
    var Drawer = (function () {
        var canvas,
            context,
            DEFAULT_STROKE_COLOR = 'black',
            DEFAULT_FILL_COLOR = 'none';

        function resetCanvasStyles() {
            context.fillStyle = DEFAULT_FILL_COLOR;
            context.strokeStyle = DEFAULT_STROKE_COLOR;
        }

        function CanvasDrawer() {
            canvas = document.getElementById('canvas');
            context = canvas.getContext("2d");
        }

        CanvasDrawer.prototype = {
            rect: function (position, size, strokeColor, fillColor, strokeWidth) {
                fillColor = fillColor || false;
                strokeColor = strokeColor || DEFAULT_STROKE_COLOR;
                strokeWidth = strokeWidth || 1;

                context.beginPath();
                context.fillStyle = fillColor;
                context.strokeStyle = strokeColor;
                context.lineWidth = strokeWidth;
                context.rect(position.x, position.y, size.width, size.height);

                if (fillColor) {
                    context.fill();
                }

                context.stroke();

                resetCanvasStyles();
            },
            circle: function(position, radius, strokeColor, fillColor, strokeWidth) {
                fillColor = fillColor || false;
                strokeColor = strokeColor || DEFAULT_STROKE_COLOR;
                strokeWidth = strokeWidth || 1;

                context.beginPath();
                context.fillStyle = fillColor;
                context.strokeStyle = strokeColor;
                context.lineWidth = strokeWidth;
                context.arc(position.x, position.y, radius, 0, 2 * Math.PI);

                if (fillColor) {
                    context.fill();
                }

                context.stroke();

                resetCanvasStyles();
            },
            line: function(startPosition, endPosition, strokeColor, strokeWidth) {
                strokeColor = strokeColor || DEFAULT_STROKE_COLOR;
                strokeWidth = strokeWidth || 1;

                context.beginPath();
                context.strokeStyle = strokeColor;
                context.lineWidth = strokeWidth;
                context.moveTo(startPosition.x, startPosition.y);
                context.lineTo(endPosition.x, endPosition.y);
                context.stroke();

                resetCanvasStyles();
            }
        };

        return CanvasDrawer;
    }());

    var Point = (function (){
        this.x;
        this.y;

        function Point(x, y) {
            this.x = x;
            this.y = y;
        }

        return Point;
    }());

    var Size = (function (){
        this.width;
        this.height;

        function Size(width, height) {
            this.width = width;
            this.height = height;
        }

        return Size;
    }());

    return {
        Drawer: Drawer,
        Point: Point,
        Size: Size
    };
}());