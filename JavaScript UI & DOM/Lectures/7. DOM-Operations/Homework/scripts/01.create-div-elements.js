(function () {
    'use strict';

    var generateDivsBtn,
        contentDiv = document.getElementById('content');
        contentDiv.style.position = 'relative';
        contentDiv.style.width = '1200px';
        contentDiv.style.height = '600px';

    generateDivsBtn = document.getElementById("btn-generate-divs");
    generateDivsBtn.addEventListener("click", onGenerateDivsBtnClick);

    function onGenerateDivsBtnClick() {
        while (contentDiv.firstChild) {
            contentDiv.removeChild(contentDiv.firstChild);
        }

        var elementsNumber = (document.getElementById("elements-number").value || 5) | 0;
        var divsDocumentFragment = createDivs(elementsNumber, contentDiv);
        contentDiv.appendChild(divsDocumentFragment);
    }


    // Returns a random integer between min and max
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        var color = {
            red: getRandomInt(0, 255),
            green: getRandomInt(0, 255),
            blue: getRandomInt(0, 255)
        }

        return color;
    }

    function createDivs(elementsNumber, parentNode) {
        var docFragment = document.createDocumentFragment();

        for (var i = 0; i < elementsNumber; i += 1) {
            
            var divElement = document.createElement('div');
            
            var randomWidth = getRandomInt(20, 100);
            var randomHeight = getRandomInt(20, 100);

            divElement.style.width =  randomWidth + 'px';
            divElement.style.height = randomHeight + 'px';
            
            var backgroundColor = getRandomColor();
            divElement.style.backgroundColor = 'rgb(' + backgroundColor.red + ',' 
                + backgroundColor.green + ',' + backgroundColor.blue + ')';

            var fontColor = getRandomColor();

            divElement.style.color = 'rgb(' + fontColor.red + ',' 
                + fontColor.green + ',' + fontColor.blue + ')';
            
            divElement.style.position = 'absolute';
            var divElementHeight = parseInt(divElement.style.height, 10) || 0;
            var divElementWidth = parseInt(divElement.style.width, 10) || 0;

            divElement.style.top = getRandomInt(0, parentNode.offsetHeight - divElementHeight) + 'px'; 
            divElement.style.left = getRandomInt(0, parentNode.offsetWidth - divElementWidth) + 'px';

            divElement.innerHTML = '<strong>div</strong>';

            divElement.style.borderRadius = getRandomInt(0, 20) + 'px';

            var borderColor = getRandomColor();
            divElement.style.borderColor = 'rgb(' + borderColor.red + ',' 
                + borderColor.green + ',' + borderColor.blue + ')';
            
            divElement.style.borderWidth = getRandomInt(0, 30) + "px";

            docFragment.appendChild(divElement);
        }

        return docFragment;
    }

}());