﻿ItemApp.service('crudService', function ($http) {
    this.GetList = function (apiRoute, cmnparam) {
        console.log(apiRoute);
        var request = $http({
            method: "POST",
            url: apiRoute,
            data: cmnparam,
            dataType: "json"


        });
        return request;
    }
    this.ShowData = function (apiRoute) {
        console.log(apiRoute);
        var request = $http({
            method: "GET",
            url: apiRoute,
            dataType: "json"
        });
        return request;
    }
    

});