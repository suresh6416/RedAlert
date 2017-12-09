angular.module('RedAlertApp').controller('activityInfoController', ['$rootScope', '$scope', '$state', 'toaster', 'activityInfoService', 'dataLookupService', function ($rootScope, $scope, $state, $toaster, activityInfoService, dataLookupService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activitiesinfo = [];
        $scope.ActivityLookup = [];
        $scope.AreaLookup = [];
        $scope.ActivityInfo = new ActivityInfoModel();
        $scope.getAreaLookup();
        $scope.isLoading = true;
       
    });

    //Get Area Lookup
    $scope.getAreaLookup = function () {
        console.log(1);
        dataLookupService.getAreaLookup().then(function (response) {
        console.log(2);
            $scope.AreaLookup = response.Data;
            _.map($scope.AreaLookup, function (data) {
                data.AreaId = data.ID;
            });
        }, function (err) {
            console.log(err);
        });
    };


    //Get Activity Lookup
    $scope.getActivityLookup = function () {
        dataLookupService.getActivityLookup().then(function (response) {
            $scope.ActivityLookup = response.Data;
            _.map($scope.ActivityLookup, function (data) {
                data.ActivityId = data.ID;
            });
        }, function (err) {
            console.log(err);
        });
    };

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

    function ActivityInfoModel() {
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