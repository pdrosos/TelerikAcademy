window.onload = (function () {
    movingShapes.startEngine();

    var addCircleButton = document.getElementById('addCircle');
    addCircleButton.addEventListener('click', function () {
        movingShapes.add('circle');
    });

    var addRectangleButton = document.getElementById('addRectangle');
    addRectangleButton.addEventListener('click', function () {
        movingShapes.add('rect');
    });
}());