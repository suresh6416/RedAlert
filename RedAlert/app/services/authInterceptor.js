angular.module('RedAlertApp').factory('authInterceptor', function ($window, $q, $injector) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($window.sessionStorage.getItem('token')) {
                config.headers.Authorization = 'Bearer ' + $window.sessionStorage.getItem('token');
            }
            return config || $q.when(config);
        },
        response: function (response) {            
            if (response.status === 401) {
                // TODO: Redirect user to login page.                
            }
            return response || $q.when(response);
        },
        responseError: function (response, $state) {
            if (response.status === 401) {               
                var state = $injector.get('$state');
                state.go('login');
            }
            return response || $q.when(response);
        }
    };
});