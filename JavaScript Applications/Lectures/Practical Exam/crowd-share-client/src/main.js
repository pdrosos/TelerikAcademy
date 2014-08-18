define(function() {
    require.config({
        paths: {
            'jquery': '../lib/jquery-2.1.1',
            'sammy': '../lib/sammy',
            'underscore': '../lib/underscore-min',
            'http-requester': 'http-requester',
            'validator': 'model/validator',
            'ui': 'model/ui',
            'login-controller': 'controller/login-controller',
            'post-controller': 'controller/post-controller'
        }
    });

    require(['jquery', 'sammy', 'login-controller', 'post-controller'],
        function($, Sammy, LoginController, PostController) {

        var loginController = new LoginController('http://localhost:3000'),
            postController = new PostController('http://localhost:3000');

        // Sammy is used only for routing, which is allowed in the task description, not for MVC
        var app = Sammy('#wrapper', function() {
            this.get("#/home", function() {
                if (! loginController.isLoggedIn()) {
                    loginController.loadLoginPartials(this);
                } else {
                    loginController.loadLogoutPartials(this);
                }

                postController.getPosts();
            });

            this.get("#/posts", function() {
                this.redirect('#/home');
            });

            this.post('#/login', function() {
                loginController.login(this.params['username'], this.params['password']);
            });

            this.post('#/register', function() {
                loginController.register(this.params['username'], this.params['password']);
            });

            this.post('#/post', function() {
                postController.addPost(this.params['title'], this.params['body'], loginController.getSessionKey());
            });

            this.get("#/logout", function() {
                loginController.logout();

                this.redirect('#/home');
            });
        });

        app.run('#/home');
    });
});