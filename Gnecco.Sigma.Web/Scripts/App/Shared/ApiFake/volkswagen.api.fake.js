(function(){
    'use strict';

    angular.module("shared.volkswagenApiFake",
                ["ngMockE2E"])
            .run(function($httpBackend)
            {

                // listarInformesInspeccion

                var informesInspeccion = 
                [
                    {
                        "Id" : 1,
                        "Nombre" : "volkswagen 1",
                        "FechaCreacion" : "10/10/2014",
                        "Estado" : true
                    },
                    {
                        "Id" : 2,
                        "Nombre" : "volkswagen 2",
                        "FechaCrecion" : "11/11/2014",
                        "Estado" : true
                    }
                ]

                var listarInformesInspeccionUrl = "/api/InformeInspeccion/Volkswagen";

                $httpBackend.whenGET(listarInformesInspeccionUrl).respond(informesInspeccion);

                // guardar

                $httpBackend.whenPOST(listarInformesInspeccionUrl).respond(function(method,url,data){
                    var informesInspeccion = angular.fromJson(data);
                    console.log(informesInspeccion);
                    return [200,informesInspeccion,{}];
                });

                // buscar informe inspeccion

                var informeInspeccion1 = {
                    "Descripcion" : "Informe Inspeccion 1 bla bla bla",
                    "Detalles" : [
                    {
                        "Id" : 1,
                        "Descripcion": "Fila 1",
                        "OpcionesCondicion": [
                            {
                                "Id": 1,
                                "Descripcion": "Ok",
                                "Valor": ""
                            },
                             {
                                 "Id": 2,
                                 "Descripcion": "No Ok",
                                 "Valor": ""
                             },
                             {
                                 "Id": 3,
                                 "Descripcion": "Corregido",
                                 "Valor": ""
                             }
                        ]
                    }, {
                        "Id" : 2,
                         "Descripcion": "Fila 2",
                         "OpcionesCondicion": [
                             {
                                 "Id" : 1,
                                 "Descripcion": "Ok",
                                 "Valor": ""
                             },
                             {
                                 "Id": 2,
                                 "Descripcion": "No Ok",
                                 "Valor": ""
                             },
                             {
                                 "Id": 3,
                                 "Descripcion": "Corregido",
                                 "Valor": ""
                             }
                         ]
                    }],
                }

                var buscarInformeInspeccionUrl = "/api/InformeInspeccion/Volkswagen/";

                $httpBackend.whenGET(buscarInformeInspeccionUrl+'1').respond(informeInspeccion1);

                // completar

                /*var informeInspeccionCompletado = {
                    "Descripcion": "Informe Inspeccion 1 bla bla bla",
                    "Detalles": [
                    {
                        "Descripcion": "Fila 1",
                        "OpcionesCondicion": [
                            {
                                "Descripcion": "Ok",
                                "Valor": ""
                            },
                             {
                                 "Descripcion": "No Ok",
                                 "Valor": ""
                             },
                             {
                                 "Descripcion": "Corregido",
                                 "Valor": ""
                             }
                        ]
                    }, {
                        "Descripcion": "Fila 2",
                        "OpcionesCondicion": [
                            {
                                "Descripcion": "Ok",
                                "Valor": ""
                            },
                            {
                                "Descripcion": "No Ok",
                                "Valor": ""
                            },
                            {
                                "Descripcion": "Corregido",
                                "Valor": ""
                            }
                        ]
                    }],
                }*/

                var completarUrl = "/api/InformeInspeccion/Volkswagen/Completar";

                $httpBackend.whenPOST(completarUrl).respond(function (method, url, data) {
                    var informesInspeccion = angular.fromJson(data);
                    console.log(informesInspeccion);
                    return [200, informesInspeccion, {}];
                });

                //
                    
                $httpBackend.whenGET(/Scripts/).passThrough();
            });



    /*var app = angular.module("resultadoAprendizajeResourceMock",
                    ["ngMockE2E"]);

    app.run(function($httpBackend){

        var resultadosAprendizaje =
        [
            {
                "codigo":"001",
                "descripcion":"Resultado Aprendizaje 1",
                "autor":"Ing. Lanchipa"
            },
            {
                "codigo":"002",
                "descripcion":"Resultado Aprendizaje 2",
                "autor":"Ing. Lanchipa"
            }
        ];

        var buscarResultadosAprendizajeUrl = "/api/resultadoAprendizaje";

        $httpBackend.whenGET(buscarResultadosAprendizajeUrl).respond(resultadosAprendizaje);

        $httpBackend.whenPOST(buscarResultadosAprendizajeUrl).respond(function(method,url,data){
            var resultadoAprendizaje = angular.fromJson(data);
            console.log(resultadoAprendizaje);
            return [200,resultadoAprendizaje,{}];
        });

        $httpBackend.whenGET(/resultadoAprendizaje/).passThrough();
    });*/

}());