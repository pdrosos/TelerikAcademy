define(function() {
    var UI = (function() {
        function addErrorMessage(message) {
            var template = Handlebars.compile($("#error-message-template").html());
            var html = template({errorMessage: message});

            $('#error-message').html(html);
        }

        function buildPostsBox(posts, skipMessagesCount) {
            var template = Handlebars.compile($("#posts-template").html());
            var html = template({posts: posts});

            $('#posts').html(html);
        }

        return {
            addErrorMessage: addErrorMessage,
            buildPostsBox: buildPostsBox
        }
    }());

    return UI;
});