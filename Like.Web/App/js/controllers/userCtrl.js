angular.module("like").controller("userCtrl", function ($scope, userDetails) {
    $scope.user = userDetails.data;
});