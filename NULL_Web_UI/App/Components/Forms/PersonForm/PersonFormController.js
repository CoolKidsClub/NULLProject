angular.module('nullApp')
    .controller('PersonController', PersonController);

function PersonController($scope, PersonModel)
{
    $scope.person = PersonModel;
};