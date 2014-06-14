(function () {
    'use strict';

    window.onload = function() {

        var tags = 
        ["cms", "javascript", "js", "ASP.NET MVC", 
        ".net", ".net", "css", "wordpress", "xaml", 
        "js", "http", "web", "asp.net", "asp.net MVC", 
        "ASP.NET MVC", "wp", "javascript", "js", 
        "cms", "html", "javascript", "http", "http", "CMS"];

        var tagCloud = generateTagCloud(tags, 10, 26);

        tagCloud.style.width = '180px';
        tagCloud.style.border = '1px solid gray';

        document.body.appendChild(tagCloud);
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {

        
        var tagObjects = [],
            uniqueTagsNumber;

        for (var i = 0, len = tags.length; i < len; i += 1) {
            updateOccurrences(tagObjects, tags[i].toLowerCase());
        }

        var leastOccurrences = getLeastOccurrences(tagObjects),
            mostOccurrences = getMostOccurrences(tagObjects);

        var fontDifference = maxFontSize - minFontSize;
        var fontIncreaseStep;

        if (mostOccurrences === leastOccurrences) {
            fontIncreaseStep = 0;
        } 
        else {
            fontIncreaseStep = fontDifference / (mostOccurrences - leastOccurrences);
        }

        var container = document.createElement('div');

        for (var i = 0; i < tagObjects.length; i += 1) {
            var element = document.createElement('span');
            
            if (i === 0) {
                element.style.fontSize = minFontSize;
            }
            else {
                element.style.fontSize = (minFontSize + tagObjects[i].occurrences * fontIncreaseStep) + 'px';
            }

            element.style.display = 'inline-block';
            element.style.margin = '3px';
            element.innerHTML = tagObjects[i].name;
            container.appendChild(element);
        }

        return container;
    }

    function Tag(name) {
        this.name = name;
        this.occurrences = 1;
    }

    function updateOccurrences(tagObjects, tagString) {
        var tagAlreadyExists = false;
        for (var i = 0; i < tagObjects.length; i++) {
            if (tagString === tagObjects[i].name) {
                tagObjects[i].occurrences += 1;
                tagAlreadyExists = true;
                break;
            }
        }

        if (!tagAlreadyExists) {
             var tag = new Tag(tagString);
             tagObjects.push(tag);
        }
    }

    function getLeastOccurrences(tagObjects) {
        var leastOccurrences = Number.MAX_VALUE;
        for (var i = 0; i < tagObjects.length; i++) {
            if (leastOccurrences > tagObjects[i].occurrences) {
                leastOccurrences = tagObjects[i].occurrences;
            }
        }
        return leastOccurrences;
    }

    function getMostOccurrences(tagObjects) {
        var mostOccurrences = Number.MIN_VALUE;
        for (var i = 0; i < tagObjects.length; i++) {
            if (mostOccurrences < tagObjects[i].occurrences) {
                mostOccurrences = tagObjects[i].occurrences;
            }
        }
        return mostOccurrences;
    }
}());