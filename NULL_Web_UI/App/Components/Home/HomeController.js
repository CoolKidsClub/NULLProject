angular.module('nullApp')
    .controller('HomeController', HomeController);

function HomeController($scope, $resource)
{
    //var clientId = "177686e5ab7f45d8a611f311741b3fb1";
    //var redirectUri = "http://localhost:14406/";

    //var init = function () {
    //    $scope.accessToken = window.location.hash.substr(14);

    //    var x = "https://api.instagram.com/v1/tags/nofilter/media/recent?access_token=" + $scope.accessToken;
    //    console.log(x);
    //};
    //init();

    //$scope.auth = function () {
    //    console.log("Button clicked");
    //    var link = "https://api.instagram.com/oauth/authorize/?"
    //        + "client_id=" + clientId
    //        + "&redirect_uri=" + redirectUri
    //        + "&response_type=token"
    //        + "&scope=public_content+comments+likes+follower_list+relationships";

    //    window.location.href = link;
    //};
}