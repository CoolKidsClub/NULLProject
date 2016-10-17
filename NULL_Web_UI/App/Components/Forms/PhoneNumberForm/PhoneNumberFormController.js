angular.module('nullApp')
    .controller('PhoneNumberFormController', PhoneNumberFormController);

function PhoneNumberFormController($scope, $resource, PersonModel) {
    $scope.person = PersonModel;

    $scope.message = $scope.person.FirstName + " " + $scope.person.LastName;
};