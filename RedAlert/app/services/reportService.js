(function () {
    'use strict';

    angular.module('RedAlertApp').factory('reportService', ['$http', '$q', '$rootScope', 'redAlertConstants', function ($http, $q, $rootScope, redAlertConstants) {

        var serviceBase = redAlertConstants.apiServiceBaseUri;

        //Login
        var _report = function (data) {
            var deferred = $q.defer();
            $http({
                url: serviceBase + '/api/Report',
                method: "POST",
                data: JSON.stringify(data)
            })
             .then(function (response) {
                 deferred.resolve(response);
             },
             function (err, status) { // optional
                 deferred.reject(err);
             });            

            return deferred.promise;
        };

        var _areas = function () {
            var deferred = $q.defer();
            $http({
                url: serviceBase + '/api/Area',
                method: "GET",
                //data: JSON.stringify(data)
            })
             .then(function (response) {
                 deferred.resolve(response);
             },
             function (err, status) { // optional
                 deferred.reject(err);
             });

            return deferred.promise;
        };

        return {
            report: _report,
            areas: _areas
        };

    }]);
}());

