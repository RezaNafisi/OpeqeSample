var app = angular.module("app",
    [
        "ngRoute",
        "LocalStorageModule"
    ]);

app.config(function ($routeProvider) {
    $routeProvider
        
        .when("/", {
            templateUrl: "/app/Home/HomeTemplate.html",
            controller: "homeController"
        })
        .when("/Login", {
            templateUrl: "/app/Membership/Login/Login.html",
            controller: "loginController"
        })
        .when("/Register", {
            templateUrl: "/app/Membership/Register/Register.html",
            controller: "signupController"
        })
        .otherwise({ redirectTo: "/" });;

});



app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.constant('basicConstant', {
    baseUrl: 'http://localhost:55062/'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});