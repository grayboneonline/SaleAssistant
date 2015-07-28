﻿(function () {
    'use strict';

    angular.module('saleAssistant').factory('sessionService', sessionService);

    sessionService.$inject = ['$localStorage'];

    function sessionService($localStorage) {
        var service = {
            isLogged: isLogged,
            getAccessToken: getAccessToken,
            setAccessToken: setAccessToken
        };

        return service;

        function getAccessToken() {
            return $localStorage.accessToken;
        }
        function setAccessToken(token) {
            $localStorage.accessToken = token;
        }
        function isLogged() {
            return $localStorage.accessToken != undefined;
        }
    }
})();