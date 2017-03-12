angular.module("like").config(function ($routeProvider) {
    //Home
    $routeProvider.when("/home", {
        templateUrl: "view/home.html",
        controller: "indexCtrl"
    });
    //Image
    $routeProvider.when("/image/:id", {
        templateUrl: "view/image.html",
        controller: "imageCtrl",
        resolve: {
            imageRandom: function (imageAPI, $route) {
                return imageAPI.getRandom($route.current.params.id);
            }
        }
    });
    //User
    $routeProvider.when("/user/:id", {
        templateUrl: "view/preference.html",
        controller: "userCtrl",
        resolve: {
            userDetails: function (userAPI, $route) {
                return userAPI.getUser($route.current.params.id);
            }
        }
    });


    //Default
    $routeProvider.otherwise({ redirectTo: "/home" });
});