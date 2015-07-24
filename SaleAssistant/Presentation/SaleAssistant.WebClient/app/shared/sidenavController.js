(function () {
    'use strict';

    angular.module('saleAssistant').controller('sidenavController', sidenavController);

    sidenavController.$inject = ['$scope', '$mdSidenav', '$location'];

    function sidenavController($scope, $mdSidenav, $location) {

        $scope.menus = [
            { name: 'Unit', url: '/Unit' },
            { name: 'Product', url: '/Product' },
            { name: 'Product Pricing', url: '/ProductPricing' },
            { name: 'Inventory', url: '/Inventory' },
            { name: 'Customer', url: '/Customer' },
            { name: 'Vendor', url: '/Vendor' }
        ];

        $scope.navigateTo = function (path) {
            $location.path(path);
            $scope.close();
        };

        $scope.close = function () {
            $mdSidenav('left').close();
        };
    }    
})();