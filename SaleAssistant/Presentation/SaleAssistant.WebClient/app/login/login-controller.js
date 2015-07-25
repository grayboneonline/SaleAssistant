(function () {
    'use strict';

    angular.module('saleAssistant').controller('loginController', loginController);

    loginController.$inject = ['$scope', 'loginService'];

    function loginController($scope, loginService) {
        $scope.login = function() {
            loginService.login($scope.username, $scope.password);
        }
    }
})();