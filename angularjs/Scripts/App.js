var app = angular.module("produtosApp", []);

//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("produtosCtrl", function ($scope, $http) {
    $http.get('/home/GetProdutos/')
    .success(function (result) {
        $scope.produtos = result;
    })
    .error(function (data) {
        console.log(data);
    });
});