(function () {
    'use strict';

    angular.module('app.route', [])
        .config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
           .when('/Directories/contacts', {
               templateUrl: '/App/contact/contact.html',
               controller: 'ContactController',
               controllerAs: 'vm'
           });
        $locationProvider
            .html5Mode({
                enabled: true,
                requireBase: false
            });

        //$qProvider.errorOnUnhandledRejections(false);
    };
})();