var app = angular.module("myApp", []);
app.controller("ProductCtrl", function ($scope)
{
    $scope.urunler = [];
    $scope.ekle = function ()
    {
        $scope.urunler.push({
            urunAdi: $scope.yeni.urunAdi,
            fiyat: $scope.yeni.fiyat,
            eklemeZamani: new Date()
        })
    }


}