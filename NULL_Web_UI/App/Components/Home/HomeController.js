angular.module('nullApp')
    .controller('HomeController', HomeController);

function HomeController($scope, $resource) {
    $scope.message = "Hello World";
    $scope.result = 0;

    var calculateRoute = $resource('http://localhost:5756/api/test/Calculate/:num1/:num2');
    var valueRoute = $resource('http://localhost:5756/api/Values', {});
    var randomRoute = $resource('http://movieapp-sitepointdemos.rhcloud.com/api/movies', {});

    calculateRoute.get({ num1: 1, num2: 4 },
        function (data) {
            $scope.result = data[0];
            console.log(data);
    });

    valueRoute.query({}, function (data) {
            console.log("Success!");
            console.log(data);
        },
    function (error) {
        console.log("Fail!");
        console.log(error);
    });
};