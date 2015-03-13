(function () {
    'use strict';

    angular.module("informesInspeccion.inventarioVehiculos")
        .controller("indexCtrl",
            ["inventarioVehiculosApi"
            , "$state"
            , "Mensajes"
            , "Loader"
            , IndexCtrl]);

    function IndexCtrl(inventarioVehiculosApi
                       , $state
                       , Mensajes
                       , Loader) {
        var vm = this;
        var idInventario = 0;

        Loader.Cargar();

        vm.listarInventarios = function () {
            inventarioVehiculosApi.listarInventarios()
            .success(function (data) {
                vm.inventarios = data;
                console.log(data);
                Loader.Cerrar();
            });
        }

        vm.nuevo = function () {
            $state.go('nuevo');
        }

        vm.ver = function (id) {
            $state.go('ver', { id: id })
        }

        vm.anular = function (id) {
            if (confirm("Realmente desea anular el informe?")) {
                Loader.Cargar();

                inventarioVehiculosApi.anular(id)
                .success(function (data) {
                    Loader.Cerrar();

                    if (data.Status == 200) {
                        Mensajes.MensajeCorrecto("Informe Anulado", vm.index);
                    }
                    //vm.index();
                });

            }
        }

        vm.modalFotos = function (id) {
            $('#modalFotos').modal('show');
            idInventario = id;
            document.getElementById('idInventario').setAttribute('value', id);
        }

        vm.agregarFotos = function () {
            Mensajes.MensajeCorrecto("Fotos Guardadas", vm.index)
            $('#modalFotos').modal('hide');
        }

        vm.listarInventarios();
    };
}());