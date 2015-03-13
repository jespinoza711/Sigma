
(function () {
    'use strict';
    var sigma = sigma || {};
    sigma.informesInspeccion = sigma.informesInspeccion || {};

    sigma.informesInspeccion.nissan = angular.module("informesInspeccion.nissan"
                    									,["ui.router"
                                                        ,"shared.nissanApi"
                    									,"shared.utils"]);

    /*,"shared.volkswagenApi"
    ,"shared.volkswagenApiFake"*/
    sigma.informesInspeccion.nissan.config(["$stateProvider",
                "$urlRouterProvider",
                function ($stateProvider, $urlRouterProvider) {
                    $urlRouterProvider.otherwise("/");

                    $stateProvider
                        .state('otherwise', {
                            url: '/',
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("index",
                        {
                            url: "/",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/index.tpl.html",
                            controller: "indexCtrl as vm"
                        })
                        .state("nuevo",
                        {
                            url: "/nuevo",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/nuevo.tpl.html",
                            controller: "nuevoCtrl as vm"
                        })
                        .state("verCompletados",
                        {
                            url: ":id/VerCompletados",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/verCompletados.tpl.html",
                            controller: "verCompletadosCtrl as vm"
                        })
                        .state("ver",
                        {
                            url: ":id/",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/ver.tpl.html",
                            controller: "verCtrl as vm"
                        })
                        .state("completar",
                        {
                            url: ":id/Completar",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/completar.tpl.html",
                            controller: "completarCtrl as vm"
                        })
                        .state("verReporte",
                        {
                            url: ":id/VerReporte",
                            templateUrl: "/Scripts/App/InformesInspeccion/Nissan/Templates/verReporte.tpl.html",
                            controller: "verReporteCtrl as vm"
                        });

                }]
    );
}());
