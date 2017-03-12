angular.module("like").controller("homeCtrl", function ($scope, $rootScope) {
    $scope.idUser = $rootScope.idUser;
});