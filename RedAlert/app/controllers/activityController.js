angular.module('RedAlertApp').controller('activityController', ['$rootScope', '$scope', '$state', 'activityService', 'toaster', 'NgTableParams', function ($rootScope, $scope, $state, activityService, toaster , NgTableParams) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Activities = [];
        $scope.Activity = new ActivityModel();        
        $scope.getCurrentRecordId();
        $scope.isLoading = false
        $scope.isShowActivities = false;
        $scope.isHighlightSelectedRow = false;
    });

   $scope.get = function () {
       activityService.get().then(function (response) {
           $scope.Activities = response.Data;
           $scope.tableParams = new NgTableParams({page:1, count:10}, {
               dataset: $scope.Activities
           });                        
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmActivity.$valid) {
            activityService.save($scope.Activity).then(function (response) {
                $scope.isHighlightSelectedRow = false;
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
            $scope.selectedRow = activity.ID;
            $scope.isHighlightSelectedRow = true;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.clear = function () {
        $scope.isHighlightSelectedRow = false;
        $scope.Activity = new ActivityModel();
        $scope.getCurrentRecordId();
    };

    $scope.getCurrentRecordId = function () {
        activityService.getCurrentRecordId().then(function (response) {
            $scope.Activity.ID = response.Data;
        }, function (err) {
            console.log(err);
        });
    };   

}]);

function ActivityModel() {
    this.ID = 0;
    this.Description = "";
    this.IsActive = true;
    this.CreatedBy = "";
    this.CreatedOn = "";
    this.UpdatedBy = "";
    this.UpdatedOn = "";
}

