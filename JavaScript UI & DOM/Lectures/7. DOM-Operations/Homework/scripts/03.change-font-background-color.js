(function () {
    'use strict';

    var wrapper = document.getElementById('wrapper');
    wrapper.style.width = '1200px';
    wrapper.style.height = '800px';
    wrapper.style.padding = '20px';

    var fontColorInputField = document.createElement('input');
    fontColorInputField.setAttribute('type', 'color');
    fontColorInputField.style.width = '100px';
    fontColorInputField.style.height = '40px';

    var backgroundColorInputField = document.createElement('input');
    backgroundColorInputField.setAttribute('type', 'color');
    backgroundColorInputField.style.width = '100px';
    backgroundColorInputField.style.height = '40px';
    backgroundColorInputField.style.margin = '15px';

    var textAreaField = document.createElement('textarea');
    textAreaField.style.display = 'block';
    textAreaField.style.width = '400px';
    textAreaField.style.height = '200px';

    var docFragment = document.createDocumentFragment();

    docFragment.appendChild(fontColorInputField);
    docFragment.appendChild(backgroundColorInputField);
    docFragment.appendChild(textAreaField);

    wrapper.appendChild(docFragment);

    fontColorInputField.addEventListener('change', onFontColorChange, false);
    backgroundColorInputField.addEventListener('change', onBackgroundColorChange, false);

    function onFontColorChange() {
        textAreaField.style.color = fontColorInputField.value;   
    }

    function onBackgroundColorChange() {
        textAreaField.style.backgroundColor = backgroundColorInputField.value;
    }
    
}());