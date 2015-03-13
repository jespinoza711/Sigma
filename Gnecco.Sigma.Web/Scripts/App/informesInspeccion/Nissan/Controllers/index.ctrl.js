(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .controller("indexCtrl",
            ["nissanApi"
            , "$state"
            , "Mensajes"
            , "Loader"
            , IndexCtrl]);

    function IndexCtrl(nissanApi
                       , $state
                       , Mensajes
                       , Loader) {
        var vm = this;

        Loader.Cargar();

        vm.listarInformesInspeccion = function(){
            nissanApi.listarInformesInspeccion()
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

                nissanApi.anular(id)
                .success(function (data) {
                    Loader.Cerrar();

                    if (data.Status == 200) {
                        Mensajes.MensajeCorrecto("Informe Anulado", vm.index);
                    }
                    //vm.index();
                });

            }
        }

        vm.listarInformesInspeccion();
    };
}());