(function () {
    'use strict';

    angular.module('saleAssistant').factory('saResponseInterceptorService', saResponseInterceptorService);

    saResponseInterceptorService.$inject = ['$q', '$window', '$location'];

    function saResponseInterceptorService($q, $window, $location) {
        return {
            response: function (response) {
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
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
})();