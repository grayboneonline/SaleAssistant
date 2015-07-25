(function () {
    'use strict';

    angular.module('saleAssistant').config(responseInterceptor).run(addAuthorizationHeader);

    responseInterceptor.$inject = ['$httpProvider'];

    function responseInterceptor($httpProvider) {
        $httpProvider.interceptors.push('saResponseInterceptorService');
    }

    addAuthorizationHeader.$inject = ['$rootScope', '$injector'];

    function addAuthorizationHeader($rootScope, $injector) {
        //$injector.get("$http").defaults.transformRequest = function (data, headersGetter) {
        //    if (sessionService.isLogged()) {
        //        headersGetter()['Authorization'] = "Bearer " + sessionService.getAccessToken();
        //    }
        //    if (data) {
        //        return angular.toJson(data);
        //    }
        //};
        $injector.get("$http").defaults.transformRequest = function (data, headersGetter) {
            if ($rootScope.oauth)
                headersGetter()['Authorization'] = "Bearer " + $rootScope.oauth.access_token;
            if (data) return angular.toJson(data);
        };
    }
})();
