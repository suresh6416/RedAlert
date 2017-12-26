angular.module('RedAlertApp').controller('complianceController', ['$rootScope', '$scope', '$state', 'complianceService', 'dataLookupService', 'toaster', 'NgTableParams', function ($rootScope, $scope, $state, complianceService, dataLookupService, toaster, NgTableParams) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Compliances = [];
        $scope.UsersList = [];
        $scope.Compliance = new ComplianceModel();
        $scope.getCurrentRecordId();
        $scope.getUsersLookup();
        $scope.isShowComplianceGrid = true;
        $scope.isHighlightSelectedRow = false;
        $scope.isLoading = false;
        $scope.StatusList = ["Open", "Complete", "Cancel"];
        $scope.DeviationAcceptance = [{ value: true, text: "Yes" }, { value: false, text: "No" }];
        $scope.get();
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
            $scope.Compliance.IsDelayed = $scope.Compliance.IsDelayed !== null ? $scope.Compliance.IsDelayed : false;
            $scope.Compliance.IsDelayAcceptable = $scope.Compliance.IsDelayAcceptable !== null ? $scope.Compliance.IsDelayAcceptable : false;
            $scope.Compliance.HasDeviation = $scope.Compliance.HasDeviation !== null ? $scope.Compliance.HasDeviation : false;
            $scope.Compliance.IsDeviationAcceptable = $scope.Compliance.IsDeviationAcceptable !== null ? $scope.Compliance.IsDeviationAcceptable : false;

            complianceService.save($scope.Compliance).then(function (response) {
                $scope.isLoading = false
                $scope.Compliance = new ComplianceModel();
                $scope.get();
                toaster.success({ title: "Success", body: "Compliance details saved successfully" });
                $scope.isShowComplianceGrid = true;
                $scope.isHighlightSelectedRow = false;
            }, function (err) {
                $scope.isLoading = false
                toaster.error({ title: "Error", body: "Insertion Failed" });
            });
        }
    };

    $scope.getById = function (compliance) {
        complianceService.getById(compliance.ID).then(function (response) {
            $scope.Compliance = response.Data;
            $scope.Compliance.DueDate = new Date($scope.Compliance.DueDate);
            $scope.Compliance.CompletionDate = $scope.Compliance.CompletionDate !== null ? new Date($scope.Compliance.CompletionDate) : new Date();

            if ($scope.Compliance.CompletionDate > $scope.Compliance.DueDate)
                $scope.Compliance.IsDelayed = true;
            else
                $scope.Compliance.IsDelayed = false;

            $scope.selectedRow = compliance.ID;
            $scope.isShowComplianceGrid = false;
            $scope.isHighlightSelectedRow = true;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.clear = function () {
        $scope.Compliance = new ComplianceModel();
        $scope.isShowComplianceGrid = true;
        $scope.isHighlightSelectedRow = false;
    };

    $scope.getCurrentRecordId = function () {
        complianceService.getCurrentRecordId().then(function (response) {
            $scope.Compliance.ID = response.Data;

        }, function (err) {
            console.log(err);
        });
    };

    $scope.checkIsDelayed = function () {
        if (($scope.Compliance.DueDate !== "" && $scope.Compliance.CompletionDate !== "") && $scope.Compliance.CompletionDate > $scope.Compliance.DueDate)
            $scope.Compliance.IsDelayed = true;
        else
            $scope.Compliance.IsDelayed = false;
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
        this.IsDeviationAcceptable = false;
        this.Status = "";
        this.PreRespPerson = "";
        this.SecRespPerson = "";


    }
}]);

