(function () {
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("verReporteCtrl",
            ["volkswagenApi"
            , "$state"
            , "$stateParams"
            , "Mensajes"
            , "Loader"
            , VerReporteCtrl]);

    function VerReporteCtrl(volkswagenApi
                       , $state
                       , $stateParams
                       , Mensajes
                       , Loader) {
        Loader.Cargar();

        var vm = this;

        vm.model = {};
        vm.estaModoEdicion = false;

        vm.index = function () {
            $state.go('index');
        }

        vm.listarInformeInspeccionCompleto = function (id) {
            var id = $stateParams.id;
            volkswagenApi.listarInformesInspeccionCompleto(id)
            .success(function (data) {
                vm.model = data;
                vm.model.DetallesAnulados = [];
                vm.model.Detalles = data.Detalles;
                console.log(data);
                Loader.Cerrar();
            });
        }

        vm.agregarFila = function () {
            vm.model.Detalles.push({
                Id: "",
                Descripcion: "",
                OpcionesCondicion: [
                    {
                        "Descripcion": "Ok",
                    },
                    {
                        "Descripcion": "No Ok",
                    },
                    {
                        "Descripcion": "Corregido",
                    }
                ],
                OpcionesInternas: [],
                OpcionesIntervalokm: [
                    {
                        "Descripcion": ""
                    }
                ],
                DetallesAnulados: []
            });
        }

        vm.eliminarDetalle = function (index) {
            if (confirm("Realmente desea eliminar esta fila?")) {
                vm.model.DetallesAnulados.push(vm.model.Detalles[index]);
                vm.model.Detalles.splice(index, 1);
            }
        }

        vm.guardar = function () {
            Loader.Cargar();

            vm.model.InformeInspeccionId = $stateParams.id;
            volkswagenApi.modificar(vm.model)
            .success(function (data) {
                Loader.Cerrar();
                Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
            });
        }

        vm.listarInformeInspeccionCompleto();
    };
}());