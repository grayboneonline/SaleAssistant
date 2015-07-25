(function () {
    'use strict';

    angular.module('saleAssistant').controller('globalController', globalController);

    globalController.$inject = ['$scope', '$mdSidenav', '$mdUtil'];

    function globalController($scope, $mdSidenav, $mdUtil) {
        $scope.toggleLeft = buildToggler('left');

        function buildToggler(navId) {
            var debounceFn = $mdUtil.debounce(function () {
                $mdSidenav(navId)
                  .toggle();
            }, 300);
            return debounceFn;
        }
    }
})();