(function () {
    'use strict';

    angular.module('RedAlertApp').factory('dashboardService', ['$http', '$q', '$rootScope', 'redAlertConstants', function ($http, $q, $rootScope, redAlertConstants) {

        var serviceBase = redAlertConstants.apiServiceBaseUri;

        //Get
        var _get = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/dashboard').success(function (response) {
                deferred.resolve(response);
            }).catch(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get To Do List 
        var _getToDoList = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/dashboard/GetToDoList').success(function (response) {
                deferred.resolve(response);
            }).catch(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;

        }

        return {
            get: _get,
            getToDoList: _getToDoList

        };
    }]);

}());