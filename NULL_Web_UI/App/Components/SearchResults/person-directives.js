"use strict";

var personApp = angular.module('person-directives', []);

personApp.directive("personTab", function () {
    return {
        restrict: "E",
        templateUrl: "../App/Components/SearchResults/person-tab.html"
    };
});