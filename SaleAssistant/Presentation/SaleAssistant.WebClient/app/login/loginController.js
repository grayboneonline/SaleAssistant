(function () {
    'use strict';

    angular.module('saleAssistant').controller('loginController', loginController);

    loginController.$inject = ['$scope'];

    function loginController($scope) {
        $scope.username = 'aaa';
        $scope.password = 'nnn';
    }
})();