/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    //simulates point class
    function Point(x, y) {
        this.x = x;
        this.y = y;
    }

    Point.prototype.toString = function () {
        return "(" + this.x + ", " + this.y + ")";
    };

    //calculates distance between two points
    Point.prototype.distanceTo = function (b) {
        //X-component of line segment ab (distance)
        var distanceX,
        //Y-component of line segment ab (distance)
            distanceY,
        //line segment ab (distance between points a and b)
            distance;

        distanceX = Math.abs(this.x - b.x);
        distanceY = Math.abs(this.y - b.y);

        //Calculating distance (using Pythagorean theorem a^2 + b^2 = c^2, distance is the hypotenuse)
        distance = Math.sqrt(Math.pow(distanceX, 2) + Math.pow(distanceY, 2));

        return distance;
    };

    //checks if two points are equal (having same coordinates)
    Point.prototype.equals = function (b) {
        return this.x === b.x && this.y === b.y;
    };

    //class defining line segment (http://en.wikipedia.org/wiki/Line_segment) by 2 points (a, b): 
    function Segment(a, b) {
        this.a = a;
        this.b = b;
    }

    Segment.prototype.toString = function () {
        return "(" + this.a + ", " + this.b + ")";
    };

    Segment.prototype.equals = function (cd) {
        return this.a.equals(cd.a) && this.b.equals(cd.b);
    };

    //checks if 3 segments ab, cd, ef can form triangle
    Segment.prototype.canFormTriangle = function (cd, ef) {
        var trianglePoints = [this.a, this.b, cd.a, cd.b, ef.a, ef.b],
            segments = [this, cd, ef],
            countA = 0,
            countB = 0,
            canFormTriangle = true,
            i,
            j;

        for (i = 0; i < segments.length; i += 1) {

            for (j = 0; j < trianglePoints.length; j += 1) {

                if (segments[i].a.equals(trianglePoints[j])) {
                    countA += 1;
                }
                if (segments[i].b.equals(trianglePoints[j])) {
                    countB += 1;
                }
            }
            //Requirement for triangle: from all 6 segment points, each point should be met exactly 2 times.
            //If each point is not met exactly two times then the 3 segments cannot form triangle.
            if (countA !== 2 || countB !== 2) {
                canFormTriangle = false;
                break;
            }

            countA = 0;
            countB = 0;
        }
        return canFormTriangle;
    };

    var a = new Point(2, 4),
        b = new Point(5, 8),
        c = new Point(7, 9),
        segments = [
            new Segment(a, b),
            new Segment(b, c),
            new Segment(c, a)],
        i;

    jsConsole.writeLine("Point a: " + a);
    jsConsole.writeLine("Point b: " + b);
    jsConsole.writeLine("Distance from a to b: " + a.distanceTo(b));

    jsConsole.writeLine("Segments:");
    for (i = 0; i < segments.length; i += 1) {
        jsConsole.writeLine(segments[i]);
    }
    jsConsole.writeLine("can form triangle: " + segments[0].canFormTriangle(segments[1], segments[2]));

}());