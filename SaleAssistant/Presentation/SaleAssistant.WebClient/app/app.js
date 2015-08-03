(function () {
    'use strict';

    /* create module */
    var app = angular.module('saleAssistant', ['ngRoute', 'ngMaterial', 'ngMessages', 'ngStorage', 'http-auth-interceptor']);
    
    /* app factories */
    app.factory('httpInterceptor', httpInterceptor);

    httpInterceptor.$inject = ['$q', '$location', '$rootScope', 'saSessionService'];

    function httpInterceptor($q, $location, $rootScope, saSessionService) {
        return {
            request: function ($config) {
                $rootScope.isAjaxLoading = true;
                if (saSessionService.getAccessToken()) {
                    $config.headers['Authorization'] = "Bearer " + saSessionService.getAccessToken();
                }
                return $config;
            },
            response: function (response) {
                $rootScope.isAjaxLoading = false;
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                $rootScope.isAjaxLoading = false;
                return $q.reject(rejection);
            }
        }
    }

    /* app config */
    app.config(appConfig);

    appConfig.$inject = ['$routeProvider', '$httpProvider'];

    function appConfig($routeProvider, $httpProvider) {
        $httpProvider.interceptors.push('httpInterceptor');

        $routeProvider
            .when('/', { templateUrl: 'app/home/home-view.html', controller: 'homeController', controllerAs: 'homeCtrl' })
            .when('/login', { templateUrl: 'app/login/login-view.html', controller: 'loginController', controllerAs: 'loginCtrl', caseInsensitiveMatch: true })
            .when('/unit', { templateUrl: 'app/unit/unit-view.html', controller: 'unitController', controllerAs: 'unitCtrl', caseInsensitiveMatch: true })
            .when('/product', { templateUrl: 'app/product/product-view.html', controller: 'productController', controllerAs: 'productCtrl', caseInsensitiveMatch: true })
            //.when('/inventory', { templateUrl: 'app/inventory/inventory-view.html', controller: 'inventoryController', controllerAs: 'inventoryCtrl', caseInsensitiveMatch: true })
            .when('/inventoryitem', { templateUrl: 'app/inventoryitem/inventoryitem-view.html', controller: 'inventoryItemController', controllerAs: 'inventoryItemCtrl', caseInsensitiveMatch: true })
            .when('/vendor', { templateUrl: 'app/vendor/vendor-view.html', controller: 'vendorController', controllerAs: 'vendorCtrl', caseInsensitiveMatch: true })
            .when('/customer', { templateUrl: 'app/customer/customer-view.html', controller: 'customerController', controllerAs: 'customerCtrl', caseInsensitiveMatch: true })
            .otherwise({ redirectTo: '/' });
    };
    
    /* app run */
    app.run(eventHandler);

    eventHandler.$inject = ['$rootScope', '$injector', 'saSessionService', 'authService', '$location', 'loginService'];

    function eventHandler($rootScope, $injector, saSessionService, authService, $location, loginService) {

        $rootScope.$on('event:auth-loginRequired', function () {
            if (!$rootScope.isRefreshingToken) {
                $rootScope.isRefreshingToken = true;
                loginService.refreshAccessToken(saSessionService.getRefreshToken(), saSessionService.getClientId()).then(onSuccess, onError);
            }

            function onSuccess(data) {
                $rootScope.isRefreshingToken = false;
                saSessionService.setAccessToken(data.access_token);
                saSessionService.setRefreshToken(data.refresh_token);
                authService.loginConfirmed();
            }
            function onError() {
                $rootScope.isRefreshingToken = false;
                saSessionService.setAccessToken(undefined);
                saSessionService.setRefreshToken(undefined);
                $location.path('/login');
            }
        });
    }
})();
