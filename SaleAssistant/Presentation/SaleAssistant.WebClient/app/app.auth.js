(function () {
    'use strict';

    angular.module('saleAssistant').config(responseInterceptor).run(addAuthorizationHeader);

    responseInterceptor.$inject = ['$httpProvider'];

    function responseInterceptor($httpProvider) {
        $httpProvider.interceptors.push('saResponseInterceptorService');
    }

    addAuthorizationHeader.$inject = ['$rootScope', '$injector', 'sessionService'];

    function addAuthorizationHeader($rootScope, $injector, sessionService) {
        $injector.get("$http").defaults.transformRequest = function (data, headersGetter) {
            if (sessionService.isLogged())
                headersGetter()['Authorization'] = "Bearer " + sessionService.getAccessToken();
            if (data) return angular.toJson(data);
        };
    }
})();
