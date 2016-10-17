angular.module('nullApp')
    .controller('SearchResultsController', SearchResultsController);

function SearchResultsController($scope, $resource, PersonModel) {
    $scope.message = "Search Results Are:";
    $scope.person = PersonModel;
    $scope.name = $scope.person.FirstName + " " + $scope.person.LastName;

    $scope.facebookAccounts = {};
    $scope.instagramAccounts = {};
    $scope.twitterAccounts = {};


};