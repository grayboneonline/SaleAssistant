(function () {
    'use strict';

    angular.module('saleAssistant').factory('httpInterceptor', httpInterceptor)
                                   .config(httpConfig)
                                   .run(eventHandler);

    httpInterceptor.$inject =['$q', '$location', '$rootScope', 'sessionService'];

    function httpInterceptor($q, $location, $rootScope, sessionService) {
        return {
            request: function($config) {
                $rootScope.isAjaxLoading = true;
                if (sessionService.getAccessToken()) {
                    $config.headers['Authorization'] = "Bearer " + sessionService.getAccessToken();
                }
                return $config;
            },
            response: function(response) {
                $rootScope.isAjaxLoading = false;
                return response || $q.when(response);
            },
            responseError: function(rejection) {
                $rootScope.isAjaxLoading = false;
                return $q.reject(rejection);
            }
        }
    }

    httpConfig.$inject = ['$httpProvider'];

    function httpConfig($httpProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
    }

    eventHandler.$inject = ['$rootScope', '$injector', 'sessionService', 'authService', '$location', 'loginService'];

    function eventHandler($rootScope, $injector, sessionService, authService, $location, loginService) {

        $rootScope.$on('event:auth-loginRequired', function() {
            if (!$rootScope.isRefreshingToken) {
                $rootScope.isRefreshingToken = true;
                loginService.refreshAccessToken(sessionService.getRefreshToken(), sessionService.getClientId()).then(onSuccess, onError);
            }

            function onSuccess(data) {
                $rootScope.isRefreshingToken = false;
                sessionService.setAccessToken(data.access_token);
                sessionService.setRefreshToken(data.refresh_token);
                authService.loginConfirmed();
            }
            function onError() {
                $rootScope.isRefreshingToken = false;
                sessionService.setAccessToken(undefined);
                sessionService.setRefreshToken(undefined);
                $location.path('/login');
            }
        });
    }
})();