angular.module('nullApp')
    .controller('EmailFormController', EmailFormController);

function EmailFormController($scope, PersonModel) {
    $scope.message = "Hello Email";
    $scope.person = PersonModel;
};