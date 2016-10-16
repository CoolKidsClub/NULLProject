var mainApp = angular.module("nullApp",
    [
        'ngRoute',
        'ngResource'
    ]);

mainApp.config(function ($routeProvider) {
    $routeProvider
		.when('/', {
		    templateUrl: '../App/Components/Home/Home.html',
            controller:  'HomeController'
		})
		.when('/personForm', {
		    templateUrl: '../App/Components/Forms/PersonForm/PersonForm.html',
		    controller:  'PersonController'
		})
        .when('/emailForm', {
        	templateUrl: '../App/Components/Forms/EmailForm/EmailForm.html',
        	controller: 'EmailController'
        })
        .when('/facebookForm', {
            templateUrl: '../App/Components/Forms/FacebookForm/FacebookForm.html',
            controller:  'FacebookFormController'
        })
        .when('/instagramForm', {
            templateUrl: '../App/Components/Forms/InstagramForm/InstagramForm.html',
            controller:  'InstagramFormController'
        })
        .when('/twitterForm', {
            templateUrl: '../App/Components/Forms/TwitterForm/TwitterForm.html',
            controller:  'TwitterFormController'
        })
		.otherwise({
		    redirectTo: '/'
		});
});