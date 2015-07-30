(function () {
    'use strict';

    angular.module('saleAssistant').controller('inventoryItemController', inventoryItemController);

    inventoryItemController.$inject = ['$scope', 'inventoryItemDataService'];

    function inventoryItemController($scope, inventoryItemDataService) {
        $scope.items = [];
        $scope.selectedItem = {};
        $scope.isAdding = false;

        $scope.init = function () {
            inventoryItemDataService.getAll().then(onSuccess, onError);

            function onSuccess(data) {
                $scope.items = data;
                cancelEdit();
                cancelAdd();
            }
            function onError() {

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

            inventoryItemDataService.getById(item.id).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.selectedItem = data;
                item.isEditing = true;
            }
            function onError() {

            }
        };

        $scope.toggleAdd = function () {
            cancelEdit();
            $scope.isAdding = !$scope.isAdding;
            $scope.selectedItem = {};
        }

        $scope.update = function () {
            inventoryItemDataService.update($scope.selectedItem.id, $scope.selectedItem).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.init();
            }
            function onError() {
            }
        }

        $scope.add = function () {
            inventoryItemDataService.add($scope.selectedItem).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.init();
            }
            function onError() {
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