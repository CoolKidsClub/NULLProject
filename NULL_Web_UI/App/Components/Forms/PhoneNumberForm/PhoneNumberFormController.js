angular.module('nullApp')
    .controller('PhoneNumberFormController', PhoneNumberFormController);

function PhoneNumberFormController($scope, $resource, PersonModel)
{
    $scope.person = PersonModel;
};