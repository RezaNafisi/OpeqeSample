﻿'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', 'basicConstant', function ($http, $q, localStorageService, basicConstant) {

    var serviceBase = basicConstant.baseUrl;
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {

        return $http.post(serviceBase + 'api/Account/Register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {
        
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password ;
        console.log(loginData);

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .then(function (response) {
            console.log("respo:", response);
            localStorageService.set('authorizationData', { token: response.data.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        },function (err) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {


        return $http.post(serviceBase + 'api/Membership/Logout')
            .then(function (response) {

                localStorageService.remove('authorizationData');

                _authentication.isAuth = false;
                _authentication.userName = "";
                return response;
            },
            function (erro) {
                localStorageService.remove('authorizationData');

                _authentication.isAuth = false;
                _authentication.userName = "";
                return erro;
            });

    };

    var _echo = function () {
        return $http.get(serviceBase + 'api/Account/Echo')
          .then(function (response) {
              return response;
          });
    }

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.Echo = _echo;

    return authServiceFactory;
}]);