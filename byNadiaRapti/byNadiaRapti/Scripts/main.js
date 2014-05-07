var app = angular.module("NadiaApp", ['ui.router'])
    .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
        .state("Home", {
            url: "/",
            templateUrl: "/Home/Home"
            //controller: "HomeCtr"
        })
        .state("Collections", {
            url: "/Collections",
            templateUrl: "/Home/Collections",
            controller: "CollectionsCtr"
        })

    }]);

app.controller("CollectionsCtr", ["$scope", "$http", function ($scope, $http) {
    $scope.Images = function () {
        $http({ method: 'GET', url: 'api/Images' }).
            success(function (data, status, headers, config) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.Images = data;
            }).
            error(function (data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                console.log(data);
            })
    }




}])

