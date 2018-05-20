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
        if (Action === "Submit") {
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
    //Deletes a subcategory
    $scope.DeleteSubcat = function (Subcat) {
        $http.delete('/api/subcategories/' + Subcat.SubcategoryId).then(function (response) {
            alert(response.data);
            $scope.GetAllSubcats();
        });
    };
    //Inserts a subcategory (depending on the button it clicks it's a post or put)
    $scope.InsertSubcat = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
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
                $scope.SubcatName = "";
                $scope.SubcatUrl = "";
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
    //Resets the button properties after a subcategory was modified
    $scope.UpdateSubcat = function (Subcat) {
        document.getElementById("SubcatID_").value = Subcat.SubcategoryId;
        $scope.SubcatName = Subcat.SubcategoryName;
        $scope.SubcatUrl = Subcat.ImageUrl;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Subcategory Information";
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
    //Deletes a product
    $scope.DeleteProd = function (Prod) {
        $http.delete('/api/products/' + Prod.ProductId).then(function (response) {
            alert(response.data);
            $scope.GetAllProds();
        });
    };
    //Inserts a product (depending on the button it clicks it's a post or put)
    $scope.InsertProd = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.Product = {};
            $scope.Product.ProductName = $scope.ProdName;
            $scope.Product.ProductOfTheWeek = $scope.ProdPOTW;
            $scope.Product.ProductDescription = $scope.ProdDescr;
            $scope.Product.ProductPrice = $scope.ProdPrice;
            $scope.Product.IngredientsBlobbed = $scope.ProdIngred;
            $scope.Product.ImageUrl = $scope.ProdUrl;
            $scope.Product.SubcategoryId = document.getElementById("Subcat_Dropdown").value;
            $http({
                method: "post",
                url: "http://localhost:8080/api/products/",
                datatype: "json",
                data: JSON.stringify($scope.Product)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllProds();
                $scope.ProdName = "";
                $scope.ProdDescr = "";
                $scope.ProdPrice = "";
                $scope.ProdIngred = "";
                $scope.ProdUrl = "";
            });
        } else {
            $scope.Product = {};
            $scope.Product.ProductName = $scope.ProdName;
            $scope.Product.ProductOfTheWeek = $scope.ProdPOTW;
            $scope.Product.ProductDescription = $scope.ProdDescr;
            $scope.Product.ProductPrice = $scope.ProdPrice;
            $scope.Product.IngredientsBlobbed = $scope.ProdIngred;
            $scope.Product.ImageUrl = $scope.ProdUrl;
            $scope.Product.ProductId = document.getElementById("ProdID_").value;
            $scope.Product.SubcategoryId = document.getElementById("Subcat_Dropdown").value;
            
            $http({
                method: "put",
                url: "http://localhost:8080/api/products/" + document.getElementById("ProdID_").value,
                datatype: "json",
                data: JSON.stringify($scope.Product)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllProds();
                $scope.ProdName = "";
                $scope.ProdPOTW = false;
                $scope.ProdDescr = "";
                $scope.ProdPrice = "";
                $scope.ProdIngred = "";
                $scope.ProdUrl = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Product";
            });
        }
    };
    //Resets the button properties after a product was modified
    $scope.UpdateProd = function (Prod) {
        document.getElementById("ProdID_").value = Prod.ProductId;
        $scope.ProdName = Prod.ProductName;
        $scope.ProdPOTW = Prod.ProductOfTheWeek;
        $scope.ProdDescr = Prod.ProductDescription;
        $scope.ProdPrice = Prod.ProductPrice;
        $scope.ProdIngred = Prod.IngredientsBlobbed;
        $scope.ProdUrl = Prod.ImageUrl;
        
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Product Information";
    };

    //Payments
    //Gets all payments
    $scope.GetAllPay = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/payments"
        }).then(function (response) {
            $scope.payments = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
    //Deletes a payment
    $scope.DeletePay = function (Pay) {
        $http.delete('/api/payments/' + Pay.PaymentId).then(function (response) {
            alert(response.data);
            $scope.GetAllPay();
        });
    };
    //Inserts a payment (depending on the button it clicks it's a post or put)
    $scope.InsertPay = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.Payment = {};
            $scope.Payment.PaymentName = $scope.PayName;

            $http({
                method: "post",
                url: "http://localhost:8080/api/payments/",
                datatype: "json",
                data: JSON.stringify($scope.Payment)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllPay();
                $scope.PayName = "";
            });
        } else {
            $scope.Payment = {};
            $scope.Payment.PaymentId = document.getElementById("PayID_").value;
            $scope.Payment.PaymentName = $scope.PayName;

            $http({
                method: "put",
                url: "http://localhost:8080/api/payments/" + document.getElementById("PayID_").value,
                datatype: "json",
                data: JSON.stringify($scope.Payment)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllPay();
                $scope.PayName = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Payment";
            });
        }
    };
    //Resets the button properties after a payment was modified
    $scope.UpdatePay = function (Pay) {
        document.getElementById("PayID_").value = Pay.PaymentId;
        $scope.PayName = Pay.PaymentName;

        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Payment Information";
    };

    //Users
    //Gets all users
    $scope.GetAllUse = function () {
        $http({
            method: "get",
            url: "http://localhost:8080/api/users"
        }).then(function (response) {
            $scope.users = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
    //Deletes a user
    $scope.DeleteUse = function (Use) {
        $http.delete('/api/users/' + Use.UserId).then(function (response) {
            alert(response.data);
            $scope.GetAllUse();
        });
    };
    //Inserts a user (depending on the button it clicks it's a post or put)
    $scope.InsertUse = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.User = {};
            $scope.User.UserName = $scope.UseName;
            $scope.User.UserEmail = $scope.UseEmail;
            $scope.User.UserPassword = $scope.UsePw;
            $scope.User.UserFirstName = $scope.UseFirstName;
            $scope.User.UserLastName = $scope.UseLastName;
            $http({
                method: "post",
                url: "http://localhost:8080/api/users/",
                datatype: "json",
                data: JSON.stringify($scope.User)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllUse();
                $scope.UseName = "";
                $scope.UseEmail = "";
                $scope.UsePw = "";
                $scope.UseFirstName = "";
                $scope.UseLastName = "";
            });
        } else {
            $scope.User = {};
            $scope.User.UserId = document.getElementById("UseID_").value;
            $scope.User.UserName = $scope.UseName;
            $scope.User.UserEmail = $scope.UseEmail;
            $scope.User.UserPassword = $scope.UsePw;
            $scope.User.UserFirstName = $scope.UseFirstName;
            $scope.User.UserLastName = $scope.UseLastName;

            $http({
                method: "put",
                url: "http://localhost:8080/api/users/" + document.getElementById("UseID_").value,
                datatype: "json",
                data: JSON.stringify($scope.User)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllUse();
                $scope.UseName = "";
                $scope.UseEmail = "";
                $scope.UsePw = "";
                $scope.UseFirstName = "";
                $scope.UseLastName = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New User";
            });
        }
    };
    //Resets the button properties after a user was modified
    $scope.UpdateUse = function (Use) {
        document.getElementById("UseID_").value = Use.UserId;
        $scope.UseName = Use.UserName;
        $scope.UseEmail = Use.UserEmail;
        $scope.UsePw = Use.UserPassword;
        $scope.UseFirstName = Use.UserFirstName;
        $scope.UseLastName = Use.UserLastName;

        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "hotpink";
        document.getElementById("spn").innerHTML = "Update Payment Information";
    };
});