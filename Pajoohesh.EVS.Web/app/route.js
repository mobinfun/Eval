app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/', {
            templateUrl: "/app/Home/home.html"
        }),
        $routeProvider.when('/post', {
            templateUrl: "/app/post/PostList.html",
            controller: "postListController"
        }),
        $routeProvider.when('/post/new', {
            templateUrl: "/app/post/Post.html",
            controller: "postController"
        }),
        $routeProvider.when('/post/:id', {
            templateUrl: "/app/post/Post.html",
            controller: "postController"
        }),
        $routeProvider.when('/mehvar', {
            templateUrl: "/app/mehvar/mehvarList.html",
            controller: "mehvarController"
        }),
        $routeProvider.when('/mehvar/new', {
            templateUrl: "/app/mehvar/Mehvar.html",
            controller: "mehvarOpController"
        }),
        $routeProvider.when('/mehvar/:id', {
            templateUrl: "/app/mehvar/mehvar.html",
            controller: "mehvarOpController"
        });

   


    $routeProvider.otherwise({
        redirectTo: '/'
    });

}]);
