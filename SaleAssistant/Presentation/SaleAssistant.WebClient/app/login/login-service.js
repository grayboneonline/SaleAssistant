(function () {
    'use strict';

    angular.module('saleAssistant').factory('loginService', loginService);

    loginService.$inject = ['$q', 'saHttpService'];

    function loginService($q, saHttpService) {
        var serviceBase = 'oauth/token';
        var service = {
            login: login,
            refreshAccessToken: refreshAccessToken,
        };

        return service;

        function login(username, password, clientId) {
            var params = {
                username: username,
                password: password,
                client_id: clientId,
                grant_type: 'password'
            };

            return saHttpService.postAsFormData(serviceBase, params);
        }

        function refreshAccessToken(refreshToken, clientId) {
            var params = {
                refresh_token: refreshToken,
                client_id: clientId,
                grant_type: 'refresh_token'
            };

            return saHttpService.postAsFormData(serviceBase, params);
        }
    }
})();
