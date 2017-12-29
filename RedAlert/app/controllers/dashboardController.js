angular.module('RedAlertApp').controller('dashboardController', ['$rootScope', '$scope', '$state', 'dashboardService', 'NgTableParams', '$localStorage', function ($rootScope, $scope, $state, dashboardService, NgTableParams, $localStorage) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.ActivitiesProgress = [];
        $scope.ToDoList = [];
        var user = $localStorage.userInfoStorage;
        $scope.get(user.UserName);
        $scope.getToDoList(user.UserName);
    });

    $scope.get = function (user) {
        dashboardService.get(user).then(function (response) {
            $scope.ActivitiesProgress = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getToDoList = function (user) { 
        dashboardService.getToDoList(user).then(function (response) {
            $scope.ToDoList = response.Data;
             $scope.tableParams = new NgTableParams({}, {
                 dataset: $scope.ToDoList
            });
            
        },
        function (err) {
            console.log(err);
        });

    }
}]);

