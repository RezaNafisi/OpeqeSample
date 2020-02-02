'use strict';
app.controller('signupController', ['$scope', '$location', 'authService',
    function ($scope, $location, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.selectedMarket = {};

    $scope.registration = {
        Email: "",
        Name: "",
        Password: "",
        ConfirmPassword: ""
    };

    $scope.signingUp = false;


    $scope.signUp = function () {
        $scope.signingUp = true;
        $scope.message = "";
        authService.saveRegistration($scope.registration).then(function (response) {
            $scope.signingUp = false;
            $scope.savedSuccessfully = true;
            $location.path('/Login');

            $scope.registration = {
                userName: "",
                password: "",
                confirmPassword: "",
                isAdmin: false
            };

        },
            function (response) {
                $scope.HandleError(response);
                $scope.signingUp = false;
            });
    };


}]);