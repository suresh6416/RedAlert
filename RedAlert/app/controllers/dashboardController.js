angular.module('RedAlertApp').controller('dashboardController', ['$rootScope', '$scope', '$state','dashboardService', function ($rootScope, $scope, $state,dashboardService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.ActivitiesProgress = [];
        $scope.get();
    });

    $scope.get = function () {
        dashboardService.get().then(function (response) {
            $scope.ActivitiesProgress = response.Data;
        }, function (err) {
            console.log(err);
        });
    };
}]);

