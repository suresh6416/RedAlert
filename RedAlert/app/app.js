var RedAlertApp = angular.module('RedAlertApp', ['ui.router', 'oc.lazyLoad', 'ui.bootstrap', 'ngAnimate', 'toaster', 'ngStorage']);

RedAlertApp.controller('appController', ['$rootScope', '$scope', '$state', '$window', '$localStorage', function ($rootScope, $scope, $state, $window, $localStorage) {
    $rootScope.userToken = null;

    var userInfo = $localStorage.userTokenStorage;
    if (userInfo !== null) {
        $rootScope.userToken = userInfo;
    }

    $scope.logout = function () {
        $rootScope.userToken = null;
        $window.sessionStorage.removeItem('token');
        $localStorage.userTokenStorage = null;
        $state.go('login');
    }
}]);

RedAlertApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', function ($stateProvider, $urlRouterProvider, $httpProvider) {

    // Register the previously created AuthInterceptor.
    $httpProvider.interceptors.push('authInterceptor');

    $urlRouterProvider.otherwise("/login");
    var WEB_APP_NAME = "RedAlertApp";

    $stateProvider
        .state('login', {
            url: '/login',
            abtract: true,
            templateUrl: 'app/views/account/login.html',
            data: { pageTitle: 'Login' },
            controller: "accountController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/accountController.js'
                        ]
                    });
                }]
            }
        })
        .state('home', {
            url: '/home',
            templateUrl: 'app/views/layout/homeLayout.html'
        })
        .state('home.dashboard', {
            url: '/dashboard',
            templateUrl: 'app/views/dashboard.html',
            data: { pageTitle: 'Dashboard' },
            controller: "dashboardController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/dashboardController.js'
                        ]
                    });
                }]
            }
        });
}]);

/*Setup Red Alert App Constants*/
RedAlertApp.constant('redAlertConstants', {
    apiServiceBaseUri: 'http://localhost:4151'
});

