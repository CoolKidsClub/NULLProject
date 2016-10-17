angular.module('nullApp')
    .controller('PersonController', PersonController);

function PersonController($scope, PersonModel) {
    var display = "Hello ";
    $scope.person = PersonModel;

    $scope.message = "";

    var updateMessage = function ()
    {
        $scope.message = display + $scope.person.FirstName + " " + $scope.person.LastName;
    }

    $scope.update = function ()
    {
        updateMessage();
    }

    updateMessage();
};