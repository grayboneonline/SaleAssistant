(function () {
    'use strict';

    angular.module('saleAssistant').controller('unitController', unitController);

    unitController.$inject = ['$scope'];

    function unitController($scope) {
        $scope.items = [
            { id: 1, name: 'kg'    , status: 1 },
            { id: 2, name: 'bottle', status: 1 },
            { id: 3, name: 'ton'   , status: 1 },
            { id: 4, name: 'l'     , status: 1 },
            { id: 5, name: 'ml'    , status: 1 },
            { id: 6, name: 'mg'    , status: 1 }
        ];

        for (var i in $scope.items)
            $scope.items[i].isEditing = false;

        $scope.toggleEdit = function (item) {
            if (item.isEditing) {
                item.isEditing = false;
                return;
            }

            for (var i in $scope.items)
                $scope.items[i].isEditing = false;
            item.isEditing = !item.isEditing;
        };
    }
})();