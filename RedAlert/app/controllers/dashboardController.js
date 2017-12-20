angular.module('RedAlertApp').controller('dashboardController', ['$rootScope', '$scope', '$state','dashboardService','NgTableParams', function ($rootScope, $scope, $state,dashboardService,NgTableParams) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.ActivitiesProgress = [];
        $scope.ToDoList = [];
        $scope.get();
        $scope.getToDoList();
    });

    $scope.get = function () {
        dashboardService.get().then(function (response) {
            $scope.ActivitiesProgress = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getToDoList = function () { 
        dashboardService.getToDoList().then(function(response){
            $scope.ToDoList = response.Data;
             $scope.tableParams = new NgTableParams({}, {
                 dataset: $scope.ToDoList
            });
            console.log($scope.ToDoList);
        },
        function (err) {
            console.log(err);
        });

    }
}]);

