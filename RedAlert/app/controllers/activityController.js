angular.module('RedAlertApp').controller('activityController', ['$rootScope', '$scope', '$state', 'activityService', 'toaster', '$filter', function ($rootScope, $scope, $state, activityService, toaster,$filter) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activities = [];
        $scope.Activity = new ActivityModel();
        $scope.CurrentActivityId = 0;
        $scope.getCurrentRecordId();
        $scope.isLoading = false
        $scope.isShowActivities = false;
    });

   $scope.get = function () {
        activityService.get().then(function (response) {
            angular.forEach(response.Data, function (data) {                            
                data.CreatedOn = $filter('date')(data.CreatedOn, 'MMM dd yyyy');
                $scope.Activities.push(data);
            });
            $scope.Activities = response.Data;

            loadGrid($scope.Activities);
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmActivity.$valid) {
            activityService.save($scope.Activity).then(function (response) {
                $scope.isLoading = false
                $scope.Activity.Description = '';
                $scope.getCurrentRecordId();
                $scope.get();
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
            $scope.Activity.Id = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    //$scope.view = function () {
    //    $scope.get();
    //    $scope.isShowActivities = true;
    //}

}]);

function ActivityModel() {
    this.Id = 0;
    this.Description = "";
    this.IsActive = true;
    this.CreatedBy = "";
    this.CreatedOn = "";
    this.UpdatedBy = "";
    this.UpdatedOn = "";
}

function loadGrid(list) {
    $("#jsGrid").jsGrid({
        height: "80%",
        width: "100%",
 
        filtering: true,
        editing: true,
        sorting: true,
        paging: true,
        autoload: true,
        
 
        pageSize: 5,
        pageButtonCount: 5,
 
        deleteConfirm: "Do you really want to delete the activity?",
 
        data: list,
 
        fields: [
            { name: "ID", type: "number", width: 50 },
            { name: "Description", type: "text", width: 200},
            { name: "CreatedOn", type: "text", width: 150 },
            { type: "control" }
        ]
    });
 


}