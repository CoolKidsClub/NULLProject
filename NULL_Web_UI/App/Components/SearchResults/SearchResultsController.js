angular.module('nullApp')
    .controller('SearchResultsController', SearchResultsController);

function SearchResultsController($scope, $resource, PersonModel)
{
    var twitterRouteByHandle = $resource("http://localhost:5756/api/1/twitter/user/handle/:twitterHandle", {});
    var twitterRouteByData = $resource("http://localhost:5756/api/1/twitter/user/details/:userData", {});
    var coolKidsClubUsers = $resource("http://localhost:5756/api/1/ckc/users", {});

    $scope.facebookAccounts = [];
    $scope.instagramAccounts = [];
    $scope.twitterAccounts = [];
    $scope.coolKidsClubAccounts = [];

    $scope.person = PersonModel;
    $scope.tab = 1;

    $scope.tabIsSet = function (checkTab) {
        return $scope.tab === checkTab;
    };

    $scope.setTab = function (activeTab) {
        $scope.tab = activeTab;
    };

    var updatePersonInformation = function (data)
    {
        var object = {
            Name: data.name,
            MatchPercentage: 0,
        };

        FB.api('/' + data.id + '/picture?type=large', function (response) {
            object.Image = response.data.url;
        });

        return object;
    }

    var fbAsyncInit = function () {
        console.log("FB INIT");

        FB.init({
            appId: '351106655235966',
            channelUrl: 'App/Components/Forms/FacebookForm/FacebookForm.html',
            status: true,
            cookie: true,
            xfbml: true,
            version: 'v2.8'
        });
        FB.AppEvents.logPageView();

        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                console.log('Logged in.');
                myFacebookLogin();
            }
            else {
                FB.login();
            }
        });

        console.log("Faceboook connection initiated");
    };

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
        js.src = "//connect.facebook.net/en_US/sdk.js";

        ref.parentNode.insertBefore(js, ref);

        console.log("Facebook SDK loaded");
    }(document));

    var myFacebookLogin = function () {
        FB.login(function () {
            facebookSearch();
        }, { scope: 'publish_actions,public_profile' });
        
    }

    var facebookSearch = function () {
        var searchString = "";
        if (IsStringNullOrEmpty($scope.person.FacebookAccount) === false)
        {
            searchString = $scope.person.FacebookAccount;
        }
        else
        {
            searchString = $scope.person.Name;
        }
        
        FB.api('/search?q=' + searchString + '&type=user' + '&token=' + FB.getAuthResponse.accessToken, function (response) {

            angular.forEach(response, function (values, keys) {
                angular.forEach(values, function (value, key) {
                    $scope.facebookAccounts.push(updatePersonInformation(value));
                });
            })
            var stringResponse = JSON.stringify(response)
            return stringResponse;
        })
    };

    var IsStringNullOrEmpty = function (data)
    {
        if (data === "" || data === null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    var createUserProfile = function (data)
    {
        var userProfile =
        {
            Name:           data.Name,
            Nickname:       data.Nickname,
            DateOfBirth:    data.DateOfBirth,
            Gender:         data.Gender,
            Email:          data.Email,
            HomeTown:       data.HomeTown,
            CurrentTown:    data.CurrentTown,
            Occupation:     data.Occupation,
            Religion:       data.Religion,
            Image:          data.Image,
            SocialMedia: {
                FacebookHandle: data.FacebookHandle,
                TwitterHandle:  data.twitterHandle
            }
        };

        return userProfile;
    }

    var checkName = function (data)
    {
        var value = 0;

        /// If names matches exactly
        if (data === $scope.person.Name && data !== "")
        {
            value = 40;
        }
        else
        {
            /// If last names macth
            if (data.split(" ").pop() === $scope.person.Name.split(" ").pop())
            {
                value = value + 15;
            }

            // If first names match
            if (data.substr(0, data.indexOf(' ')) === $scope.person.Name.substr(0, $scope.person.Name.indexOf(' ')))
            {
                value = value + 10;
            }
        }

        return value;
    }

    var checkNickname = function (data)
    {
        var value = 0;

        if (data === $scope.person.Nickname && data !== "")
        {
            value = 25;
        }

        return value;
    }

    var checkBirthDate = function (data)
    {
        var value = 0;

        var profileDate = new Date(data).setHours(0, 0, 0, 0);
        var selectedDate = new Date($scope.person.DateOfBirth).setHours(0, 0, 0, 0);

        if (profileDate === selectedDate)
        {
            value = 5;
        }

        return value;
    }

    var checkGender = function (data)
    {
        var value = 0;

        if (data !== "Unknown" &&
            data === $scope.person.Gender)
        {
            value = 5;
        }

        return value;
    }

    var checkCityOfBirth = function (data)
    {
        var value = 0;

        if (data === $scope.person.HomeTown && data !== null)
        {
            value = 5;
        }

        return value;
    }

    var checkCurrentCity = function (data)
    {
        var value = 0;

        if (data === $scope.person.CurrentTown && data !== "")
        {
            value = 5;
        }

        return value;
    }

    var checkOccupation = function (data)
    {
        var value = 0;

        if (data === $scope.person.Occupation && data !== "")
        {
            value = 5;
        }

        return value;
    }

    var checkReligion = function (data)
    {
        var value = 0;

        if (data === $scope.person.Religion && data !== "")
        {
            value = 5;
        }

        return value;
    }

    var checkPhoneNumber = function (data)
    {
        var value = 0;

        if (data === $scope.person.PhoneNumber && data !== "")
        {
            value = 100;
        }

        return value;
    }

    var checkEmail = function (data)
    {
        var value = 0;

        if (data === $scope.person.Email && data !== "")
        {
            value = 100;
        }

        return value;
    }

    var calculateMatchPercentage = function (data)
    {
        data.MatchPercentage = data.MatchPercentage + checkName(data.Name);

        data.MatchPercentage = data.MatchPercentage + checkNickname(data.Nickname);

        data.MatchPercentage = data.MatchPercentage + checkBirthDate(data.DateOfBirth);

        data.MatchPercentage = data.MatchPercentage + checkGender(data.Gender);

        data.MatchPercentage = data.MatchPercentage + checkCityOfBirth(data.HomeTown);

        data.MatchPercentage = data.MatchPercentage + checkCurrentCity(data.CurrentTown);

        data.MatchPercentage = data.MatchPercentage + checkOccupation(data.Occupation);

        data.MatchPercentage = data.MatchPercentage + checkReligion(data.Religion);

        data.MatchPercentage = data.MatchPercentage + checkPhoneNumber(data.PhoneNumber);

        data.MatchPercentage = data.MatchPercentage + checkEmail(data.Email);

        if (data.MatchPercentage > 100)
        {
            data.MatchPercentage = 100;
        }
    }

    var calculateMatchPercentages = function (data)
    {
        angular.forEach(data, function (value, key)
        {
            calculateMatchPercentage(value);
        });
    }

    console.log($scope.person);

    var CheckAccounts = function ()
    {
        if ($scope.facebookAccounts.length === 0)
        {
            console.log("No facebook accounts found");
            GetFacebookAccounts();
        }

        console.log($scope.twitterAccounts.length);
        if ($scope.twitterAccounts.length === 0)
        {
            console.log("No twitter accounts found");
            GetTwitterAccount();
        }

        GetCoolKidsClubAccounts();
    }

    var FindByEmail = function ()
    {
        console.log("Find by email");

        CheckAccounts();
    }

    var FindByPhoneNumber = function ()
    {
        console.log("Find by phone number");
        CheckAccounts();
    }

    var GetFacebookAccounts = function ()
    {
        console.log("Check facebook accounts");
        //if (IsStringNullOrEmpty($scope.person.FacebookAccount) === false)
        //{
        //    $scope.facebookAccounts = [];

        //    // Find single account
        //    fbAsyncInit();
        //}
        //else {
        //    // Widen Search Range
        //    console.log("No Facebook handle provided");
        //    fbAsyncInit();
        //}

        fbAsyncInit();     
    }

    var GetInstagramAccounts = function ()
    {
        if (IsStringNullOrEmpty($scope.person.InstagramAccount) === false)
        {
            $scope.instagramAccounts = [];

            // Find single account
        }
        else {
            // Widen Search Range
            console.log("No Instagram handle provided");
        }
    }

    var GetTwitterAccount = function ()
    {
        if (IsStringNullOrEmpty($scope.person.TwitterAccount) === false)
        {
            $scope.twitterAccounts = [];

            // Find single account
            twitterRouteByHandle.get({ twitterHandle: $scope.person.TwitterAccount },
                function (data) {
                    $scope.twitterAccounts.push(data);
                });
        }
        else
        {
            // Widen Search Range
            console.log("No Twitter handle provided");

            twitterRouteByData.query({ userString: angular.toJson(createUserProfile($scope.person), false) },
                function (data)
                {
                    console.log(data);
                    $scope.twitterAccounts = data;
                });
        }
    }

    var GetCoolKidsClubAccounts = function ()
    {
        coolKidsClubUsers.query({},
            function (data) {
                $scope.coolKidsClubAccounts = data;

                calculateMatchPercentages($scope.coolKidsClubAccounts);
            });
    }

    var SearchAccounts = function ()
    {
        if (IsStringNullOrEmpty($scope.person.Email) === false)
        {
            FindByEmail();
        }
        else if (IsStringNullOrEmpty($scope.person.PhoneNumber) === false)
        {
            FindByPhoneNumber();
        }
        else
        {
            GetFacebookAccounts();
            GetInstagramAccounts();
            GetTwitterAccount();
            GetCoolKidsClubAccounts();
        }
    }

    SearchAccounts();
};