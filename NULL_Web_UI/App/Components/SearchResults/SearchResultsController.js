angular.module('nullApp')
    .controller('SearchResultsController', SearchResultsController);

function SearchResultsController($scope, $resource, PersonModel) {
    var singleTwitterRoute = $resource("http://localhost:5756/api/1/twitter/user/:twitterHandle", {});

    $scope.message = "Search Results Are:";
    $scope.person = PersonModel;
    $scope.name = $scope.person.FirstName + " " + $scope.person.LastName;
    $scope.tab = 1;

    $scope.tabIsSet = function (checkTab) {
        return $scope.tab === checkTab;
    };

    $scope.setTab = function (activeTab) {
        $scope.tab = activeTab;
    };

    var IsStringEmpty = function (data)
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
        if ($scope.twitterAccounts.length === 0) {
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
        if (IsStringEmpty($scope.person.FacebookAccount) === false)
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
        if (IsStringEmpty($scope.person.InstagramAccount) === false)
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
        if (IsStringEmpty($scope.person.TwitterAccount) === false)
        {
            $scope.twitterAccounts = [];

            // Find single account
            singleTwitterRoute.get({ twitterHandle: $scope.person.TwitterAccount },
                function (data) {
                    $scope.twitterAccounts.push(data);
                    console.log(data);
                });
        }
        else
        {
            // Widen Search Range
            console.log("No Twitter handle provided");
        }
    }

    var SearchAccounts = function ()
    {
        if (IsStringEmpty($scope.person.Email) === false)
        {
            FindByEmail();
        }
        else if (IsStringEmpty($scope.person.PhoneNumber) === false)
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