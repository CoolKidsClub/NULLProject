angular.module('nullApp')
    .controller('SearchResultsController', SearchResultsController);

function SearchResultsController($scope, $resource, PersonModel)
{
    var twitterRouteByHandle    = $resource("http://localhost:5756/api/1/twitter/user/handle/:twitterHandle", {});
    var twitterRouteByData      = $resource("http://localhost:5756/api/1/twitter/user/details/:userData", {});

    $scope.person = PersonModel;
    $scope.tab = 1;

    $scope.tabIsSet = function (checkTab) {
        return $scope.tab === checkTab;
    };

    $scope.setTab = function (activeTab) {
        $scope.tab = activeTab;
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
            HomeTown:       data.HomeTown,
            Address:        data.CurrentTown,
            Occupation:     data.Occupation,
            Religion:       data.Religion,
        };

        return userProfile;
    }

    console.log($scope.person);

    $scope.facebookAccounts = [];
    $scope.instagramAccounts = [];
    $scope.twitterAccounts = [];

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
        if (IsStringNullOrEmpty($scope.person.FacebookAccount) === false)
        {
            $scope.facebookAccounts = [];

            // Find single account
        }
        else {
            // Widen Search Range
            console.log("No Facebook handle provided");
        }
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
                    console.log(data);
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
        }
    }

    SearchAccounts();
};