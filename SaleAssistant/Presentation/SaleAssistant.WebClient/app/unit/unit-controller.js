(function () {
    'use strict';

    angular.module('saleAssistant').controller('unitController', unitController);

    unitController.$inject = ['$scope', 'unitDataService'];

    function unitController($scope, unitDataService) {
        $scope.getAllPromise = unitDataService.getAll;
        $scope.getByIdPromise = unitDataService.getById;
        $scope.setStatusPromise = unitDataService.setStatus;
        $scope.setTrashStatusPromise = unitDataService.setTrashStatus;
        $scope.updatePromise = unitDataService.update;
        $scope.addPromise = unitDataService.add;
    }
})();