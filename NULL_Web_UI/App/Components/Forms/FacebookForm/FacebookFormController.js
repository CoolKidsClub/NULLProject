angular.module('nullApp')
    .controller('FacebookFormController', FacebookFormController);

function FacebookFormController($scope, PersonModel, $window) {
    $scope.message = "Hello Facebook";
    $scope.person = PersonModel;
};