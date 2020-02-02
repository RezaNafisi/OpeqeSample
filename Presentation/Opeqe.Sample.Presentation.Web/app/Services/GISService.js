'use strict';
app.factory('GISService', ['$http', 'basicConstant', function ($http, basicConstant) {


    var serviceBase = basicConstant.baseUrl;

    var _getDistance = function (model) {

        return $http.post(serviceBase + 'api/GIS/GetDistance', model).then(function (response) {
            return response;
        });

    };

    var _getHistory = function () {

        return $http.get(serviceBase + 'api/GIS/GetHistory').then(function (response) {
            return response;
        });

    };

    return {
        GetDistance: _getDistance,
        GetHistory: _getHistory
    }

}]);