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

                if (rejection.status === 401) {
                    $location.path('/login');
                    // handle refresh token here.
                    //var token = $rootScope.refresh_token;

                    //authFactory.save({
                    //    client_id: 'client_id',
                    //    grant_type: 'refresh_token',
                    //    // refresh_token: token, sent with the encrypted cookie
                    //}, function (obj) {
                    //    //update access_token
                    //}, function () {
                    //    //redirect to login page
                    //});
                }
                return $q.reject(rejection);
            }
        }
    }

    httpConfig.$inject = ['$httpProvider'];

    function httpConfig($httpProvider) {
        $httpProvider.interceptors.push('responseInterceptor');
    }

    modifyRequest.$inject = ['$rootScope', '$injector', 'sessionService'];

    function modifyRequest($rootScope, $injector, sessionService) {
        $injector.get("$http").defaults.transformRequest = function (data, headersGetter) {
            $rootScope.isAjaxLoading = true;

            if (sessionService.isLogged())
                headersGetter()['Authorization'] = "Bearer " + sessionService.getAccessToken();
            if (data) return angular.toJson(data);
        };
    }
})();