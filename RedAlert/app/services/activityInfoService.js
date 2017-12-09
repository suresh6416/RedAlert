(function () {
    'use strict';
    angular.module('RedAlertApp').factory('activityInfoService', ['$http', '$q', '$rootScope', 'redAlertConstants', function ($http, $q, $rootScope, redAlertConstants) {
        var serviceBase = redAlertConstants.apiServiceBaseUri;
   
        //Get

        var _get = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/activityInfo').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Save
        var _save = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + '/api/activityInfo', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Activity By ID
        var _getById = function (id) {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/activityInfo/GetById/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Current Record Id
        var _getCurrentRecordId = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/activityInfo/GetCurrentRecordId').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };


         return {
            get: _get,
            save: _save,          
            getById: _getById,
            getCurrentRecordId: _getCurrentRecordId
        };



    }])
    })();