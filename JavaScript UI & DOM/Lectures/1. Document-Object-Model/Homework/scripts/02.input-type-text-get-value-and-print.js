/*jslint browser: true*/

(function () {
    'use strict';
    document.querySelector('input[type=button]').onclick = function () {
        var input,
            notification;
        input = document.querySelector('input[type=text]').value;
        console.log(input);

        notification = document.createElement('p');
        notification.innerHTML = "Now open the browser console and check the output";
        document.body.appendChild(notification);
    };
}());