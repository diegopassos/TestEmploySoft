angular.module("like").controller("imageCtrl", function ($scope, $location, $route, imageRandom, imageAPI, userAPI) {
    $scope.image = imageRandom.data;

    $scope.rechargerImage = function (id) {

        imageAPI.getRandom(id).success(function (data) {
            $scope.image = data;
        });
    };

    $scope.savePreference = function (like) {
        
        var preference = { UserId: $route.current.params.id, ImageId: $scope.image.Id, Like: like }
        
        userAPI.addPreference(preference).success(function (data) {
            $location.path("user/" + $route.current.params.id);
        });
    };
});