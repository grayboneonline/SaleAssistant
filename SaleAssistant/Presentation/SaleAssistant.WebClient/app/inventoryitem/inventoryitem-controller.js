(function () {
    'use strict';

    angular.module('saleAssistant').controller('inventoryItemController', inventoryItemController);

    inventoryItemController.$inject = ['$scope', 'inventoryItemDataService', 'productDataService'];

    function inventoryItemController($scope, inventoryItemDataService, productDataService) {
        $scope.items = [];
        $scope.selectedItem = {};
        $scope.isAdding = false;
        $scope.products = [];

        $scope.init = function () {
            inventoryItemDataService.getAll().then(onSuccess);

            function onSuccess(data) {
                $scope.items = data;
                productDataService.getAll().then(function(productData) {
                    $scope.products = productData;
                });
                cancelEdit();
                cancelAdd();
            }
        }

        $scope.noItems = function () {
            return $scope.items.length == 0;
        }

        $scope.toggleEdit = function (item) {
            if (item.isEditing) {
                item.isEditing = false;
                $scope.selectedItem = {};
                return;
            }

            cancelEdit();
            cancelAdd();

            inventoryItemDataService.getById(item.id).then(onSuccess);

            function onSuccess(data) {
                $scope.selectedItem = data;
                item.isEditing = true;
            }
        };

        $scope.toggleAdd = function () {
            cancelEdit();
            $scope.isAdding = !$scope.isAdding;
            $scope.selectedItem = {};
        }

        $scope.update = function () {
            inventoryItemDataService.update($scope.selectedItem.id, $scope.selectedItem).then(onSuccess);

            function onSuccess(data) {
                $scope.init();
            }
        }

        $scope.add = function () {
            inventoryItemDataService.add($scope.selectedItem).then(onSuccess);

            function onSuccess(data) {
                $scope.init();
            }
        }

        $scope.del = function(id) {
            inventoryItemDataService.del(id).then(onSuccess);

            function onSuccess(data) {
                $scope.init();
            }
        }

        function cancelEdit() {
            for (var i in $scope.items)
                $scope.items[i].isEditing = false;
        }
        function cancelAdd() {
            $scope.isAdding = false;
        }
    }
})();