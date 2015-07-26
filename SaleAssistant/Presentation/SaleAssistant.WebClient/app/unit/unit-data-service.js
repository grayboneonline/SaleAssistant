(function () {
    'use strict';

    angular.module('saleAssistant').factory('unitDataService', unitDataService);

    unitDataService.$inject = ['$q', 'saHttpService'];

    function unitDataService($q, saHttpService) {
        var serviceBase = 'api/units/';
        var service = {
            getAll: getAll,
            getById: getById,
            setStatus: setStatus,
            setTrashStatus: setTrashStatus,
        };

        return service;

        function getAll() {
            return saHttpService.get(serviceBase);
        }

        function getById(id) {
            return saHttpService.get(serviceBase + id);
        }

        function setStatus(id, status) {
            return saHttpService.put(serviceBase + id + '/updatestatus/' + status);
        }

        function setTrashStatus(id, status) {
            return saHttpService.put(serviceBase + id + '/updatetrashstatus/' + status);
        }
    }
})();
