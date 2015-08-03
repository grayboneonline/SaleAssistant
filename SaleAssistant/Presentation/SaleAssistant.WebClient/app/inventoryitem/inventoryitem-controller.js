(function () {
    'use strict';

    angular.module('saleAssistant').controller('inventoryItemController', inventoryItemController);

    inventoryItemController.$inject = ['$scope', 'inventoryItemDataService', '$q'];

    function inventoryItemController($scope, inventoryItemDataService, $q) {
        $scope.items = [];
        $scope.selectedItem = {};
        $scope.isAdding = false;
        $scope.products = [];
        $scope.editForm = {};

        $scope.init = function () {
            var inventoryItems = inventoryItemDataService.getAll();
            var products = inventoryItemDataService.getRemainProduct();

            $q.all([inventoryItems, products]).then(function(data) {
                $scope.items = data[0];
                $scope.products = data[1];
                cancelEdit();
                cancelAdd();
            });
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
            if (!$scope.editForm.$valid)
                return;

            inventoryItemDataService.update($scope.selectedItem.id, $scope.selectedItem).then(onSuccess);

            function onSuccess(data) {
                $scope.init();
            }
        }

        $scope.add = function () {
            if (!$scope.editForm.$valid)
                return;

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

        $scope.setEditForm = function(form) {
            $scope.editForm = form;
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