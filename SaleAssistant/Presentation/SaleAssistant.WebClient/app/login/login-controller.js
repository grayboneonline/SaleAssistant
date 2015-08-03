(function () {
    'use strict';

    angular.module('saleAssistant').controller('loginController', loginController);

    loginController.$inject = ['$scope', 'loginService', 'saSessionService', '$location'];

    function loginController($scope, loginService, saSessionService, $location) {
        $scope.errorMessage = '';
        $scope.login = function () {
            if (!$scope.loginForm.$valid)
                return;

            loginService.login($scope.username, $scope.password, saSessionService.getClientId()).then(onSuccess, onError);

            function onSuccess(data) {
                saSessionService.setAccessToken(data.access_token);
                saSessionService.setRefreshToken(data.refresh_token);
                $location.path('/');
            }
            function onError(data) {
                var error = data.data;
                $scope.errorMessage = error.error_description;
                $scope.loginForm.password.$setValidity("passwordCheck", false);
            }
        }
    }
})();