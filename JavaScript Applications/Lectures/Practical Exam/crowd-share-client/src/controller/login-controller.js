define(['http-requester', 'validator'], function(HttpRequester, Validator) {
    var LoginController = (function() {
        var LoginController = function(resourceUrl) {
            this.resourceUrl = resourceUrl;
        };

        LoginController.prototype.getUsername = function() {
            return sessionStorage.getItem('username');
        };

        LoginController.prototype.setUsername = function(username) {
            sessionStorage.setItem('username', username);
        };

        LoginController.prototype.destroyUsername = function() {
            sessionStorage.removeItem('username');
        };

        LoginController.prototype.getSessionKey = function() {
            return sessionStorage.getItem('sessionKey');
        };

        LoginController.prototype.setSessionKey = function(sessionKey) {
            sessionStorage.setItem('sessionKey', sessionKey);
        };

        LoginController.prototype.destroySessionKey = function() {
            sessionStorage.removeItem('sessionKey');
        };

        LoginController.prototype.isLoggedIn = function() {
            return this.getSessionKey() != null;
        };

        LoginController.prototype.loadLoginPartials = function() {
            $('#login').load('src/view/login-template.html');
            $('#register').load('src/view/register-template.html');
            $('#logout').html('');
            $('#add-post').html('');
        };

        LoginController.prototype.loadLogoutPartials = function() {
            $('#login').html('');
            $('#register').html('');
            $('#logout').load('src/view/logout-template.html');
            $('#add-post').load('src/view/add-post-template.html');
        };

        LoginController.prototype.register = function(username, password) {
            var self = this;

            /*
            if (! Validator.isValidUserName(username)) {
                var template = Handlebars.compile($("#error-message-template").html());
                var html = template({errorMessage: 'Invalid username'});

                $('#error-message').html(html);

                return;
            }
            */

            HttpRequester.postJSON(self.resourceUrl + '/user', {
                username: username,
                authCode: SHA1(username + password)
            }).done(function(data, textStatus, jqXHR) {
                self.setUsername(data.username);
                self.setSessionKey(data.sessionKey);

                window.location.href = '#/posts';
            }).fail(function(jqXHR, textStatus, errorThrown) {
                var template = Handlebars.compile($("#error-message-template").html());
                var html = template({errorMessage: jqXHR.responseJSON.message});

                $('#error-message').html(html);
            });
        };

        LoginController.prototype.login = function(username, password) {
            var self = this;

            HttpRequester.postJSON(self.resourceUrl + '/auth', {
                username: username,
                authCode: SHA1(username + password)
            }).done(function(data, textStatus, jqXHR) {
                self.setUsername(data.username);
                self.setSessionKey(data.sessionKey);

                window.location.href = '#/posts';
            }).fail(function(jqXHR, textStatus, errorThrown) {
                var template = Handlebars.compile($("#error-message-template").html());
                var html = template({errorMessage: jqXHR.responseJSON.message});

                $('#error-message').html(html);
            });
        };

        LoginController.prototype.logout = function() {
            var exit = confirm("Are you sure you want to end the session?");
            if (exit === true) {
                this.destroyUsername();
                this.destroySessionKey();
            }
        };

        return LoginController;
    }());

    return LoginController;
});