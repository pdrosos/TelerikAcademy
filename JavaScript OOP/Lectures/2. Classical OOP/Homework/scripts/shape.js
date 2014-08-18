var Shape = (function () {
    var canvas,
        canvasContext;

    function Shape(startPointX, startPointY) {
        this.startPointX = startPointX;
        this.startPointY = startPointY;
    }

    Shape.prototype.draw = function (canvasId, lineWidth, strokeStyle) {
        canvas = document.getElementById(canvasId);
        canvasContext = canvas.getContext("2d");
        this.canvasContext = canvasContext;

        lineWidth = typeof lineWidth !== 'undefined' ? lineWidth : 6;
        strokeStyle = typeof strokeStyle !== 'undefined' ? strokeStyle : 'blue';
    
        this.canvasContext.beginPath();
        this.canvasContext.lineWidth = lineWidth;
        this.canvasContext.strokeStyle = strokeStyle;
    };

    return Shape;
}());