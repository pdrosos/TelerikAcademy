var domModule = (function() {
    'use strict'

    var buffer = [];
    
    function appendChild(element, parentNode) {
        var parent = document.querySelector(parentNode);
        parent.appendChild(element);
    }

    function removeChild(parent, child) {
        var childNode = document.querySelector(parent + " " + child);
        childNode.parentNode.removeChild(childNode);
    }

    function addHandler(selector, eventType, eventHandler) {
        var list = document.querySelectorAll(selector);

        for (var i = 0; i < list.length; i++) {
            list[i].addEventListener(eventType, eventHandler, false);
        }
    }

    function appendToBuffer(selector, element) {
        if (buffer.length === 0) {
            var obj = createElementObj(selector, element);            
            buffer.push(obj);

        } 
        else {
            var isElementPresent = false;
            for (var i = 0; i < buffer.length; i++) {
                if (buffer[i].selector === selector) {
                    isElementPresent = true;
                    buffer[i].docFragment.appendChild(element);
                    if (buffer[i].docFragment.children.length >= 100) {
                        var container = document.querySelector(selector);
                        container.appendChild(buffer[i].docFragment);
                        buffer.splice(i, 1);
                    }
                }
            }

            if (!isElementPresent) {
                var obj = createElementObj(selector, element);
                buffer.push(obj);
            }
        }

        function createElementObj(selector, element) {
            var docFrag = document.createDocumentFragment();
            docFrag.appendChild(element);

            var obj = {
                selector: selector,
                docFragment: docFrag
            }
            return obj;
        }
    }

    function getElementsBySelector(selector) {
        return document.querySelectorAll(selector);
    }

    self = {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElementsBySelector: getElementsBySelector
    }
    return self;
}());