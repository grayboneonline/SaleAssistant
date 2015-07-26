(function () {
    'use strict';

    angular.module('saleAssistant').factory('saHttpService', saHttpService);

    saHttpService.$inject = ['$http', '$q'];

    function saHttpService($http, $q) {
        var baseUrl = 'http://localhost/SaleAssistant.WebApi/';
        var service = {
            get: get,
            post: post,
            postAsFormData: postAsFormData
        }

        return service;

        function get(url, params) {
            var deferred = $q.defer();
            var options = { async: true };

            angular.extend(options, { params: params });

            $http.get(baseUrl + url, options)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject({ data: data, status: status });
                });

            return deferred.promise;
        }

        function post(url, data) {
            var deferred = $q.defer();

            $http.post(baseUrl + url, data, { async: true })
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject({ data: data, status: status });
                });

            return deferred.promise;
        }

        function postAsFormData(url, data) {
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: baseUrl + url,
                data: data,
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
            }).success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject({ data: data, status: status });
            });
            return deferred.promise;
        }
    }
})();