(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .controller("verCompletadosCtrl",
            ["nissanApi"
            , "$state"
            , "$stateParams"
            , "Loader"
            , verCompletadosCtrl]);

    function verCompletadosCtrl(nissanApi
                       , $state
                       , $stateParams
                       , Loader) {

        Loader.Cargar();

        var vm = this;

        vm.index = function(){
            $state.go('index');
        }

        vm.listarFormatos = function () {
            var id = $stateParams.id;
            nissanApi.verCompletados(id)
            .success(function (data) {
                vm.informesInspeccion = data;
                console.log(vm.informesInspeccion);
                Loader.Cerrar();
            });
        }

        vm.verReporte = function (id) {
            $state.go('verReporte', { id: id })
        }

        vm.listarFormatos();
        
    };
}());