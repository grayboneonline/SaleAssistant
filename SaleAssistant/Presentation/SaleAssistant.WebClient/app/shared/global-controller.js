(function () {
    'use strict';

    angular.module('saleAssistant').controller('globalController', globalController);

    globalController.$inject = ['$rootScope', '$scope', '$mdSidenav', '$mdUtil', '$location'];

    function globalController($rootScope, $scope, $mdSidenav, $mdUtil, $location) {
        $scope.showSidenav = true;
        $scope.toggleLeft = buildToggler('left');

        function buildToggler(navId) {
            var debounceFn = $mdUtil.debounce(function () {
                $mdSidenav(navId).toggle();
            }, 300);
            return debounceFn;
        }

        $rootScope.$on('$locationChangeSuccess', function () {
            if ($location.path().toUpperCase() !== '/login'.toUpperCase())
                $scope.showSidenav = true;
            else
                $scope.showSidenav = false;
        });
    }
})();