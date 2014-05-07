var app = angular.module("AdminApp", []);

app.controller("AdminCtrl", ["$scope", "$http", function ($scope, $http) {
    $scope.selectedImage = 0;
    $scope.Images = function () {
        $http({ method: 'GET', url: 'Admin/GetImages/' + $scope.selectedImage }).
            success(function (data, status, headers, config) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.Images = data;
            }).
            error(function (data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                console.log(data);
            });
    }
}])