/*jslint browser: true*/
/*global Sizzle*/

function onButtonClick() {
    'use strict';
    var selector = document.getElementById("selector").value,
        elements = new Sizzle(selector),
        result = document.createElement("div"),
        wrapper = document.getElementById("wrapper"),
        fragment = document.createDocumentFragment(),
        i;

    for (i = 0; i < elements.length; i += 1) {
        result = document.createElement("div");
        result.innerHTML += "Tag name: " + elements[i].tagName + " Class: " + elements[i].className + " ID: " + elements[i].id;
        fragment.appendChild(result);
    }
    wrapper.appendChild(fragment);
}