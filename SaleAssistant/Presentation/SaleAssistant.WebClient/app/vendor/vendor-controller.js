(function () {
    'use strict';

    angular.module('saleAssistant').controller('vendorController', vendorController);

    vendorController.$inject = ['$scope', 'vendorDataService'];

    function vendorController($scope, vendorDataService) {
        $scope.getAllPromise = vendorDataService.getAll;
        $scope.getByIdPromise = vendorDataService.getById;
        $scope.setStatusPromise = vendorDataService.setStatus;
        $scope.setTrashStatusPromise = vendorDataService.setTrashStatus;
        $scope.updatePromise = vendorDataService.update;
        $scope.addPromise = vendorDataService.add;
    }
})();