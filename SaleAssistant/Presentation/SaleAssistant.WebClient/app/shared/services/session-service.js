(function () {
    'use strict';

    angular.module('saleAssistant').factory('sessionService', sessionService);

    sessionService.$inject = ['$localStorage'];

    function sessionService($localStorage) {
        var service = {
            getAccessToken: getAccessToken,
            setAccessToken: setAccessToken,
            getRefreshToken: getRefreshToken,
            setRefreshToken: setRefreshToken,
            getClientId: getClientId,
        };

        return service;

        function getAccessToken() {
            return $localStorage.accessToken;
        }
        function setAccessToken(token) {
            $localStorage.accessToken = token;
        }
        function getRefreshToken() {
            return $localStorage.refreshToken;
        }
        function setRefreshToken(token) {
            $localStorage.refreshToken = token;
        }
        function getClientId() {
            return 'angularApp';
        }
    }
})();