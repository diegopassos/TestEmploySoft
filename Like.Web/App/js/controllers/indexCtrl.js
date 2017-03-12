angular.module("like").controller("indexCtrl", function ($scope, userAPI, $rootScope) {

    userAPI.getUserList().success(function (data) {
        $scope.userList = data;
        $scope.userSelected = {Id: 1}
    });

    $rootScope.idUser = 1;


    $scope.selectUser = function (id) {

        $rootScope.idUser = $scope.userSelected
    };

    
});