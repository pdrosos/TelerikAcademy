var Line = (function () {
    function Line(startPointX, startPointY, endPointX, endPointY) {
        Shape.call(this, startPointX, startPointY);
        this.endPointX = endPointX;
        this.endPointY = endPointY;
    }

    Line.prototype = new Shape();

    Line.prototype.constructor = Line;

    Line.prototype.draw = function (canvasId, lineWidth, strokeStyle) {
        Shape.prototype.draw.call(this, canvasId, lineWidth, strokeStyle);
        this.canvasContext.moveTo(this.startPointX, this.startPointY);
        this.canvasContext.lineTo(this.endPointX, this.endPointY);
        this.canvasContext.stroke();
    };

    return Line;
}());