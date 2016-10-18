angular.module('nullApp')
    .controller('FacebookFormController', FacebookFormController);

function FacebookFormController($scope, PersonModel, $window) {
    $scope.message = "Hello Facebook";
    $scope.person = PersonModel;

    $window.fbAsyncInit = function () {
        FB.init({
            appId: '',
            channelUrl: 'App/Components/Forms/FacebookForm/FacebookForm.html',
            status: true,
            cookie: true,
            xfbml: true,
            version: 'v2.8'
        });
        FB.AppEvents.logPageView();

        console.log("Faceboook connection initiated");
    };

    //(function (d, s, id) {
    //    var js, fjs = d.getElementsByTagName(s)[0];
    //    if (d.getElementById(id)) { return; }
    //    js = d.createElement(s); js.id = id;
    //    js.src = "//connect.facebook.net/en_US/sdk.js";
    //    fjs.parentNode.insertBefore(js, fjs);
    //}(document, 'script', 'facebook-jssdk'));

    (function (d) {
        // load the Facebook javascript SDK

        var js,
        id = 'facebook-jssdk',
        ref = d.getElementsByTagName('script')[0];

        if (d.getElementById(id)) {
            return;
        }

        js = d.createElement('script');
        js.id = id;
        js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";

        ref.parentNode.insertBefore(js, ref);

        console.log("Facebook SDK loaded");
    }(document));

    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            console.log('Logged in.');
        }
        else {
            FB.login();
        }
    });

    var myFacebookLogin = function () {
        FB.login(function () { }, { scope: 'publish_actions,public_profile' });
    }

    $scope.findMe = function () {
        var searchString = document.getElementById("inputFacebook").value;
        FB.api('/search?q=' + searchString + '&type=user', function (response) {
            console.log(response);
            var stringResponse = JSON.stringify(response)
            document.getElementById('results').innerHTML = stringResponse;
        })
    };

    myFacebookLogin();
};