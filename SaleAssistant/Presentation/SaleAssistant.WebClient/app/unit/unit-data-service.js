(function () {
    'use strict';

    angular.module('saleAssistant').factory('unitDataService', unitDataService);

    unitDataService.$inject = ['$q', 'saHttpService'];

    function unitDataService($q, saHttpService) {
        var serviceBase = 'api/units/';
        //var baseUrl = '/api/units/';
        var service = {
            //units: {},
            //introduction: {},
            getAll: getAll,
            //updateSelectedAnswer: updateSelectedAnswer,
            //updateStatus: updateStatus,
            //updateActiveCategory: updateActiveCategory
        };

        return service;

        function getAll() {
            return saHttpService.get(serviceBase);
            //var deferred = $q.defer();

            //var loadConfig = saHttpService.get(serviceBase + 'Load');
            //var loadIntroduction = $q.when(introduction());

            //$q.all([loadConfig, loadIntroduction]).then(function (result) {
            //    service.data = result[0];
            //    service.introduction = result[1];

            //    deferred.resolve();
            //});

            //return deferred.promise;
        }

        //function updateSelectedAnswer(questionId, answerIds) {
        //    return saHttpService.post(baseUrl + '/UpdateSelectedAnswer', { questionID: questionId, answerIDs: answerIds });
        //}

        //function updateStatus(status) {
        //    return saHttpService.post(baseUrl + '/UpdateStatus', { status: status });
        //}

        //function updateActiveCategory(activeCategoryID) {
        //    return saHttpService.post(baseUrl + '/UpdateActiveCategory', { activeCategoryID: activeCategoryID });
        //}
    }
})();
