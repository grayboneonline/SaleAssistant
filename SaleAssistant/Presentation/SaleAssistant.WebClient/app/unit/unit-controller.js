(function () {
    'use strict';

    angular.module('saleAssistant').controller('unitController', unitController);

    unitController.$inject = ['$scope', 'unitDataService'];

    function unitController($scope, unitDataService) {
        $scope.inTrash = false;
        $scope.items = [];
        $scope.selectedItem = {};

        $scope.init = function () {
            unitDataService.getAll().then(onSuccess, onError);

            function onSuccess(data) {
                $scope.items = data;
                for (var i in $scope.items)
                    $scope.items[i].isEditing = false;
            }
            function onError() {

            }
        }

        $scope.trashFilter = function(item) {
            return item.isTrash === $scope.inTrash;
        }
        
        $scope.noItems = function() {
            if ($scope.inTrash) {
                for (var i in $scope.items) {
                    if($scope.items[i].isTrash)
                        return false;
                }
                return true;
            } else {
                for (var i in $scope.items) {
                    if (!$scope.items[i].isTrash)
                        return false;
                }
                return true;
            }
        }

        $scope.toggleEdit = function(item) {
            if (item.isEditing) {
                item.isEditing = false;
                $scope.selectedItem = {};
                return;
            }

            for (var i in $scope.items)
                $scope.items[i].isEditing = false;

            unitDataService.getById(item.id).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.selectedItem = data;
                item.isEditing = true;
            }
            function onError() {

            }
        };

        $scope.setStatus = function(id, status) {
            unitDataService.setStatus(id, status).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.init();
            }
            function onError() {

            }
        }

        $scope.setTrashStatus = function (id, status) {
            unitDataService.setTrashStatus(id, status).then(onSuccess, onError);

            function onSuccess(data) {
                $scope.init();
            }
            function onError() {

            }
        }

        $scope.update = function(id, item) {
            
        }
    }
})();