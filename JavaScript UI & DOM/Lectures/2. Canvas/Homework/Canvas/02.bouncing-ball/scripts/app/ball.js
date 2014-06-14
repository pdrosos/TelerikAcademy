define(function (require) {
    'use strict';
    
    var Direction = require('./direction');
    var WallPosition = require('./wall-position');

    //simulates ball class
    function Ball(centerX, centerY, radius, direction, lineWidth, strokeStyle, fillStyle, canvas) {
        this.centerX = centerX;
        this.centerY = centerY;
        this.radius = radius;
        this.direction = direction;
        this.lineWidth = lineWidth;
        this.strokeStyle = strokeStyle;
        this.fillStyle = fillStyle;
        this.canvas = canvas;
    }

    Ball.prototype.toString = function () {
        return "Center: (" + this.centerX + ", " + this.centerY + "), Radius: " + this.radius;
    };

    Ball.prototype.changeColor = function (colorOne, colorTwo, switchColorsCount, colorsChangeRate) {
        if (switchColorsCount.value >= 2 * colorsChangeRate) {
            switchColorsCount.value = 0;
        }

        if (switchColorsCount.value > 0 && switchColorsCount.value <= colorsChangeRate) {
            this.fillStyle = colorOne;
        }
        else {
            this.fillStyle = colorTwo;
        }
        switchColorsCount.value += 1;
    };

    Ball.prototype.draw = function () {
        var context = this.canvas.getContext("2d");
        context.clearRect(0, 0, this.canvas.width, this.canvas.height);
        context.beginPath();
        context.arc(this.centerX, this.centerY, this.radius, 0, 2 * Math.PI);
        context.closePath();

        context.restore();

        context.lineWidth = this.lineWidth;
        context.strokeStyle = this.strokeStyle;
        context.fillStyle = this.fillStyle;

        context.stroke();
        context.fill();
    };

    Ball.prototype.isWallReached = function () {
        var wallReached = false,
            ballMostLeftCoord = this.centerX - this.radius,
            ballMostRightCoord = this.centerX + this.radius,
            ballHighestCoord = this.centerY - this.radius,
            ballLowestCoord = this.centerY + this.radius;

        if (ballMostLeftCoord <= 0 || ballMostRightCoord >= this.canvas.width ||
                ballHighestCoord <= 0 || ballLowestCoord >= this.canvas.height) {
            wallReached = true;
        }

        return wallReached;
    };

    Ball.prototype.getReachedWall = function () {
        var ballMostLeftCoord = this.centerX - this.radius,
            ballMostRightCoord = this.centerX + this.radius,
            ballHighestCoord = this.centerY - this.radius,
            ballLowestCoord = this.centerY + this.radius,
            reachedWall;

        if (ballMostLeftCoord <= 0) {
            reachedWall = WallPosition.Left;
        } else if (ballMostRightCoord >= this.canvas.width) {
            reachedWall = WallPosition.Right;
        } else if (ballHighestCoord <= 0) {
            reachedWall = WallPosition.Top;
        } else if (ballLowestCoord >= this.canvas.height) {
            reachedWall = WallPosition.Bottom;
        } else {
            reachedWall = null;
        }
        return reachedWall;
    };

    Ball.prototype.changeDirection = function () {

        if (this.direction === Direction.DownRight &&
                this.getReachedWall(this.canvas) === WallPosition.Bottom) {
            this.direction = Direction.UpRight;
        } else if (this.direction === Direction.DownRight &&
                    this.getReachedWall(this.canvas) === WallPosition.Right) {
            this.direction = Direction.DownLeft;
        } else if (this.direction === Direction.UpRight &&
                    this.getReachedWall(this.canvas) === WallPosition.Top) {
            this.direction = Direction.DownRight;
        } else if (this.direction === Direction.UpRight &&
                    this.getReachedWall(this.canvas) === WallPosition.Right) {
            this.direction = Direction.UpLeft;
        } else if (this.direction === Direction.DownLeft &&
                    this.getReachedWall(this.canvas) === WallPosition.Bottom) {
            this.direction = Direction.UpLeft;
        } else if (this.direction === Direction.DownLeft &&
                    this.getReachedWall(this.canvas) === WallPosition.Left) {
            this.direction = Direction.DownRight;
        } else if (this.direction === Direction.UpLeft &&
                    this.getReachedWall(this.canvas) === WallPosition.Top) {
            this.direction = Direction.DownLeft;
        } else if (this.direction === Direction.UpLeft &&
                this.getReachedWall(this.canvas) === WallPosition.Left) {
            this.direction = Direction.UpRight;
        } else if (this.direction === Direction.Down) {
            this.direction = Direction.Up;
        } else if (this.direction === Direction.Up) {
            this.direction = Direction.Down;
        } else if (this.direction === Direction.Left) {
            this.direction = Direction.Right;
        } else if (this.direction === Direction.Right) {
            this.direction = Direction.Left;
        } else {
            throw "Error: Invalid direction type.";
        }
    };

    Ball.prototype.move = function (speed) {
        switch (this.direction) {
        case Direction.Down:
            this.centerY += speed;
            break;
        case Direction.Up:
            this.centerY -= speed;
            break;
        case Direction.Left:
            this.centerX -= speed;
            break;
        case Direction.Right:
            this.centerX += speed;
            break;
        case Direction.DownRight:
            this.centerX += speed;
            this.centerY += speed;
            break;
        case Direction.UpRight:
            this.centerX += speed;
            this.centerY -= speed;
            break;
        case Direction.UpLeft:
            this.centerX -= speed;
            this.centerY -= speed;
            break;
        case Direction.DownLeft:
            this.centerX -= speed;
            this.centerY += speed;
            break;
        default:
            throw "Error: Invalid ball move.";
        }
    };
    
    return Ball;
});