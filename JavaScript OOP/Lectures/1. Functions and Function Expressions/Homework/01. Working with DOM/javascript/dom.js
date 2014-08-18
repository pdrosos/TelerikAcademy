window.onload = (function () {
    var div = document.createElement("div");

    //appends div to #wrapper
    domModule.appendChild(div, "#wrapper");

    //removes li:first-child from ul
    domModule.removeChild("ul","li:first-child");

    //add handler to each a element with class button
    domModule.addHandler("a.button", "click", function(){alert("Clicked")});

    //adding 99 div elements to the buffer
    for (var i = 0; i < 99; i++) {
        domModule.appendToBuffer("#wrapper", div.cloneNode(true));
    }

    //adding 100th div element to the buffer, at that point all 100 div elements are appended to the wrapper
    domModule.appendToBuffer("#wrapper", div.cloneNode(true));

    var buttons = domModule.getElementsBySelector("a.button");
    console.log(buttons);
}());