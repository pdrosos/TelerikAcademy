define(function() {
    var Validator = (function() {
        function isValidUserName(username) {
            var isValidUsername = username && typeof username == 'string' &&
                                  username.length >= 6 && username.length <= 40;
            return isValidUsername;
        }

        return {
            isValidUserName: isValidUserName
        }
    }());

    return Validator;
});