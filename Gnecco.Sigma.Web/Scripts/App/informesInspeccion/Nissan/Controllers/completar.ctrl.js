(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .controller("completarCtrl",
            ["nissanApi"
            , "Mensajes"
            , "$state"
            , "$stateParams"
            , "Loader"
            ,completarCtrl]);

    function completarCtrl(nissanApi
                       , Mensajes
                       , $state
                       , $stateParams
                       , Loader) {
        var vm = this;
        vm.model = {};
        //vm.model.intervaloKilometros ="";

        vm.estaModoEdicion = false;

        vm.model.Grupos = [];
        vm.model.GruposCalidad = [];
        vm.model.GruposEspeciales = [];

        vm.buscarInformeInspeccion = function(){
            var id = $stateParams.id;
            nissanApi.buscarInformeInspeccion(id)
            .success(function(data){
                vm.model = data;
                vm.model.Tipo = "Nissan";
                vm.model.Preventivo = 0;
                vm.model.Correctivo = 0;
                console.log(vm.model);
            });
        }

        vm.buscarCliente = function () {
            console.log("aasda");
            var ot = vm.model.OT;
            nissanApi.buscarCliente(ot)
            .success(function (data) {
                vm.resultados = data;
                console.log(vm.resultados);
                $('#modalOT').modal('hide');
                $('#modalDiscriminador').modal('show');
            });
        }

        vm.cargarDatos = function (resultado) {
            $('#modalDiscriminador').modal('hide');
            vm.model.CLIENTE = resultado.CLIENTE;
            vm.model.OT = resultado.OT;
            vm.model.FECHAINGRESO = resultado.FECHAINGRESO;
            vm.model.HORAINGRESO = resultado.HORAINGRESO;
            vm.model.PLACA = resultado.PLACA;
            vm.model.KM = resultado.KM;
            vm.model.FECHAPROMETIDA = resultado.FECHAPROMETIDA;
            vm.model.HORAPROMETIDA = resultado.HORAPROMETIDA;
            vm.model.DNIRUC = resultado.DNIRUC;
            vm.model.DIRECCION = resultado.DIRECCION;
            vm.model.EMAIL = resultado.EMAIL;
            vm.model.TELEFONO = resultado.TELEFONO;
            vm.model.COMP = resultado.COMP;
            vm.model.ID = resultado.ID;
            vm.model.VIN = resultado.VIN;
            vm.model.PREVENTIVO = resultado.PREVENTIVO;
            vm.model.CORRECTIVO = resultado.CORRECTIVO;
            console.log(vm.model);

        }

        vm.agregarGrupo = function () {
            var grupo = {
                "GrupoInformeInspeccionId": 1,
                "Detalles": [
                    {
                        "DetalleId": 1,
                        "OpcionesCheckRevision": [
                                     {
                                         "OpcionId": 1,
                                         "Valor": "True"
                                     },
                                     {
                                         "OpcionId": 1,
                                         "Valor": "True"
                                     },
                                     {
                                         "OpcionId": 1,
                                         "Valor": "True"
                                     }
                        ]
                    }
                ]
            }

            
        }

        vm.agregarGrupoCalidad = function () {
            var grupocalidad = {
                "GrupoInformeInspeccionId": 1,
                "Detalles":
                     [
                            {
                                "DetalleId": 1,
                                "OpcionesCheckCalidad": [
                                     {
                                         "OpcionId": 1,
                                         "Valor": "True"
                                     }
                                ]
                            }
                     ]
            }

            
        }

        vm.agregarGrupoEspecial = function () {
            var grupoespecial = {
                "GrupoInformeInspeccionId": 1,
                "Detalles": [
                       {
                           "DetalleId": 1,
                           "OpcionesCheckRevision": [
                                {
                                    "OpcionId": 1,
                                    "Valor": "True"
                                },
                                {
                                    "OpcionId": 1,
                                    "Valor": "True"
                                },
                                {
                                    "OpcionId": 1,
                                    "Valor": "True"
                                }
                           ],
                           "OpcionesMedicion": [
            					 {
            					     "OpcionId": 1,
            					     "Valor": "1515.15"
            					 }
                           ]
                       }
                ]
            }

            
        }

        vm.index = function () {
            $state.go('index');
        }

        vm.completar = function () {
            Loader.Cargar();

            vm.model.InformeInspeccionId = $stateParams.id;
            nissanApi.completar(vm.model)
            .success(function (data) {
                //vm.agregarGrupo();
                //vm.agregarGrupoCalidad();
                //vm.agregarGrupoEspecial();
                Loader.Cerrar();
                console.log(data);

                if (data.Status == 200) {
                    Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                }
            });
        }

        vm.buscarInformeInspeccion();
        vm.agregarGrupo();
    };
}());