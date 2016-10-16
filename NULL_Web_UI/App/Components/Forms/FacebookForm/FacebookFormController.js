angular.module('nullApp')
    .controller('FacebookFormController', FacebookFormController);

function FacebookFormController($scope, $resource) {
    $scope.message = "Hello Facebook";
};