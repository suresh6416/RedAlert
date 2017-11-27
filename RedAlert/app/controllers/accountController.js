angular.module('RedAlertApp').controller('accountController', ['$rootScope', '$scope', '$state', '$window', '$location', 'accountService', 'toaster', function ($rootScope, $scope, $state, $window, $location, accountService, toaster) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.User = new User();
        $scope.isLoading = false
    });

    /*BEGIN: Login User*/
    $scope.login = function () {
        $scope.isLoading = true;
        accountService.login($scope.User).then(function (response) {            
            if (response !== null) {
                $rootScope.userToken = response;
                $window.sessionStorage.setItem('token', response.access_token);
                $state.go('home.dashboard');
                toaster.success({ title: "Success", body: "You are successfully logged in" });
            }
        }, function (err) {
            $rootScope.userToken = null;
            $scope.isLoading = false;
            toaster.error({ title: "Error", body: "Login failed" });
        });
    };
    /*END: Login User*/
}]);

function User() {
    this.UserName = "";
    this.Password = "";
}
