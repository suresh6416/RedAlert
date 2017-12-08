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




    }])
    })();