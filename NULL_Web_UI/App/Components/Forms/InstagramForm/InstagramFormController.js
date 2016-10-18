angular.module('nullApp')
    .controller('InstagramFormController', InstagramFormController);

function InstagramFormController($scope, $resource) {
    $scope.message = "Hello Instagram";

    var setupRoute = $resource('http://localhost:5756/api/1/instagram/setup', {});
    // Request Instagram auth
    setupRoute.get(
        {},
        function (data) {
            // todo
        }
    );
};