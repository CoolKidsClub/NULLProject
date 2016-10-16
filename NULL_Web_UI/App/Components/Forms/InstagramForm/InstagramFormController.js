angular.module('nullApp')
    .controller('InstagramFormController', InstagramFormController);

function InstagramFormController($scope, $resource) {
    $scope.message = "Hello Instagram";
};