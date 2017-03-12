angular.module("like").factory("userAPI", function ($http) {
    var _getUser = function (id) {
        return $http.get("/api/users/details/" + id);
    };
    var _getUserList = function () {
        return $http.get("/api/users/list");
    };
    var _addPreference = function (preference) {
        return $http.post("/api/users/add/", preference);
    };

    return {
        getUser: _getUser,
        getUserList: _getUserList,
        addPreference: _addPreference
    };
});