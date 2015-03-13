(function () {
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("verCtrl",
            ["volkswagenApi"
            , "$state"
            , "$stateParams"
            , "Mensajes"
            , "Loader"
            , VerCtrl]);

    function VerCtrl(volkswagenApi
                       , $state
                       , $stateParams
                       , Mensajes
                       , Loader) {
        Loader.Cargar();

        var vm = this;

        vm.model = {};
        vm.estaModoEdicion = true;

        vm.index = function () {
            $state.go('index');
        }

        vm.buscarInformeInspeccion = function () {
            var id = $stateParams.id;
            volkswagenApi.buscarInformeInspeccion(id)
            .success(function (data) {
                vm.model = data;
                vm.model.DetallesAnulados = [];
                vm.model.OpcionesAnulados = [];
                vm.model.Detalles = data.Detalles;
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
                console.log(data);
            });
        }

        vm.buscarInformeInspeccion();
    };
}());