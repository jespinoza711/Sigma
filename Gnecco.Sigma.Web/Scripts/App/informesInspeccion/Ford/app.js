
(function () {
    'use strict';
    var sigma = sigma || {};
    sigma.informesInspeccion = sigma.informesInspeccion || {};

    sigma.informesInspeccion.ford = angular.module("informesInspeccion.ford"
                    									,["ui.router"
                                                        ,"shared.fordApi"
                    									,"shared.utils"]);

    /*,"shared.volkswagenApi"
    ,"shared.volkswagenApiFake"*/
    sigma.informesInspeccion.ford.config(["$stateProvider",
                "$urlRouterProvider",
                function ($stateProvider, $urlRouterProvider) {
                    $urlRouterProvider.otherwise("/");

                    $stateProvider
                        .state('otherwise', {
                            url: '/',
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("index",
                        {
                            url: "/",
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("nuevo",
                        {
                            url: "/nuevo",
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/nuevo.tpl.html",
                            controller: "nuevoCtrl as vm"
                        })
                        .state("verCompletados",
                        {
                            url: ":id/VerCompletados",
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/verCompletados.tpl.html",
                            controller: "verCompletadosCtrl as vm"
                        })
                        .state("ver",
                        {
                            url: ":id/",
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/ver.tpl.html",
                            controller: "verCtrl as vm"
                        })
                        .state("completar",
                        {
                            url: ":id/Completar",
                            templateUrl: "/Scripts/App/InformesInspeccion/Ford/Templates/completar.tpl.html",
                            controller: "completarCtrl as vm"
                        });

                }]
    );
}());
