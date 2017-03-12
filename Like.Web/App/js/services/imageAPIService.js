angular.module("like").factory("imageAPI", function ($http) {
    var _getRandom = function (id) {
        return $http.get("/api/images/random/" + id);
    };

    return {
        getRandom: _getRandom
    };
});