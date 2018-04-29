var app = angular.module("myApp", []);
app.controller("myCategories", function($scope, $http) {
    $scope.GetAllData = function() {
        $http({
            method: "get",
            url: "http://localhost:8080/api/categories"
        }).then(function(response) {
            $scope.categories = response.data;
            }, function() {
            alert("Error Occur");
        });
    };

    $scope.DeleteCat = function (Cat) {
        $http.delete('/api/categories/' + Cat.CategoryId).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        });
        //$http({
        //    method: "delete",
        //    url: "http://localhost:8080/api/categories/DeleteCategory",
        //    datatype: "json",
        //    data: JSON.stringify(Cat)
        //}).then(function (response) {
        //    alert(response.data);
        //    $scope.GetAllData();
        //});
    };

    $scope.InsertData = function() {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Category = {};
            $scope.Category.CategoryName = $scope.CatName;
            $scope.Category.ImageUrl = $scope.CatUrl;
            $http({
                method: "post",
                url: "http://localhost:8080/api/categories/",
                datatype: "json",
                data: JSON.stringify($scope.Category)
        }).then(function(response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.CatName = "";
                $scope.CatUrl = ""; 
            });
        } else {
            $scope.Category = {};
            $scope.Category.CategoryName = $scope.CatName;
            $scope.Category.ImageUrl = $scope.CatUrl;
            $scope.Category.CategoryId = document.getElementById("CatID_").value;
            $http({
                method: "put",
                url: "http://localhost:8080/api/categories/" + document.getElementById("CatID_").value,
                datatype: "json",
                data: JSON.stringify($scope.Category)
            }).then(function(response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.CatName = "";
                $scope.CatUrl = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Category";
            });
        }
    };

    $scope.UpdateCat = function (Cat) {
        document.getElementById("CatID_").value = Cat.CategoryId;
        $scope.CatName = Cat.CategoryName;
        $scope.CatUrl = Cat.ImageUrl;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Category Information";
    };
});

app.controller("mySubcategories", function ($scope, $http) {
    //debugger;
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/subcategories"
        }).then(function (response) {
            $scope.subcategories = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
});

app.controller("myProducts", function ($scope, $http) {
    //debugger;
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/products"
        }).then(function (response) {
            $scope.products = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
});