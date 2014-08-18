define(['http-requester', 'ui'], function(HttpRequester, UI) {
    var PostController = (function() {
        var PostController = function(resourceUrl) {
            this.resourceUrl = resourceUrl;
            this.refreshTimeMS = 4000;
            this.showLastPostsCount = 200;
        };

        PostController.prototype.addPost = function(title, body, sessionKey) {
            var self = this;

            var headers = [];
            headers.push({name: 'X-SessionKey', value: sessionKey});

            HttpRequester.postJSON(self.resourceUrl + '/post', {
                title: title,
                body: body
            }, headers).done(function(data, textStatus, jqXHR) {
                window.location.href = '#/posts';
            }).fail(function(jqXHR, textStatus, errorThrown) {
                UI.addErrorMessage(jqXHR.responseJSON.message);
            });
        };

        PostController.prototype.getPosts = function() {
            var self = this;

            updatePostsBox(self.resourceUrl);
            setInterval(function() {
                updatePostsBox(self.resourceUrl);
            }, self.refreshTimeMS);
        };

        function updatePostsBox(url) {
            var self = this;

            HttpRequester.getJSON(url + '/post')
            .done(function(data, textStatus, jqXHR) {
                UI.buildPostsBox(data, self.showLastPostsCount);
            }).fail(function(jqXHR, textStatus, errorThrown) {
                var template = Handlebars.compile($("#error-message-template").html());
                var html = template({errorMessage: jqXHR.responseJSON.message});

                $('#error-message').html(html);
            });
        }

        return PostController;
    }());

    return PostController;
});