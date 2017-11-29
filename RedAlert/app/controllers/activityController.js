angular.module('RedAlertApp').controller('activityController', ['$rootScope', '$scope', '$state', 'activityService', 'toaster', function ($rootScope, $scope, $state, activityService, toaster) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activities = [];
        $scope.Activity = "";
        $scope.CurrentActivityId = 0;
        $scope.getCurrentRecordId();
        $scope.isLoading = false
    });

    $scope.get = function () {
        activityService.get().then(function (response) {
            $scope.Activities = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmActivity.$valid) {
            activityService.save($scope.Activity).then(function (response) {
                $scope.isLoading = false
                $scope.Activity.Name = '';
                $scope.getCurrentRecordId();
                toaster.success({ title: "Success", body: "Activity saved successfully" });
            }, function (err) {
                $scope.isLoading = false
                toaster.error({ title: "Error", body: "Insertion Failed" });
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