(function () {
    'use strict';

    angular.module('saleAssistant').config(configureRoutes);

    configureRoutes.$inject = ['$routeProvider'];

    function configureRoutes($routeProvider) {

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

})();
