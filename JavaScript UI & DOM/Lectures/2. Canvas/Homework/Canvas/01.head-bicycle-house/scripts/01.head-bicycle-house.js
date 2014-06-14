var canvas = document.getElementById('main-canvas');
var ctx = canvas.getContext('2d');

//bike
ctx.beginPath();
ctx.lineWidth = 2;
ctx.strokeStyle = "#337D8E";
ctx.fillStyle = "#90CAD7";
ctx.arc(170, 510, 50, 0, 7);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.lineWidth = 2;
ctx.strokeStyle = "#337D8E";
ctx.fillStyle = "#90CAD7";
ctx.moveTo(170, 510);
ctx.lineTo(230, 450);
ctx.lineTo(350, 450);
ctx.lineTo(250, 510); 
ctx.lineTo(215, 425);
ctx.lineTo(235, 425);
ctx.lineTo(195, 425);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(250, 510);
ctx.lineTo(170, 510);
ctx.stroke();

ctx.beginPath();
ctx.lineWidth = 2;
ctx.strokeStyle = "#337D8E";
ctx.fillStyle = "#90CAD7";
ctx.arc(360, 510, 50, 0, 7);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(360, 510);
ctx.lineTo(340, 410);
ctx.lineTo(370, 380);
ctx.moveTo(340, 410);
ctx.lineTo(300, 425);
ctx.stroke();

ctx.beginPath();
ctx.arc(250, 510, 15, 0.5, 7);
ctx.lineTo(275, 530);
ctx.stroke();

ctx.beginPath();
ctx.arc(250, 510, 15, 0, 4);
ctx.lineTo(225, 480);
ctx.stroke();



//snowman
ctx.lineWidth = 4;
drawEllipse(ctx, 165, 275, 115, 105);
ctx.fill();

drawEllipse(ctx, 185, 340, 55, 20);
ctx.fill();

ctx.beginPath();
ctx.lineWidth = 2;
ctx.moveTo(210, 330);
ctx.lineTo(195, 330);
ctx.lineTo(210, 300);
ctx.stroke();

ctx.lineWidth = 4;
drawEllipse(ctx, 180, 305, 15, 12);
ctx.fill();

ctx.lineWidth = 4;
drawEllipse(ctx, 220, 305, 15, 12);
ctx.fill();

ctx.lineWidth = 4;

ctx.strokeStyle = "#262626";
ctx.fillStyle = "#262626";

drawEllipse(ctx, 222, 308, 5, 8);
ctx.fill();

drawEllipse(ctx, 182, 308, 5, 8);
ctx.fill();

ctx.fillStyle = "#396693";
ctx.strokeStyle = "#262626";

drawEllipse(ctx, 155, 265, 130, 30);
ctx.fill();

drawEllipse(ctx, 190, 255, 70, 25);
ctx.fill();

ctx.fillRect(190, 200, 70, 65);
ctx.lineWidth = 2;
ctx.strokeRect(190, 200, 70, 65);
ctx.lineWidth = 4;
ctx.fillRect(191, 260, 68, 10);

drawEllipse(ctx, 190, 190, 70, 25);
ctx.fill();

// house
ctx.fillStyle = "#975B5B";
ctx.strokeStyle = "#000000";

ctx.lineWidth = 2;
ctx.fillRect(510, 300, 240, 180);
ctx.strokeRect(510, 300, 240, 180);

ctx.beginPath()
ctx.moveTo(510, 298);
ctx.lineTo(630, 160);
ctx.lineTo(750, 298);
ctx.stroke();
ctx.fill();

ctx.lineWidth = 2;
ctx.fillRect(680, 200, 25, 70);
ctx.strokeRect(680, 200, 25, 70);
ctx.fillRect(675, 265, 45, 15);
ctx.lineWidth = 4;

drawEllipse(ctx, 680, 195, 25, 5);
ctx.fill();

ctx.fillStyle = "#000000";
ctx.strokeStyle = "#975B5B";
ctx.fillRect(525, 320, 90, 60);
ctx.beginPath();
ctx.moveTo(525, 350);
ctx.lineTo(615, 350);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(570, 320);
ctx.lineTo(570, 380);
ctx.stroke();


ctx.fillRect(645, 320, 90, 60);
ctx.beginPath();
ctx.moveTo(690, 320);
ctx.lineTo(690, 380);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(645, 350);
ctx.lineTo(735, 350);
ctx.stroke();

ctx.fillRect(645, 390, 90, 60);
ctx.beginPath();
ctx.moveTo(690, 390);
ctx.lineTo(690, 450);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(645, 420);
ctx.lineTo(735, 420);
ctx.stroke();

ctx.fillStyle = "#975B5B";
ctx.strokeStyle = "#000000";
drawEllipse(ctx, 540, 395, 65, 35);

ctx.fillRect(540, 410, 65, 40);
ctx.fill();

ctx.lineWidth = 2;
ctx.beginPath();
ctx.moveTo(540, 410);
ctx.lineTo(540, 480);
ctx.stroke();


ctx.beginPath();
ctx.moveTo(605, 410);
ctx.lineTo(605, 480);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(572, 395);
ctx.lineTo(572, 480);
ctx.stroke();

ctx.beginPath();
ctx.arc(582, 452, 4, 0, 7);
ctx.stroke();

ctx.beginPath();
ctx.arc(563, 452, 4, 0, 7);
ctx.stroke();

function drawEllipseByCenter(ctx, cx, cy, w, h) {
    drawEllipse(ctx, cx - w / 2.0, cy - h / 2.0, w, h);
}

function drawEllipse(ctx, x, y, w, h) {
    var kappa = .5522848,
        ox = (w / 2) * kappa, // control point offset horizontal
        oy = (h / 2) * kappa, // control point offset vertical
        xe = x + w,           // x-end
        ye = y + h,           // y-end
        xm = x + w / 2,       // x-middle
        ym = y + h / 2;       // y-middle

    ctx.beginPath();
    ctx.moveTo(x, ym);
    ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
    ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
    ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
    ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
    ctx.closePath();
    ctx.stroke();
}