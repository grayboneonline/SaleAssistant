(function () {
    'use strict';

    angular.module('saleAssistant').factory('loginService', loginService);

    loginService.$inject = ['$q', 'saHttpService'];

    function loginService($q, saHttpService) {
        var serviceBase = 'oauth/token';
        var service = {
            login: login,
        };

        return service;

        function login(username, password) {
            var params = {
                username: username,
                password: password,
                grant_type: 'password'
            };

            return saHttpService.postAsFormData(serviceBase, params);
        }
    }
})();
