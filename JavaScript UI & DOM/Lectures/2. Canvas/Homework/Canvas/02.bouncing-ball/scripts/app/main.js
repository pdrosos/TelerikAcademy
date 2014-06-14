/*jslint browser: true*/

define(function (require) {
    'use strict';

    var Ball = require('./ball');
    var Direction = require('./direction');
    
    var canvas = document.getElementById('the-canvas'),
        ballRadius = 30,
        startX = ballRadius + 2,
        startY = canvas.height / 2,
        speed = 2;

    var ball = new Ball(startX, startY, ballRadius, Direction.DownRight, 2, '#252321', '#D4DBD3', canvas);
        
        //var switchColorsCount = {value: 0};
        //var colorsChangeRate = 20;
    

    function startBouncing() {

        if (ball.isWallReached()) {
            ball.changeDirection();
        }

        //ball.changeColor('#AEB5D4', '#334061', switchColorsCount, colorsChangeRate);

        ball.draw();
        ball.move(speed);
        
        requestAnimationFrame(startBouncing);
    }
    requestAnimationFrame(startBouncing);

});