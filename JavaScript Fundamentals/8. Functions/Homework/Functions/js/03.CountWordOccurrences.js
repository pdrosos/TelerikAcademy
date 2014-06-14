/*global jsConsole*/
/*jslint browser: true*/

(function () {
    'use strict';

    function countWordOccurrences(text, word, caseSensitive) {
        var i,
            words = [],
            occurrences = 0,
            pattern = /\w+/g;

        //function overloading simulation:
        //if only two parameters (text, word) are specified, the search is NOT case sensitive.
        //if all 3 parameters are entered and caseSensitive = true the search IS case sensitive.
        if (arguments.length === 2 || caseSensitive === false) {
            text = text.toLowerCase();
            word = word.toLowerCase();
        }

        words = text.match(pattern);
        for (i = 0; i < words.length; i += 1) {
            if (words[i] === word) {
                occurrences += 1;
            }
        }

        return occurrences;
    }

    var text = "We all live in the yellow submarine, the yellow submarine, the yellow submarine.";
    jsConsole.writeLine(text);

    document.getElementById("process").onclick = function () {

        var word = jsConsole.read("#word"),
            caseSensitive = true;
        jsConsole.writeLine("Word: \"" + word + "\", Occurrences: " + countWordOccurrences(text, word));
        jsConsole.writeLine("Word: \"" + word + "\", Occurrences (case sensitive): " + countWordOccurrences(text, word, caseSensitive));
    };
}());