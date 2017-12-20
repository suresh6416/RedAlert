angular.module('RedAlertApp').controller('complianceController', ['$rootScope', '$scope', '$state', 'complianceService','dataLookupService', 'toaster', 'NgTableParams','$filter', function ($rootScope, $scope, $state, complianceService,dataLookupService, toaster, NgTableParams,$filter) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Compliances = [];
        $scope.UsersList = [];
        $scope.Compliance = new ComplianceModel();
        $scope.getCurrentRecordId();
        $scope.getUsersLookup();
        $scope.get();
        $scope.isShowComplianceGrid = true;
        $scope.isShowComplianceForm=false;
        $scope.isLoading = false;
        $scope.StatusList = ["Open", "Complete", "Cancel"];
        $scope.DeviationAcceptance = $scope.DelayAcceptance = [{ value: true, text: "Yes" }, { value: false, text: "No" }];
    });

    $scope.get = function () {
        complianceService.get().then(function (response) {
            $scope.Compliances = response.Data;
            $scope.tableParams = new NgTableParams({ page: 1, count: 10 }, {
                dataset: $scope.Compliances
            });
            
        }, function (err) {
            console.log(err);
        });
    };


    //Get Users Lookup
    $scope.getUsersLookup = function () {
        dataLookupService.getUsersLookup().then(function (response) {
            $scope.UsersList = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

     $scope.save = function () {
        $scope.isLoading = true;
        if ($scope.frmCompliance.$valid) {
            complianceService.save($scope.Compliance).then(function (response) {
                $scope.isLoading = false
                $scope.Compliance = new ComplianceModel();
                $scope.get();
                toaster.success({ title: "Success", body: "Compliance details saved successfully" });
                $scope.isShowComplianceGrid = true;
                $scope.isShowComplianceForm = false;
            }, function (err) {
                $scope.isLoading = false
                toaster.error({ title: "Error", body: "Insertion Failed" });
            });
        }
    };

    $scope.getById = function (compliance) {
        complianceService.getById(compliance.ID).then(function (response) {
            $scope.Compliance = response.Data;
            $scope.Compliance.DueDate = $filter('date')($scope.Compliance.DueDate, "yyyy-MM-dd");
            $scope.Compliance.CompletionDate = $filter('date')($scope.Compliance.CompletionDate, "yyyy-MM-dd");
            $scope.selectedRow = compliance.ID;
            $scope.isShowComplianceGrid = false;
            $scope.isShowComplianceForm = true;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.cancel = function () {
        $scope.Compliance = new ComplianceModel();
        $scope.isShowComplianceGrid = true;
        $scope.isShowComplianceForm = false;
    };

    $scope.getCurrentRecordId = function () {
        complianceService.getCurrentRecordId().then(function (response) {
            $scope.Compliance.ID = response.Data;
           
        }, function (err) {
            console.log(err);
        });
    };

    function ComplianceModel() {
        this.ID = 0;
        this.AreaId = 0;
        this.AreaName = "";
        this.ActivityId = 0;
        this.ActivityName = "";
        this.Description = "";
        this.DueDate = "";
        this.CompletionDate = "";
        this.IsDelayed = false;
        this.ReasonForDelay = "";
        this.IsDelayAcceptable = false;
        this.Remarks = "";
        this.HasDeviation = false;
        this.DeviationDesc = "";
        this.IsDeviationAcceptable = "";
        this.Status = "";
        this.PreRespPerson = "";
        this.SecRespPerson = "";


    }
}]);

