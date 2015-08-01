(function () {
    'use strict';

    angular.module('saleAssistant').factory('responseInterceptor', responseInterceptor)
                                   .config(httpConfig)
                                   .run(modifyRequest);

    responseInterceptor.$inject = ['$q', '$location', '$rootScope'];

    function responseInterceptor($q, $location, $rootScope) {
        return {
            response: function (response) {
                $rootScope.isAjaxLoading = false;
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                $rootScope.isAjaxLoading = false;

                //if (rejection.status === 401) {
                //    $location.path('/login');
                //}
                return $q.reject(rejection);
            }
        }
    }

    httpConfig.$inject = ['$httpProvider'];

    function httpConfig($httpProvider) {
        $httpProvider.interceptors.push('responseInterceptor');
    }

    modifyRequest.$inject = ['$rootScope', '$injector', 'sessionService', 'authService', '$location'];

    function modifyRequest($rootScope, $injector, sessionService, authService, $location) {
        $injector.get("$http").defaults.transformRequest = function (data, headersGetter) {
            $rootScope.isAjaxLoading = true;

            if (sessionService.isLogged())
                headersGetter()['Authorization'] = "Bearer " + sessionService.getAccessToken();
            if (data) return angular.toJson(data);
        };

        $rootScope.$on('event:auth-loginRequired', function() {
            var loginService = $injector.get('loginService');
            loginService.refreshAccessToken(sessionService.getRefreshToken(), sessionService.getClientId()).then(onSuccess, onError);

            function onSuccess(data) {
                sessionService.setAccessToken(data.access_token);
                sessionService.setRefreshToken(data.refresh_token);
                authService.loginConfirmed();
            }
            function onError() {
                sessionService.setAccessToken(undefined);
                sessionService.setRefreshToken(undefined);
                $location.path('/login');
            }
        });
    }
})();