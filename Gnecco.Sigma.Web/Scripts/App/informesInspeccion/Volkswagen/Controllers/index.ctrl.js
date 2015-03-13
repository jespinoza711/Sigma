(function(){
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("indexCtrl",
            ["volkswagenApi"
            , "$state"
            , "Mensajes"
            , "Loader"
            ,IndexCtrl]);

    function IndexCtrl(volkswagenApi
                       , $state
                       , Mensajes
                       , Loader) {

        Loader.Cargar();

        var vm = this;

        vm.listarInformesInspeccion = function(){
            volkswagenApi.listarInformesInspeccion()
            .success(function(data){
                vm.informesInspeccion = data;
                Loader.Cerrar();
            });
        }

        vm.index = function () {
            $state.go('index');
        }

        vm.nuevo = function(){
            $state.go('nuevo');
        }

        vm.ver = function (id) {
            $state.go('ver', {id:id})
        }

        vm.verCompletados = function(id){
            $state.go('verCompletados', {id:id})
        }

        vm.completar = function(id){
            $state.go('completar',{id:id})
        }

        vm.anular = function (id) {
            if (confirm("Realmente desea anular el informe?")) {
                Loader.Cargar();

                volkswagenApi.anular(id)
                .success(function (data) {
                    Loader.Cerrar();

                    if (data.Status == 200)
                    {
                        Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                    }
                    //vm.index();
                });
                
            }
        }

        vm.listarInformesInspeccion();
    };
}());