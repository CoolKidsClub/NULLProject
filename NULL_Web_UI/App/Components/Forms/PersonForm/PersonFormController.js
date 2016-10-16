angular.module('nullApp')
    .controller('PersonController', PersonController);

function PersonController($scope) {
    $scope.message = "Hello Person";
};