(function () {
    'use strict';

    angular.module('saleAssistant').config(configureRoutes);

    configureRoutes.$inject = ['$routeProvider'];

    function configureRoutes($routeProvider) {

        $routeProvider
            .when('/', { templateUrl: 'app/home/home-view.html', controller: 'homeController', controllerAs: 'homeCtrl' })
            .when('/login', { templateUrl: 'app/login/login-view.html', controller: 'loginController', controllerAs: 'loginCtrl', caseInsensitiveMatch: true })
            .when('/unit', { templateUrl: 'app/unit/unit-view.html', controller: 'unitController', controllerAs: 'unitCtrl', caseInsensitiveMatch: true })
            //.when('/Question-And-Answer/:categoryOrder', { templateUrl: '../Areas/N/App/personalisation/questionAndAnswer/questionAndAnswer.html', controller: 'questionAndAnswerController', controllerAs: 'questionAndAnswer' })
            //.when('/Summary', { templateUrl: '../Areas/N/App/personalisation/summary/summary.html', controller: 'summaryController', controllerAs: 'summary' })
            .otherwise({ redirectTo: '/' });
    };

})();
