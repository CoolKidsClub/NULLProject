angular.module('nullApp')
    .controller('EmailFormController', EmailFormController);

function EmailFormController($scope, $resource) {
    $scope.message = "Hello Email";
};