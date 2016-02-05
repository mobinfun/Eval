var app = angular.module('myApp', []);

app.controller('myCtr', function($scope) {
    $scope.dropdown = [
        { text: "first", value: 1120231351 },
        { text: "second", value: 4134545642 },
        { text: "third", value: 45646546543 }
    ];
    $scope.counter = 0;
    $scope.myFunc = function() {
        $scope.counter += 1;
    };

    $scope.first = 'yes';
    $scope.second = angular.noop($scope.first);
});

app.directive('myDir', function() {
    return {
        restrict: "M",
        template: '<h1>ok</h1>'
    };

});

app.controller('todoCtr', function($scope) {
    $scope.todos = [
        { text: 'learn angular', done: false },
        { text: 'learn MVC', done: false }
    ];
    $scope.addTodo = function() {
        $scope.todos.push({ text: $scope.newTodo, done: false });
        $scope.newTodo = null;
    };
});

