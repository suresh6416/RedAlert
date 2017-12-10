angular.module('RedAlertApp').controller('activityInfoController', ['$rootScope', '$scope', '$state', 'toaster', 'activityInfoService', 'dataLookupService', function ($rootScope, $scope, $state, $toaster, activityInfoService, dataLookupService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.ActivitiesInfo = [];
        $scope.ActivityLookup = [];
        $scope.AreaLookup = [];
        $scope.ActivityInfo = new ActivityInfoModel();
        $scope.getAreaLookup();
        $scope.getActivityLookup();
        $scope.isLoading = false;
       
        $scope.SelectedArea = "";
        $scope.SelectedActivity = "";
        $scope.TypeList = ['Open', 'Close'];
        $scope.DueTypeList = ["Days", "Months", "Years"];
        $scope.StatusList = ["Open", "Complete", "Cancel"];
    });

    //Get Area Lookup
    $scope.getAreaLookup = function () {        
        dataLookupService.getAreaLookup().then(function (response) {
            $scope.AreaLookup = response.Data;           
        }, function (err) {
            console.log(err);
        });
    };


    //Get Activity Lookup
    $scope.getActivityLookup = function () {
        dataLookupService.getActivityLookup().then(function (response) {
            $scope.ActivityLookup = response.Data;           
        }, function (err) {
            console.log(err);
        });
    };

    $scope.get = function () {
        activityInfoService.get().then(function (response) {
            $scope.ActivitiesInfo = response.Data;
            $scope.tableParams = new NgTableParams({}, {
                dataset: $scope.ActivitiesInfo
            });
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmActivityInfo.$valid) {
            $scope.ActivityInfo.AreaId = $scope.SelectedArea.ID;
            $scope.ActivityInfo.ActivityId = $scope.SelectedActivity.ID;

            activityInfoService.save($scope.ActivityInfo).then(function (response) {
                $scope.isLoading = false
                $scope.ActivityInfo = new ActivityInfoModel();
                $scope.get();
                toaster.success({ title: "Success", body: "Activity information saved successfully" });
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
        this.Periodicity = "";
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