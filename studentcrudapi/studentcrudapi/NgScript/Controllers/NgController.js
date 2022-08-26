var ItemApp = angular.module('myApp', ["ui.grid","ui.grid.pagination"]);


ItemApp.controller("myCtrl", ['$scope', 'crudService', function ($scope, crudService) {
    //$scope.studentMaster = [];
    //$scope.studentDetail = [];
    //init
    $scope.id = 0;
    $scope.gridOptions = [];
    $scope.dob = new Date('01/31/2022');
    $scope.firstName = "";
    $scope.lastName = "";
    $scope.sub1 = "";
    $scope.num1 = 0;
    $scope.sub2 = "";
    $scope.num2 = 0;
    $scope.sub3 = "";
    $scope.num3 = 0;
    $scope.sub4 = "";
    $scope.num4 = 0;


    $scope.myVar = false;

    $scope.loadalertt = function () {
        alert($scope.dob);
    }
    $scope.submitItemForm = function () {
        var apiRoute = '/api/apiItem/temp/';
        var data = {
            id : $scope.id,
            dob: $scope.dob,
            firstName: $scope.firstName,
            lastName: $scope.lastName,
            sub1: $scope.sub1,
            num1: $scope.num1,
            sub2: $scope.sub2,
            num2: $scope.num2,
            sub3: $scope.sub3,
            num3: $scope.num3,
            sub4: $scope.sub4,
            num4: $scope.num4
        };
        alert(JSON.stringify(data));
        var cmnparam = "[" + JSON.stringify(data) + "]";
        /////alert(cmnparam);
        var create = crudService.GetList(apiRoute, cmnparam);
        //create.then(function (response) {
        //    alert(JSON.stringify(response));
        //    // $scope.Code = "yasin er gusti";

        //},
        //function (error) {
        //    console.log("error: " + error);
        //}
        //);

    }

    $scope.rrresetForm = function () {
        alert("resetting");
        $scope.id = 0;
        $scope.dob = "";
        $scope.firstName = "";
        $scope.lastName = "";

        $scope.sub1 = "";
        $scope.num1 = 0;
        $scope.sub2 = "";
        $scope.num2 = 0;
        $scope.sub3 = "";
        $scope.num3 = 0;
        $scope.sub4 = "";
        $scope.num4 = 0;
    }

    $scope.LoadPopupTable = function () {
        //alert("pop up table is loaded");
        ///conversion.getStringToDate($scope.ProductionDate)
    }



    $scope.showList = function () {
        $scope.gridOptions = {

            paginationPageSizes: [25, 50, 75],

            paginationPageSize: 5,

            columnDefs: [
            { field: 'id', visible: false },
            { field: 'firstName' },
            { field: 'lastName' },
            { field: 'dob' },
            { field: 'sub1', visible: false },
            { field: 'num1', visible: false },
            { field: 'sub2', visible: false },
            { field: 'num2', visible: false },
            { field: 'sub3', visible: false },
            { field: 'num3', visible: false },
            { field: 'sub4', visible: false },
            { field: 'num4', visible: false },
            {
                 name: 'Action',
                 displayName: "Action",

                 enableColumnResizing: false,
                 enableFiltering: false,
                 enableSorting: false,
                 pinnedRight: true,


                 width: '15%',
                 headerCellClass: $scope.highlightFilteredHeader,
                 cellTemplate: '<span class="label label-info label-mini" style="text-align:center !important;">' +
                               '<a href="" title="Edit" ng-click="grid.appScope.Edit(row.entity)">' +
                                 '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                               '</a>' +
                               '</span>' +

                               '<span class="label label-danger label-mini" style="text-align:center !important;">' +
                               '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                 '<i class="icon-glyphicon glyphicon-trash" aria-hidden="true"></i> Delete' +
                               '</a>' +
                               '</span>'

             }


            ],

            onRegisterApi: function (gridApi) {

                $scope.grid1Api = gridApi;

            }


        };


        var apiRoute = '/api/apiItem/GetAllData/';
        var receiveData = crudService.ShowData(apiRoute);
        ///alert(receiveData);
        receiveData.then(function (response) {
           /// alert(response.data[0]);
            console.log(response);
            $scope.gridOptions.data = response.data;
            $scope.myVar = true;
        },
         function (error) {
             console.log("error: " + error);
         }
        );
        //var selectedRow;
        $scope.Edit = function (myRow) {
            console.log(myRow);
            $scope.id = myRow.id;
            $scope.dob = new Date(myRow.dob);
            $scope.firstName = myRow.firstName;
            $scope.lastName = myRow.lastName;
            $scope.sub1 = myRow.sub1;
            $scope.num1 = myRow.num1;
            $scope.sub2 = myRow.sub2;
            $scope.num2 = myRow.num2;
            $scope.sub3 = myRow.sub3;
            $scope.num3 = myRow.num3;
            $scope.sub4 = myRow.sub4;
            $scope.num4 = myRow.num4;

        };

        ////sokale implement korbo
        $scope.delete = function (myRow) {
            //$scope.id = myRow.id;
            //var apiRoute = '/api/apiItem/delet/';
            //var data = {
            //    id: $scope.id
            //};
            //alert(JSON.stringify(data));
            //var cmnparam = "[" + JSON.stringify(data) + "]";
            //var creat = crudService.delList(apiRoute, cmnparam);
            //delett(myRow);

        }



    };
    //var delett = function (myrow) {
    //    $scope.id = myrow.id;
    //    var apiRoute = '/api/apiItem/delet/';
    //    var data = {
    //        id: $scope.id,
    //        dob: $scope.dob,
    //        firstName: $scope.firstName,
    //        lastName: $scope.lastName,
    //        sub1: $scope.sub1,
    //        num1: $scope.num1,
    //        sub2: $scope.sub2,
    //        num2: $scope.num2,
    //        sub3: $scope.sub3,
    //        num3: $scope.num3,
    //        sub4: $scope.sub4,
    //        num4: $scope.num4

    //    };
    //    alert(JSON.stringify(data));
    //    var cmnparam = "[" + JSON.stringify(data) + "]";
    //    var create = crudService.GetList(apiRoute, cmnparam);
    //}


}]);
