(function () {
    'use strict';

    angular.module('saleAssistant').controller('customerController', customerController);

    customerController.$inject = ['$scope', 'customerDataService'];

    function customerController($scope, customerDataService) {
        $scope.getAllPromise = customerDataService.getAll;
        $scope.getByIdPromise = customerDataService.getById;
        $scope.setStatusPromise = customerDataService.setStatus;
        $scope.setTrashStatusPromise = customerDataService.setTrashStatus;
        $scope.updatePromise = customerDataService.update;
        $scope.addPromise = customerDataService.add;
    }
})();