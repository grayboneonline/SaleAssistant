(function () {
    'use strict';

    angular.module('saleAssistant').directive('saTile', saTile);

    function saTile() {
        var directive = {
            restrict: 'E',
            templateUrl: 'app/shared/directives/saTileDirective.html',
            controller: function ($scope) {
                for (var i in $scope.items)
                    $scope.items[i].isEditing = false;

                $scope.toggleEdit = function (item) {
                    item.isEditing = !item.isEditing;
                };
            }
        };

        return directive;
    }
})();
