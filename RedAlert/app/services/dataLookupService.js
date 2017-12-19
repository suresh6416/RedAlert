(function () {
    'use strict';

    angular.module('RedAlertApp').factory('dataLookupService', ['$http', '$q', '$rootScope', 'redAlertConstants', function ($http, $q, $rootScope, redAlertConstants) {
        var serviceBase = redAlertConstants.apiServiceBaseUri;   


        //Get Area Lookup
        var _getAreaLookup = function () {
            var deferred = $q.defer();
            console.log("In data look up service");
            $http.get(serviceBase + '/api/DataLookup/AreaLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };      

        //Get Activity Lookup
        var _getActivityLookup = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + '/api/DataLookup/ActivityLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Users Lookup
        var _getUsersLookup = function () {
            var deferred = $q.defer();
            console.log("In lookup service");
            $http.get(serviceBase + '/api/DataLookup/UsersLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {
            getAreaLookup: _getAreaLookup,
            getActivityLookup: _getActivityLookup,
            getUsersLookup: _getUsersLookup
        };

    }]);

})();