window.onload = (function () {
    var drawRectangle = document.getElementById('draw-rectangle'),
        drawCircle= document.getElementById('draw-circle'),
        drawLine = document.getElementById('draw-line'),
        rectangle = new Rectangle(20, 20, 260, 160),
        circle = new Circle(300, 300, 60),
        line = new Line(100, 200, 200, 350);

    drawRectangle.addEventListener('click', function () {
        rectangle.draw('shapes-canvas', 6, 'red');
    });
    drawCircle.addEventListener('click', function () {
        circle.draw('shapes-canvas', 4, 'blue');
    });
    drawLine.addEventListener('click', function () {
        line.draw('shapes-canvas', 2, 'green');
    });
}());