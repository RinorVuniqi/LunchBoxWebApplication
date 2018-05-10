var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    //Categories
    //Gets all categories
    $scope.GetAllCats = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/categories"
        }).then(function (response) {
            $scope.categories = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
    //Deletes a category
    $scope.DeleteCat = function (Cat) {
        $http.delete('/api/categories/' + Cat.CategoryId).then(function (response) {
            alert(response.data);
            $scope.GetAllCats();
        });
    };
    //Inserts a category (depending on the button it clicks it's a post or put)
    $scope.InsertCat = function () {
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
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllCats();
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
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllCats();
                $scope.CatName = "";
                $scope.CatUrl = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Category";
            });
        }
    };
    //Resets the button properties after a category was modified
    $scope.UpdateCat = function (Cat) {
        document.getElementById("CatID_").value = Cat.CategoryId;
        $scope.CatName = Cat.CategoryName;
        $scope.CatUrl = Cat.ImageUrl;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Category Information";
    };

    //Subcategories
    //Gets all subcategories
    $scope.GetAllSubcats = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/subcategories"
        }).then(function (response) {
            $scope.subcategories = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
    //Deletes a category
    $scope.DeleteSubcat = function (Subcat) {
        $http.delete('/api/subcategories/' + Subcat.SubcategoryId).then(function (response) {
            alert(response.data);
            $scope.GetAllSubcats();
        });
    };
    //Inserts a subcategory (depending on the button it clicks it's a post or put)
    $scope.InsertSubcat = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Subcategory = {};
            $scope.Subcategory.SubcategoryName = $scope.SubcatName;
            $scope.Subcategory.ImageUrl = $scope.SubcatUrl;
            $scope.Subcategory.CategoryId = document.getElementById("Cat_Dropdown").value;
            $http({
                method: "post",
                url: "http://localhost:8080/api/subcategories/",
                datatype: "json",
                data: JSON.stringify($scope.Subcategory)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllSubcats();
                $scope.CatName = "";
                $scope.CatUrl = "";
            });
        } else {
            $scope.Subcategory = {};
            $scope.Subcategory.SubcategoryName = $scope.SubcatName;
            $scope.Subcategory.ImageUrl = $scope.SubcatUrl;
            $scope.Subcategory.SubcategoryId = document.getElementById("SubcatID_").value;
            $scope.Subcategory.CategoryId = document.getElementById("Cat_Dropdown").value;
            $http({
                method: "put",
                url: "http://localhost:8080/api/subcategories/" + document.getElementById("SubcatID_").value,
                datatype: "json",
                data: JSON.stringify($scope.Subcategory)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllSubcats();
                $scope.SubcatName = "";
                $scope.SubcatUrl = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Subcategory";
            });
        }
    };

    $scope.UpdateSubcat = function (Subcat) {
        document.getElementById("SubcatID_").value = Subcat.SubcategoryId;
        $scope.SubcatName = Subcat.SubcategoryName;
        $scope.SubcatUrl = Subcat.ImageUrl;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Category Information";
    };

    //Products
    //Gets all products
    $scope.GetAllProds = function () {
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