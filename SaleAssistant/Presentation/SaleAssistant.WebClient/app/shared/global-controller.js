(function () {
    'use strict';

    angular.module('saleAssistant').controller('globalController', globalController);

    globalController.$inject = ['$rootScope', '$scope', '$mdSidenav', '$mdUtil', '$location'];

    function globalController($rootScope, $scope, $mdSidenav, $mdUtil, $location) {
        $scope.toggleLeft = function() {
            $mdSidenav('left').toggle();
        }//buildToggler('left');

        $scope.menus = [
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

        function buildToggler(navId) {
            var debounceFn = $mdUtil.debounce(function () {
                $mdSidenav(navId).toggle();
            }, 300);
            return debounceFn;
        }

        $scope.showSidenav = function() {
            if ($location.path().toUpperCase() !== '/login'.toUpperCase())
                return true;

            return false;
        }
    }
})();