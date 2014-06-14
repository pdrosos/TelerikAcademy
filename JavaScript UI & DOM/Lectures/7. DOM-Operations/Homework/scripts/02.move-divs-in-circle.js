(function () {
    'use strict';
    var container = document.getElementById('container');
    container.style.position = 'relative';
    container.style.width = '1100px';
    container.style.height = '700px';
    container.style.backgroundColor = '#222222';

    var bigCircleRadius = 250;

    var divsList = createDivs(5);

    styleDivsAsCircles(divsList, 50);

    positionDivsInCircle(divsList, parseFloat(container.style.width) / 2, parseFloat(container.style.height) / 2, bigCircleRadius);

    appendElementsToDOM(divsList, container);

    rotateElements(divsList, bigCircleRadius, container.offsetWidth / 2, container.offsetHeight / 2, 100, 0.08);

    function createDivs(elementsNumber) {
        var divs = [];
        for (var i = 0; i < elementsNumber; i += 1) {
            var divElement = document.createElement('div');
            divElement.setAttribute('initialAngle', 0);
            divs.push(divElement);
        }
        return divs;
    }

    function styleDivsAsCircles(divs, size) {
        
        for (var i = 0, len = divs.length; i < len; i += 1) {
            divs[i].style.width = size + 'px';
            divs[i].style.height = size + 'px';
            divs[i].style.borderRadius = (size / 2) + 'px';
            divs[i].style.border = '1px solid black';
            setRandomBackgroundColor(divs[i]);
        }
    }

    // Returns a random integer between min and max
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function setRandomBackgroundColor(element) {
        var red = getRandomInt(0, 255),
            green = getRandomInt(0, 255),
            blue = getRandomInt(0, 255);

            element.style.backgroundColor = 'rgb(' + red + ',' 
                + green + ',' + blue + ')';
    }

    function positionDivsInCircle(divs, centerX, centerY, radius) {
        var divsNumber = divs.length;
        
        var angleBetweenTwoDivs = 2 * Math.PI / divsNumber;
        for (var i = 0; i < divsNumber; i += 1) {
            divs[i].style.position = 'absolute';
            divs[i].initialAngle = i * angleBetweenTwoDivs;

            var divCenterX = centerX + radius * Math.cos(i * angleBetweenTwoDivs);
            var divCenterY = centerY + radius * Math.sin(i * angleBetweenTwoDivs);

            divs[i].style.left = divCenterX - (parseFloat(divs[i].style.width) / 2) + 'px';
            divs[i].style.top = divCenterY - (parseFloat(divs[i].style.height) / 2) + 'px';
        }
    }

    function appendElementsToDOM(elements, parentNode) {
        var docFragment = document.createDocumentFragment();
        for (var i = 0, len = elements.length; i < len; i += 1) {
            docFragment.appendChild(elements[i]);   
        }

        parentNode.appendChild(docFragment);
    }

    function rotateElements(elements, radius, centerX, centerY, timeInterval, speed) {

            var angleDifference = 0;

        function animate() {
        
            for (var i = 0, len = elements.length; i < len; i += 1) {

                var elementCenterX = centerX + radius * Math.cos(elements[i].initialAngle + angleDifference);
                var elementCenterY = centerY + radius * Math.sin(elements[i].initialAngle + angleDifference);
                elements[i].style.left = (elementCenterX - parseFloat(elements[i].style.width) / 2) + 'px';
                elements[i].style.top = (elementCenterY - parseFloat(elements[i].style.height) / 2) + 'px';
            }

            angleDifference += speed;
            setTimeout(animate, timeInterval);
        }
        animate();
    }
}());