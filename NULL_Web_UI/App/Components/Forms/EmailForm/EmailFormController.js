angular.module('nullApp')
    .controller('EmailFormController', EmailFormController);

function EmailFormController($scope) {
    $scope.message = "Hello Email";
};