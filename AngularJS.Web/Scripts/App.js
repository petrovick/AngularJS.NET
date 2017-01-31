var app = angular.module("restaurantesApp", []);



app.controller("pratosCtrl", function ($scope, $rootScope, $http) {

    $scope.ListarPratos = function () {
        debugger;
        var idRestaurante = $('#idRestaurante').attr('idrestaurante');
        $scope.IdRestaurante = idRestaurante;
        $http.post('/prato/Listar/', { idRestaurante: $scope.IdRestaurante })
        .success(function (result) {
            $scope.pratos = JSON.parse(result);
            delete $scope.prato;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método ExcluirProduto do controlador
    $scope.DeletaPrato = function (prato) {
        $http.post('/prato/Excluir/', { prato: prato })
        .success(function (result) {
            $scope.pratos = JSON.parse(result);
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método IncluirProduto do controlador
    $scope.AddPrato = function (prato) {
        prato.IdRestaurante = $scope.IdRestaurante;
        $http.post('/prato/Incluir/', { prato: prato })
        .success(function (result) {
            $scope.pratos = JSON.parse(result);
            delete $scope.prato;
        })
        .error(function (data) {
            console.log(data);
        });
    }

});

//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("restaurantesCtrl", function ($scope, $rootScope, $http) {

    $http.get('/restaurante/Listar/')
    .success(function (result) {
        debugger;
        $scope.restaurantes = JSON.parse(result);
    })
    .error(function (data) {
        debugger;
        console.log(data);
    });



    //chama o  método IncluirProduto do controlador
    $scope.AddRestaurante = function (restaurante) {
        $http.post('/restaurante/Incluir/', { restaurante: restaurante })
        .success(function (result) {
            $scope.restaurantes = result;
            delete $scope.restaurante;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método ExcluirProduto do controlador
    $scope.DeletaRestaurante = function (restaurante) {
        $http.post('/restaurante/Excluir/', { restaurante: restaurante })
        .success(function (result) {
            $scope.restaurantes = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método ExcluirProduto do controlador
    $scope.CadastrarPratos = function (restaurante) {
        debugger;
        $rootScope.IdRestaurante = restaurante.IdRestaurante;
        window.location = "/prato/index?id=" + restaurante.IdRestaurante;
    }



});