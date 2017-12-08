angular.module('RedAlertApp').controller('activityInfoController', ['$rootScope', '$scope', '$state', 'toaster', function ($rootScope, $scope, $state,$toaster) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activitiesinfo = [];
        $scope.ActivityInfo = new ActivityInfoModel();
        $scope.getCurrentRecordId();
        $scope.isLoading = true;
       
    });

    $scope.get = function () {
        activityInfoService.get().then(function (response) {
            $scope.Activitiesinfo = response.Data;
            $scope.tableParams = new NgTableParams({}, {
                dataset: $scope.Activitiesinfo
            });
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmActivityInfo.$valid) {
            activityInfoService.save($scope.ActivityInfo).then(function (response) {
                $scope.isLoading = false
                $scope.ActivityInfo.Description = '';
                $scope.ActivityInfo.AreaId = '';
                $scope.ActivityInfo.ActivityId = '';
                $scope.ActivityInfo.Type = '';
                $scope.ActivityInfo.Periodicity = '';
                $scope.ActivityInfo.PeriodicityType = '';
                $scope.ActivityInfo.AdvnaceAlert = '';
                $scope.ActivityInfo.AdvnaceAlertType = '';
                $scope.ActivityInfo.NextDueDate = '';
                $scope.ActivityInfo.StartJobDate = '';
                $scope.ActivityInfo.PreRespPerson = '';
                $scope.ActivityInfo.SecRespPerson = '';
                $scope.ActivityInfo.Status = '';
                $scope.ActivityInfo.UpdatedBy = '';
                $scope.ActivityInfo.UpdatedOn = '';
                $scope.getCurrentRecordId();
                $scope.get();
                toaster.success({ title: "Success", body: "ActivityInfo saved successfully" });
            }, function (err) {
                $scope.isLoading = false
                toaster.error({ title: "Error", body: "Insertion Failed" });
            });
        }
    };

    function AreaModel() {
        this.AreaId = '';
        this.ActivityId = "";
        this.Type = "";
        this.Periodicity = true;
        this.PeriodicityType = "";
        this.AdvnaceAlert = "";
        this.AdvnaceAlertType = "";
        this.NextDueDate = "";
        this.StartJobDate = "";
        this.PreRespPerson = "";
        this.SecRespPerson = "";
        this.Status = "";
        this.UpdatedBy = "";
        this.UpdatedOn = "";
        
    }


}]);