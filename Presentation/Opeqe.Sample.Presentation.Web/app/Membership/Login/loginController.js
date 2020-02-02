'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', 
    function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

   // $scope.logOut();

    $scope.message = "";
    $scope.logining = false;
    $scope.login = function () {
        $scope.logining = true;
        authService.login($scope.loginData).then(function (response) {

            $location.path('/');
        },
         function (err) {
             $scope.logining = false;
             console.log(err);
             $scope.message = err.data.error_description;
             $scope.MessageBox($scope.message);

                });
        };



    }]);