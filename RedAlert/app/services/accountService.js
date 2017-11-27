(function () {
    'use strict';

    angular.module('RedAlertApp').factory('accountService', ['$http', '$q', '$rootScope', 'redAlertConstants', function ($http, $q, $rootScope, redAlertConstants) {

        var serviceBase = redAlertConstants.apiServiceBaseUri;

        //Login
        var _login = function (user) {
            var deferred = $q.defer();
            var userData = "grant_type=password&username=" + user.UserName + "&password=" + user.Password;

            $http.post(serviceBase + '/token', userData, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };


        return {
            login: _login
        };

    }]);
}());

