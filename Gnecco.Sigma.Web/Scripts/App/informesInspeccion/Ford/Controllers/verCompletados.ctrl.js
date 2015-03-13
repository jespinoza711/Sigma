(function(){
    'use strict';

    angular.module("informesInspeccion.ford")
        .controller("verCompletadosCtrl",
            ["fordApi"
            , "$state"
            , "$stateParams"
            , "Loader"
            , verCompletadosCtrl]);

    function verCompletadosCtrl(fordApi
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
            fordApi.verCompletados(id)
            .success(function (data) {
                vm.InformesInspeccionCompleto = data.InformesInspeccionCompleto;
                Loader.Cerrar();
            });
        }

        vm.VerInforme = function () {
            var id = $stateParams.id;
            fordApi.listarInformesInspeccionCompleto(id)
            .success(function (data) {
                vm.informes = data;
                console.log(vm.informes);
            })
        }

        vm.listarFormatos();
        
    };
}());