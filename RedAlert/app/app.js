var RedAlertApp = angular.module('RedAlertApp', ['ui.router', 'oc.lazyLoad', 'ui.bootstrap']);

RedAlertApp.controller('appController', ['$rootScope', '$scope', '$state', function ($rootScope, $scope, $state) {
    
}]);

RedAlertApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', function ($stateProvider, $urlRouterProvider, $httpProvider) {

    $urlRouterProvider.otherwise("/home/dashboard");
    var WEB_APP_NAME = "RedAlertApp";

    $stateProvider
        .state('home', {
            url: '/home',
            abtract: true,
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