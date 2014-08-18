var Rectangle = (function () {
    function Rectangle(startPointX, startPointY, width, height) {
        Shape.call(this, startPointX, startPointY);
        this.width = width;
        this.height = height;
    }

    Rectangle.prototype = new Shape();
    
    Rectangle.prototype.constructor = Rectangle;
    
    Rectangle.prototype.draw = function (canvasId, lineWidth, strokeStyle) {
        Shape.prototype.draw.call(this, canvasId, lineWidth, strokeStyle);
        
        this.canvasContext.rect(this.startPointX, this.startPointY, this.width, this.height);
        this.canvasContext.stroke();
    };

    return Rectangle;
}());