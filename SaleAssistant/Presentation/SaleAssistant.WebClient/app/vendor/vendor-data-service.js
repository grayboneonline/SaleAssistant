(function () {
    'use strict';

    angular.module('saleAssistant').factory('vendorDataService', vendorDataService);

    vendorDataService.$inject = ['$q', 'saHttpService'];

    function vendorDataService($q, saHttpService) {
        var serviceBase = 'api/vendors/';
        var service = {
            getAll: getAll,
            getAllVisible: getAllVisible,
            getById: getById,
            setStatus: setStatus,
            setTrashStatus: setTrashStatus,
            update: update,
            add: add,
        };

        return service;

        function getAll() {
            return saHttpService.get(serviceBase);
        }

        function getAllVisible() {
            return saHttpService.get(serviceBase + 'visible');
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
        
        function update(id, item) {
            return saHttpService.put(serviceBase + id, item);
        }

        function add(item) {
            return saHttpService.post(serviceBase, item);
        }
    }
})();
