(function () {
    'use strict';

    angular.module('saleAssistant').factory('inventoryItemDataService', inventoryItemDataService);

    inventoryItemDataService.$inject = ['$q', 'saHttpService'];

    function inventoryItemDataService($q, saHttpService) {
        var serviceBase = 'api/inventoryitems/';
        var service = {
            getAll: getAll,
            getById: getById,
            update: update,
            add: add,
            del: del,
        };

        return service;

        function getAll() {
            return saHttpService.get(serviceBase);
        }

        function getById(id) {
            return saHttpService.get(serviceBase + id);
        }
        
        function update(id, item) {
            return saHttpService.put(serviceBase + id, item);
        }

        function add(item) {
            return saHttpService.post(serviceBase, item);
        }

        function del(id) {
            return saHttpService.del(serviceBase + id);
        }
    }
})();
