angular.module('nullApp')
    .controller('FacebookFormController', FacebookFormController);

function FacebookFormController($scope, PersonModel) {
    $scope.message = "Hello Facebook";
    $scope.person = PersonModel;
};