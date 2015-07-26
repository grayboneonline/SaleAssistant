(function () {
    'use strict';

    angular.module('saleAssistant').controller('loginController', loginController);

    loginController.$inject = ['$scope', 'loginService', 'sessionService', '$location'];

    function loginController($scope, loginService, sessionService, $location) {
        $scope.errorMessage = '';
        $scope.login = function () {
            if (!$scope.loginForm.$valid)
                return;

            loginService.login($scope.username, $scope.password).then(onSuccess, onError);

            function onSuccess(data) {
                sessionService.setAccessToken(data.access_token);
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