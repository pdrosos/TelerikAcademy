/*jslint browser: true*/

(function () {
    'use strict';

    function getChildDivsUsingQuerySelectorAll() {
        var divs = document.querySelectorAll('div > div');
        return divs;
    }

    function getChildDivsUsingGetElementsByTagName() {
        var divs = [],
            allDivs,
            i;

        allDivs = document.getElementsByTagName('div');

        for (i = 0; i < allDivs.length; i += 1) {
            if (allDivs[i].parentNode.tagName.toLowerCase() === 'div') {
                divs.push(allDivs[i]);
            }
        }
        return divs;
    }

    var divsCount,
        directChildDivsCount;

    divsCount = document.createElement('p');
    directChildDivsCount = getChildDivsUsingQuerySelectorAll().length;

    divsCount.innerHTML = "Direct inner div elements (QuerySelectorAll): " + directChildDivsCount;
    document.body.appendChild(divsCount);

    divsCount = document.createElement('p');
    directChildDivsCount = getChildDivsUsingGetElementsByTagName().length;

    divsCount.innerHTML = "Direct inner div elements (GetElementsByTagName): " + directChildDivsCount;
    document.body.appendChild(divsCount);

}());