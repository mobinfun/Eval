var app = angular.module('myApp', []);

app.controller('mobinController', function ($scope) {

    $scope.family = [{ text: "Mehdi", value: 10 },
    { text: "Mali", value: 20 },
    { text: "Mobina", value: 30 },
    { text: "Dyana", value: 40 }];


    $scope.counter = 0;
    $scope.myFunc = function() {
        $scope.counter += 1;
    }

    

});


app.directive('myDir', function() {
    return {
        restrict: "A",
        template: '<h1>Dyan</h1>'
    };
});