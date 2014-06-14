window.onload = function () {
    var canvas = document.getElementById('field'),
        ctx = canvas.getContext('2d'),
        center = {
            x: canvas.width / 2,
            y: canvas.height / 2
        },
        radius = 150,
        angle = 0,
        point = {
            radius: 5,
            x: 0,
            y: 0
        },
        pointsCount = 1;

    function drawPoint(ctx, x, y, r){
        ctx.beginPath();
        ctx.arc(x, y, r, 0, 2*Math.PI);
        ctx.fill();
    }

    function movePoint(trajectory){
        return {
            x : trajectory.x + trajectory.radius * Math.cos(trajectory.angle),
            y : trajectory.y + trajectory.radius * Math.sin(trajectory.angle)
        };
    }

    function drawTrajectory() {
        ctx.beginPath();
        ctx.arc(center.x, center.y, radius, 0, 2 * Math.PI);
        ctx.stroke();
    }

    var shouldRun = true;

    function frame() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawTrajectory();
        angle += 0.05;
        for (var i = 0; i < pointsCount; i += 1) {
            var newPoint = movePoint({
                x: center.x,
                y: center.y,
                radius: radius,
                angle: angle + i * 2 * Math.PI / pointsCount
            });
            drawPoint(ctx, newPoint.x, newPoint.y, point.radius);
        }
        //var newPoint = movePoint({
        //    x: center.x,
        //    y: center.y,
        //    radius: radius,
        //    angle: angle
        //});
        drawPoint(ctx, newPoint.x, newPoint.y, point.radius);

        //setTimeout(frame, 100);
        window.requestAnimationFrame(frame);
    }

    frame();




};