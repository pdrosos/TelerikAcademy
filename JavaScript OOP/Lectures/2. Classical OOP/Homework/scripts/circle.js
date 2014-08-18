var Circle = (function () {
    function Circle(startPointX, startPointY, radius) {
        Shape.call(this, startPointX, startPointY);
        this.radius = radius;
    }

    Circle.prototype = new Shape();

    Circle.prototype.constructor = Circle;

    Circle.prototype.draw = function (canvasId, lineWidth, strokeStyle) {
        Shape.prototype.draw.call(this, canvasId, lineWidth, strokeStyle);
        this.canvasContext.arc(this.startPointX, this.startPointY, this.radius, 0, 2 * Math.PI, false);
        this.canvasContext.stroke();
    };

    return Circle;
}());