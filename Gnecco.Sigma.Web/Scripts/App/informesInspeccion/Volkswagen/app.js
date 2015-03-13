
(function(){
    'use strict';
    var sigma = sigma || {};
    sigma.informesInspeccion = sigma.informesInspeccion || {};

    sigma.informesInspeccion.volkswagen = angular.module("informesInspeccion.volkswagen"
                    									,["ui.router"
                                                        , "shared.volkswagenApi"
                    									//,"shared.volkswagenApiFake"
                                                        , "shared.volkswagenApi",
                    									"shared.utils"]);

                                                         /*,"shared.volkswagenApi"
                                                         ,"shared.volkswagenApiFake"*/
    sigma.informesInspeccion.volkswagen.config(["$stateProvider",
                "$urlRouterProvider",
                function($stateProvider,$urlRouterProvider){
                    $urlRouterProvider.otherwise("/");

                    $stateProvider
                        .state('otherwise',{
                            url : '/',
                            templateUrl : "/Scripts/App/InformesInspeccion/Volkswagen/Templates/index.tpl.html",
                            controller : "indexCtrl as vm"
                        })
                        .state("index",
                        {
                            url : "/",
                            templateUrl : "/Scripts/App/InformesInspeccion/Volkswagen/Templates/index.tpl.html",
                            controller : "indexCtrl as vm"
                        })
                        .state("nuevo",
                        {
                           url : "/nuevo",
                            templateUrl : "/Scripts/App/InformesInspeccion/Volkswagen/Templates/nuevo.tpl.html",
                            controller : "nuevoCtrl as vm"
                        })
                        .state("verCompletados",
                        {
                           url : ":id/VerCompletados",
                            templateUrl : "/Scripts/App/InformesInspeccion/Volkswagen/Templates/verCompletados.tpl.html",
                            controller : "verCompletadosCtrl as vm"
                        })
                        .state("ver",
                        {
                            url: ":id/",
                            templateUrl: "/Scripts/App/InformesInspeccion/Volkswagen/Templates/ver.tpl.html",
                            controller: "verCtrl as vm"
                        })
                        .state("completar",
                        {
                           url : ":id/Completar",
                            templateUrl : "/Scripts/App/InformesInspeccion/Volkswagen/Templates/completar.tpl.html",
                            controller : "completarCtrl as vm"
                        })
                        .state("verReporte",
                        {
                            url: ":id/verReporte",
                            templateUrl: "/Scripts/App/InformesInspeccion/Volkswagen/Templates/verReporte.tpl.html",
                            controller: "verReporteCtrl as vm"
                        });
                        
                }]
    );
}());
