/* globals window, $, document */

'use strict';
window.onload = function () {
	var canvas = document.getElementById('stats-canvas'),
		ctx = canvas.getContext('2d');

	function getData(successCallback) {
		$.get('http://random-numbers.herokuapp.com',
			function (response) {
				successCallback(response);
			});
	}

	//from (x, y), to (x, y)
	function drawAnimatedLine(ctx, from, to) {

		//drawing the trajectory
		ctx.beginPath();
		ctx.moveTo(from.x, from.y);
		ctx.lineTo(to.x, to.y);
		ctx.stroke();

		//draw the many circles

		//calculate number of points
		var n = Math.sqrt((from.x - to.x) * (from.x - to.x) +
			(from.y - to.y) * (from.y - to.y));
		n = (n > 100) ? 100 : n;

		//draw points with interval
		var i = 0;
		// var refreshInterval = 1;

		//animation frame
		function frame() {
			var newPoint = calculateDeltaPosition(from, to, i / n);
			drawPoint(ctx, newPoint.x, newPoint.y);
			i += 1;
			if (i <= n) {
				// setTimeout(frame, refreshInterval);
				window.requestAnimationFrame(frame);
			}
		}
		frame();
	}

	function calculateDeltaPosition(from, to, d) {
		return {
			x: from.x + d * (to.x - from.x),
			y: from.y + d * (to.y - from.y)
		};
	}

	function drawPoint(ctx, x, y) {
		ctx.beginPath();
		ctx.arc(x, y, 3, 0, 2 * Math.PI);
		ctx.fill();
	}

	function drawStats(ctx) {
		var lastPoint = {
				x: 0,
				y: 0
			},
			deltaX = 15;
		drawLine();

		function drawLine() {
			getData(function (data) {
				var point = {
					x: lastPoint.x + deltaX,
					y: 300 - data.value
				};

				var from = {
						x: lastPoint.x,
						y: lastPoint.y
					},
					to = {
						x: point.x,
						y: point.y
					};

				drawAnimatedLine(ctx, from, to);
				lastPoint.x = point.x;
				lastPoint.y = point.y;
				// setTimeout(drawLine, 1000);
				drawLine();
			});
		}

		// get data
		// draw data
	}

	drawStats(ctx);

	// var from = {
	// 		x: 45,
	// 		y: 75
	// 	},
	// 	to = {
	// 		x: 275,
	// 		y: 245
	// 	};
	// drawAnimatedLine(ctx, from, to);

};