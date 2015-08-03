(function () {
    'use strict';

    angular.module('saleAssistant').directive('saAdminTile', saAdminTile);

    function saAdminTile() {
        var directive = {
            restrict: 'E',
            transclude: true,
            templateUrl: 'app/shared/directives/sa-admin-tile-directive.html',
            controller: controller
        };

        return directive;

        function controller($scope, $element, $attrs) {
            $scope.header = $attrs.header;
            $scope.inTrash = false;
            $scope.items = [];
            $scope.selectedItem = {};
            $scope.isAdding = false;
            $scope.editForm = {};

            $scope.init = function () {
                $scope.getAllPromise().then(onSuccess, onError);

                function onSuccess(data) {
                    $scope.items = data;
                    if ($scope.loadData)
                        $scope.loadData();
                    cancelEdit();
                    cancelAdd();
                }
                function onError() {

                }
            }

            $scope.trashFilter = function (item) {
                return item.isTrash === $scope.inTrash;
            }

            $scope.noItems = function () {
                if ($scope.inTrash) {
                    for (var i in $scope.items) {
                        if ($scope.items[i].isTrash)
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

            $scope.toggleEdit = function (item) {
                if (item.isEditing) {
                    item.isEditing = false;
                    $scope.selectedItem = {};
                    return;
                }

                cancelEdit();
                cancelAdd();

                $scope.getByIdPromise(item.id).then(onSuccess, onError);

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

            $scope.setStatus = function (item) {
                $scope.setStatusPromise(item.id, !item.status ? 1 : 0).then(onSuccess, onError);

                function onSuccess(data) {
                    $scope.init();
                }
                function onError() {

                }
            }

            $scope.setTrashStatus = function (item) {
                $scope.setTrashStatusPromise(item.id, !item.isTrash).then(onSuccess, onError);

                function onSuccess(data) {
                    $scope.init();
                }
                function onError() {

                }
            }

            $scope.update = function () {
                if (!$scope.editForm.$valid)
                    return;

                $scope.updatePromise($scope.selectedItem.id, $scope.selectedItem).then(onSuccess, onError);

                function onSuccess(data) {
                    $scope.init();
                }
                function onError() {
                    var a = 0;
                }
            }

            $scope.add = function () {
                if (!$scope.editForm.$valid)
                    return;

                $scope.addPromise($scope.selectedItem).then(onSuccess, onError);

                function onSuccess(data) {
                    $scope.init();
                }
                function onError() {
                    var a = 0;
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
    }
})();
