var RedAlertApp = angular.module('RedAlertApp', ['ui.router', 'oc.lazyLoad', 'ui.bootstrap', 'ngAnimate', 'toaster', 'ngStorage','ngTable']);

RedAlertApp.controller('appController', ['$rootScope', '$scope', '$state', '$window', '$localStorage', function ($rootScope, $scope, $state, $window, $localStorage) {
    $rootScope.userToken = null;

    var userToken = $localStorage.userTokenStorage;
    if (userToken !== null) {
        $rootScope.userToken = userToken;
    }

    var userInfo = $localStorage.userInfoStorage;
    if (userInfo !== null) {
        $rootScope.userInfo = userInfo;
    }

    $scope.logout = function () {
        $rootScope.userToken = null;
        $rootScope.userInfo = "";
        $window.sessionStorage.removeItem('token');
        $localStorage.userTokenStorage = null;
        $localStorage.userInfoStorage = null;
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
        })
        .state('home.activity', {
            url: '/activity',
            templateUrl: 'app/views/activity.html',
            data: { pageTitle: 'Activities' },
            controller: "activityController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/activityController.js'
                        ]
                    });
                }]
            }
        })
        .state('home.activityInfo', {
            url: '/activityInfo',
            templateUrl: 'app/views/activityInfo.html',
            data: { pageTitle: 'Activity Information' },
            controller: "activityInfoController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/activityInfoController.js'
                        ]
                    });
                }]
            }
        })
        .state('home.area', {
            url: '/area',
            templateUrl: 'app/views/area.html',
            data: { pageTitle: 'Area' },
            controller: "areaController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/areaController.js'
                        ]
                    });
                }]
            }
        })
        .state('home.compliance', {
            url: '/compliance',
            templateUrl: 'app/views/compliance.html',
            data: { pageTitle: 'Compliance' },
            controller: "complianceController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/complianceController.js'
                        ]
                    });
                }]
            }
        })
        .state('home.reports', {
            url: '/reports',
            templateUrl: 'app/views/reports.html',
            data: { pageTitle: 'Reports' },
            controller: "reportController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controllers/reportController.js'
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

