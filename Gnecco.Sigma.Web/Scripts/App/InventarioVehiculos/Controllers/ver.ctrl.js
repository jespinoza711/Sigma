(function () {
    'use strict';

    angular.module("informesInspeccion.inventarioVehiculos")
        .controller("verCtrl",
            ["inventarioVehiculosApi"
            , "$state"
            , "$stateParams"
            , "Mensajes"
            , "Loader"
            , VerCtrl]);

    function VerCtrl(inventarioVehiculosApi
                       , $state
                       , $stateParams
                       , Mensajes
                       , Loader) {

        var vm = this;
        vm.model = {};
        Loader.Cargar();

        vm.buscarInventario = function () {
            var id = $stateParams.id;
            inventarioVehiculosApi.buscarInventario(id)
            .success(function (data) {
                vm.model = data;
                vm.model.Fotos = data.Fotos;
                console.log(vm.model.Fotos);
                console.log(vm.model);
                vm.model.firma = data.RutaFirma;
                signaturePad.fromDataURL(vm.model.firma);
                
                dibujarCirculos(data.Coordenadas);
                dibujarCirculosGasolina(data.CoordenadasGasolina);
                Loader.Cerrar();
            });

        }

        vm.guardar = function () {
            Loader.Cargar();

            inventarioVehiculosApi.guardar(vm.model)
            .success(function (data) {
                console.log(data);
                Loader.Cerrar();
                Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
            });
        }

        vm.anular = function (id) {
            if (confirm("Realmente desea anular el informe?")) {
                Loader.Cargar();

                inventarioVehiculosApi.anular(id)
                .success(function (data) {
                    Loader.Cerrar();

                    if (data.Status == 200) {
                        Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                    }
                    //vm.index();
                });

            }
        }

        vm.index = function () {
            $state.go('index');
        }

        vm.buscarInventario();
    };
}());