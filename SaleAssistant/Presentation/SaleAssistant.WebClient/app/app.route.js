(function () {
    'use strict';

    angular.module('saleAssistant').config(configureRoutes);

    configureRoutes.$inject = ['$routeProvider'];

    function configureRoutes($routeProvider, $locationProvider) {

        //var routeProvider = angular.extend({}, $routeProvider, {
        //    when: function (path, route) {
        //        route.resolve = (route.resolve) ? route.resolve : {};
        //        angular.extend(route.resolve, { appStart: ['appStartService', function (appStartService) { return appStartService.start(path); }] });
        //        $routeProvider.when(path, route);
        //        return this;
        //    }
        //});

        $routeProvider
            .when('/', { templateUrl: '/app/home/homeView.html', controller: 'homeController', controllerAs: 'homeCtrl' })
            .when('/Login', { templateUrl: '/app/login/loginView.html', controller: 'loginController', controllerAs: 'loginCtrl', caseInsensitiveMatch: true })
            .when('/Unit', { templateUrl: '/app/unit/unitView.html', controller: 'unitController', controllerAs: 'unitCtrl', caseInsensitiveMatch: true })
            //.when('/Question-And-Answer/:categoryOrder', { templateUrl: '../Areas/N/App/personalisation/questionAndAnswer/questionAndAnswer.html', controller: 'questionAndAnswerController', controllerAs: 'questionAndAnswer' })
            //.when('/Summary', { templateUrl: '../Areas/N/App/personalisation/summary/summary.html', controller: 'summaryController', controllerAs: 'summary' })
            .otherwise({ redirectTo: '/' });
    };

})();
