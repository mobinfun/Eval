app.controller("mehvarController",
     ['$scope', 'MehvarService', '$window', '$routeParams',
    function ($scope, MehvarService, $window, $routeParams) {

        GetAllMehvars();

        //Get All Mehvars  
        function GetAllMehvars() {
            var getData = MehvarService.getMehvars();
            getData.then(function (pst) {
                $scope.mehvars = pst.data;
            }, function () {
                $scope.message = 'Unable to load mehvar data: ' + error.message;
            });
        }

        //Delete Mehvar
        $scope.deleteMehvar = function (mehvarId) {
            alert(mehvarId);
            var getData = MehvarService.Delete(mehvarId);
            getData.then(function (msg) {
                $scope.message = 'Mehvar Successfully Deleted.';
            }, function () {
                $scope.message = 'Unable to delete Mehvar: ' + error.message;
            });
        }

    }]);


app.controller("mehvarOpController", ['$scope', 'MehvarService', '$window', '$routeParams', function ($scope, MehvarService, $window, $routeParams) {

   

    //Get Mahvar by MehvarId
    $scope.mehvar = {};
    if ($routeParams.id) {

        var getData = MehvarService.getMehvar($routeParams.id);
        getData.then(function (pst) {
            $scope.mehvar = pst.data;
            $scope.Name = pst.data.Name;
            $scope.MehvarId = pst.data.MehvarId;
            $scope.PositiveModality = pst.data.PositiveModality;
            $scope.SystemType = pst.data.SystemType;

        }, function () {
            $scope.message = 'Unable to load mehvar data: ' + error.message;
        });
    }




    $scope.AddUpdateMehvar = function () {
       
        var mehvar = {
            Name: $scope.Name,
            PositiveModality: $scope.PositiveModality,
            SystemType: $scope.SystemType.value,
            MehvarId: $scope.MehvarId
        };
        alert("new");
        if (mehvar.MehvarId != null) {
            alert("2");//Update Mehvar
            var getData = MehvarService.updateMehvar(mehvar);
            getData.then(function (msg) {
                $window.location = "#/mehvar";
                $scope.message = 'Mehvar Successfully Updated.';
            }, function () {
                $scope.message = 'Unable to update mehvar: ' + error.message;
            });
        } else {
            alert("1");//Add Mehvar
            var getData = MehvarService.newMehvar(mehvar);
            getData.then(function (msg) {
                $window.location = "#/mehvar";
                $scope.message = 'Mehvar Successfully Created.';
            }, function () {
                $scope.message = 'Unable to create new mehvar: ' + error.message;
            });
        }
    };

    GetSystemCode();

    function GetSystemCode() {
        var getData = MehvarService.getSystemCode();
        getData.then(function (pst) {
            $scope.syscodes = pst.data;
        }, function () {
            $scope.message = 'Unable to load mehvar data: ' + error.message;
        });
    }
}]);