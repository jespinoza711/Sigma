(function(){
    'use strict';

    angular.module("informesInspeccion.ford")
        .controller("indexCtrl",
            ["fordApi"
            , "$state"
            , "Mensajes"
            , "Loader"
            , IndexCtrl]);

    function IndexCtrl(fordApi
                       , $state
                       , Mensajes
                       , Loader) {
        var vm = this;
        Loader.Cargar();

        vm.listarInformesInspeccion = function(){
            fordApi.listarInformesInspeccion()
            .success(function(data){
                vm.informesInspeccion = data;
                Loader.Cerrar();
            });
        }

        vm.nuevo = function(){
            $state.go('nuevo');
        }

        vm.verCompletados = function(){
            $state.go('verCompletados');
        }

        vm.ver = function (id) {
            $state.go('ver', { id: id })
        }

        vm.verCompletados = function (id) {
            $state.go('verCompletados', { id: id })
        }

        vm.completar = function (id) {
            $state.go('completar', { id: id })
        }

        vm.anular = function (id) {
            if (confirm("Realmente desea anular el informe?")) {
                Loader.Cargar();

                fordApi.anular(id)
                .success(function (data) {
                    Loader.Cerrar();

                    if (data.Status == 200) {
                        Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                    }
                    //vm.index();
                });

            }
        }

        vm.listarInformesInspeccion();
    };
}());