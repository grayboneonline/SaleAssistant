(function () {
    'use strict';

    angular.module('saleAssistant').controller('sidenavController', sidenavController);

    sidenavController.$inject = ['$scope', '$mdSidenav', '$location'];

    function sidenavController($scope, $mdSidenav, $location) {

        $scope.menus2 = [
            {
                name: 'Admin',
                type: 0,
                url: '#/',
                submenus: [
                    { name: 'Unit', url: '#/Unit' },
                    { name: 'Product', url: '#/Product' },
                    { name: 'Product Pricing', url: '#/ProductPricing' },
                    //{ name: 'Inventory', url: '#/Inventory' },
                    { name: 'Inventory Item', url: '#/InventoryItem' },
                    { name: 'Customer', url: '#/Customer' },
                    { name: 'Vendor', url: '#/Vendor' }
                ]
            },
            {
                name: 'SalesOrder',
                type: 1,
                url: '#/SalesOrder',
                submenus: []
            }
        ];

        $scope.close = function () {
            $mdSidenav('left').close();
        };
    }    
})();