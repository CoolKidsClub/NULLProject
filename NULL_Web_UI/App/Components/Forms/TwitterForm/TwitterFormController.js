angular.module('nullApp')
    .controller('TwitterFormController', TwitterFormController);

function TwitterFormController($scope, $resource) {
    $scope.message = "Hello Twitter";
};