(function () {
    'use strict';

    angular.module('saleAssistant').controller('productController', productController);

    productController.$inject = ['$scope', 'productDataService', 'unitDataService'];

    function productController($scope, productDataService, unitDataService) {
        $scope.getAllPromise = productDataService.getAll;
        $scope.getByIdPromise = productDataService.getById;
        $scope.setStatusPromise = productDataService.setStatus;
        $scope.setTrashStatusPromise = productDataService.setTrashStatus;
        $scope.updatePromise = productDataService.update;
        $scope.addPromise = productDataService.add;

        $scope.units = [];
        $scope.loadData = function() {
            unitDataService.getAll().then(onSuccess, onError);

            function onSuccess(data) {
                $scope.units = data;
            }
            function onError() {

            }
        }
    }
})();