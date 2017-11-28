angular.module('RedAlertApp').controller('activityController', ['$rootScope', '$scope', '$state', 'activityService', function ($rootScope, $scope, $state, activityService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activities = [];
        $scope.Activity = "";
        $scope.CurrentActivityId = 0;
    });

    $scope.get = function () {
        activityService.get().then(function (response) {
            $scope.Activities = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        if ($scope.frmActivity.$valid) {
            activityService.save($scope.Activity).then(function (response) {
                $scope.get();
                toaster.success({ title: "Success", body: "Activity saved successfully" });
            }, function (err) {
                console.log(err);
            });
        }
    };

    $scope.getById = function (activity) {
        activityService.getById(activity.ID).then(function (response) {
            $scope.Activity = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getCurrentRecordId = function () {
        activityService.getCurrentRecordId().then(function (response) {
            $scope.CurrentActivityId = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

}]);