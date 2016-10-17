angular.module('nullApp')
    .controller('TwitterFormController', TwitterFormController);

function TwitterFormController($scope, PersonModel) {
    $scope.message = "Hello Twitter";
    $scope.person = PersonModel;
};