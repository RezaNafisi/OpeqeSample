app.controller('homeController', function ($scope, $location, authService, GISService) {

    $scope.logOut = function () {

        authService.logOut().then(
            function (res) {
                $location.path('/Login');
            },
            function (err) {
                $location.path('/Login');
            }
        );
        //$location.path('/Login');
    }

    $scope.authentication = authService.authentication;


    authService.Echo().then();

    $scope.GetDistance = function (model) {

        $scope.getting = true;
        GISService.GetDistance(model).then(
            function (response) {
                $scope.Distance = response.data;
                $scope.GetHistory();
                $scope.getting = false;
            },
            function (err) {
                $scope.getting = false;
                $scope.HandleError(err);
            });
    }

    $scope.GetHistory = function () {

        $scope.working = true;
        GISService.GetHistory().then(
            function (response) {
                $scope.History = response.data;
                console.log('$scope.History', $scope.History);
                $scope.working = false;
            },
            function (err) {
                $scope.working = false;
                $scope.HandleError(err);
            });
    }
    $scope.GetHistory();

    $scope.HandleError = function (response) {
        $scope.gettingReview = false;
        console.log('Error:', response);
        if (response.status == '401') {
            $scope.logOut();
            return;
        }
        if (response.status == '404' || response.status == '500') {
            $scope.message = 'Internal Server Error.';
        } else {
            if (response.status == '400') {
                if (response.data) {
                    if (response.data.Message) {
                        $scope.message = response.data.Message;
                    } else {
                        $scope.message = response.data;
                    }
                }

            } else {
                var errors = [];
                for (var key in response.data.ModelState) {
                    for (var i = 0; i < response.data.ModelState[key].length; i++) {
                        errors.push(response.data.ModelState[key][i]);
                    }
                }

                $scope.message = errors.join(' ');
            }
        }
        //alert($scope.message);
        if (!$scope.message) {
            $scope.message = 'Internal Server Error.';
        }
        $scope.MessageBox($scope.message);
    }

    $scope.MessageBox = function (message) {
        alert(message);
    }




});