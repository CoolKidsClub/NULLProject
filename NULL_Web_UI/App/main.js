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
        	controller:  'EmailFormController'
        })
        .when('/phoneNumberForm', {
            templateUrl: '../App/Components/Forms/PhoneNumberForm/PhoneNumberForm.html',
            controller:  'PhoneNumberFormController'
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
        .when('/searchResults', {
            templateUrl: '../App/Components/SearchResults/SearchResults.html',
            controller:  'SearchResultsController'
        })
		.otherwise({
		    redirectTo: '/'
		});
});

mainApp.factory('PersonModel', function PersonModel() {
    var person = {
        Name: "",
        Nickname: "",
        Gender: "Unknown",
        Occupation: "",
        Religion: "",
        Email: "",
        PhoneNumber: "",
        DateOfBirth: new Date("2000-01-01"),
        HomeTown: "",
        CurrentTown: "",
        FacebookAccount: "",
        InstagramAccount: "",
        TwitterAccount: "",
        //Posts: []
    };

    return person;
});