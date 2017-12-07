angular.module('RedAlertApp').controller('areaController', ['$rootScope', '$scope', '$state', 'areaService', 'NgTableParams', function ($rootScope, $scope, $state, areaService, NgTableParams) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Areas = [];
        $scope.Area = new AreaModel();
        $scope.getCurrentRecordId();
        $scope.isLoading = false
        $scope.isShowAreaGrid = false;
    });


    $scope.get = function () {
        areaService.get().then(function (response) {
            $scope.Areas = response.Data;
            $scope.tableParams = new NgTableParams({}, {
                dataset: $scope.Areas
            });
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmArea.$valid) {
            areaService.save($scope.Area).then(function (response) {
                $scope.isLoading = false
                $scope.Area.Name = '';
                $scope.Area.Code = '';
                $scope.getCurrentRecordId();
                $scope.get();
                toaster.success({ title: "Success", body: "Area saved successfully" });
            }, function (err) {
                $scope.isLoading = false
                toaster.error({ title: "Error", body: "Insertion Failed" });
            });
        }
    };

    $scope.getById = function (area) {
        areaService.getById(area.ID).then(function (response) {
            $scope.Area = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getCurrentRecordId = function () {
        areaService.getCurrentRecordId().then(function (response) {
            $scope.Area.ID = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    function AreaModel() {
        this.ID = 0;
        this.Name = "";
        this.Code = "";
        this.IsActive = true;
        this.CreatedBy = "";
        this.CreatedOn = "";
        this.UpdatedBy = "";
        this.UpdatedOn = "";
    }

}]);

