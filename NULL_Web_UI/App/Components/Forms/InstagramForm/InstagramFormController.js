angular.module('nullApp')
    .controller('InstagramFormController', InstagramFormController);

function InstagramFormController($scope, PersonModel) {
    $scope.message = "Hello Instagram";
    $scope.person = PersonModel;
};