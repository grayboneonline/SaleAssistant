(function () {
    'use strict';

    angular.module('saleAssistant').controller('inventoryController', inventoryController);

    inventoryController.$inject = ['$scope', 'inventoryDataService'];

    function inventoryController($scope, inventoryDataService) {
        $scope.getAllPromise = inventoryDataService.getAll;
        $scope.getByIdPromise = inventoryDataService.getById;
        $scope.setStatusPromise = inventoryDataService.setStatus;
        $scope.setTrashStatusPromise = inventoryDataService.setTrashStatus;
        $scope.updatePromise = inventoryDataService.update;
        $scope.addPromise = inventoryDataService.add;
    }
})();