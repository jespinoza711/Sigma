
(function () {
    'use strict';
    var sigma = sigma || {};
    sigma.informesInspeccion = sigma.informesInspeccion || {};

    sigma.informesInspeccion.inventarioVehiculos = angular.module("informesInspeccion.inventarioVehiculos"
                    									, ["ui.router"
                                                        , "shared.inventarioVehiculosApi"
                    									, "shared.utils"]);

    /*,"shared.volkswagenApi"
    ,"shared.volkswagenApiFake"*/
    sigma.informesInspeccion.inventarioVehiculos.config(["$stateProvider",
                "$urlRouterProvider",
                function ($stateProvider, $urlRouterProvider) {
                    $urlRouterProvider.otherwise("/");

                    $stateProvider
                        .state('otherwise', {
                            url: '/',
                            templateUrl: "/Scripts/App/InventarioVehiculos/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("index",
                        {
                            url: "/",
                            templateUrl: "/Scripts/App/InventarioVehiculos/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("nuevo",
                        {
                            url: "/nuevo",
                            templateUrl: "/Scripts/App/InventarioVehiculos/Templates/nuevo.tpl.html",
                            controller: "nuevoCtrl as vm"
                        })
                        .state("ver",
                        {
                            url: ":id/",
                            templateUrl: "/Scripts/App/InventarioVehiculos/Templates/ver.tpl.html",
                            controller: "verCtrl as vm"
                        });
                        
                        

                }]
    );
}());
