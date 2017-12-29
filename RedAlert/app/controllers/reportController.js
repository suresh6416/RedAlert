angular.module('RedAlertApp').controller('reportController', ['$rootScope', '$scope', '$state', 'reportService', function ($rootScope, $scope, $state, reportService) {
   // $scope.$on('$viewContentLoaded', function () {
        $scope.ReportDetails = { Report : "History",
            ReportType: "",
            FromDate :"",
            ToDate: "",
            UserName: "",
            Type: "",
            AreaType:""
        };
        $scope.showDesableReport = true;
        $scope.selectedReport = "Consolidated";
    //});
    $scope.showReport = function () {
        $scope.ReportDetails.ReportType = $scope.selectedReport;
        $scope.ReportDetails.FromDate = $scope.from;
        $scope.ReportDetails.ToDate = $scope.to;
        $scope.FromDate = new Date($scope.from);
        $scope.ToDate = new Date($scope.to);
        $scope.ReportDetails.UserName = $rootScope.userToken.userName;
        $scope.ReportDetails.AreaType = $scope.selectedArea == undefined ? 0 : $scope.selectedArea.ID;
        $scope.ReportDetails.Type=$scope.selectedType;
    //    $scope.ReportDetails.AreaType = $scope.selectedType;

        //if ($scope.ReportDetails.ReportType=="Type" && $scope.selectedType == undefined || $scope.selectedType == "Select Type") {
        //    $scope.error = true;
        //    return false;
        //}
        //else if($scope.ReportDetails.ReportType=="Type"){
        //    $scope.error = false;
        //};
        //$scope.ReportDetails.Type = $scope.selectedType;
        //if ($scope.ReportDetails.ReportType=="Area Wise" && ($scope.selectedArea == ""||$scope.selectedArea == undefined)) {
        //    $scope.ReportDetails.AreaType = 0;
        //    $scope.error_area = true;
        //    return false;
        //}
        //else  if ($scope.ReportDetails.ReportType=="Area Wise") {
        //    $scope.ReportDetails.AreaType = $scope.selectedArea.ID;
        //    $scope.error_area = false;
        //}
      //  $scope.ReportDetails.AreaType = $scope.selectedArea == (undefined || "" || null) ? 0 : $scope.selectedArea.ID;
        reportService.report($scope.ReportDetails).then(function (response) {
            if (response != null) {

                console.log(response.data.Data);
                $scope.reports = response.data.Data;
                $scope.showDesableReport = false;
                if ($scope.from == undefined || $scope.from == null || $scope.from == "") $scope.FromDate = "--";
                if ($scope.to == undefined || $scope.to == null || $scope.to == "") $scope.ToDate = "--";
            }
        }, function (err) {
            console.log(err)
        });
    };

    $scope.getAreas = function (selectedReport) {
        if (selectedReport == 'Area Wise') {
            reportService.areas().then(function (response) {

                if (response != null) {
                   // console.log(response.data.Data);
                    $scope.areas = response.data.Data;
                    $scope.selectedArea = $scope.areas[0];
                }
            }, function (err) {
                console.log('Areas exception')
            });
        }
        else if (selectedReport == "Type") {
            $scope.selectedType = "Open";
        }
    }
    $scope.reportType = function (reportType) {
        $scope.ReportDetails.Report = reportType;       
    }
    $scope.close=function(){
        $state.go('home.dashboard');
    }
    $scope.type = function (error) {
        if (error) $scope.error = false;
        else $scope.error = true;
    }
    $scope.areaType = function () {
        if ($scope.selectedArea=="") $scope.error_area = true;
        else $scope.error_area = false;
    }
    $scope.print = function (printable) {

        if ($scope.reports.length == 0) return;
        if (printable == 'printable') {
            if ($scope.ReportDetails.Report == "" || $scope.selectedReport == undefined) return;

        }
        if ($scope.ReportDetails.Report == 'Future') printable = 'printfuturetable';
        printFun(printable);
    };
    $scope.printdetailtable = function (printable) {

        if ($scope.reports.length == 0) return;
        printFun(printable)
    };
    function printFun(printable)   {
        var printContents = document.getElementById(printable).innerHTML;

        var popupWin = window.open('', '_blank');
        popupWin.document.open();
        popupWin.document.write('<link href="../../Content/css/print.css" rel="stylesheet" />');
        popupWin.document.write('<link href="../../Content/css/bootstrap.css" rel="stylesheet" />');
        popupWin.document.write(printContents);
        popupWin.document.close();
    }
}]);

