(function(){
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("verCompletadosCtrl",
            ["volkswagenApi"
            , "$state"
            , "$stateParams"
            , "Loader"
            ,verCompletadosCtrl]);

    function verCompletadosCtrl(volkswagenApi
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
            volkswagenApi.verCompletados(id)
            .success(function (data) {
                vm.informesInspeccion = data;
                console.log(data);
                Loader.Cerrar();
            });
        }

        //vm.verReporte = function () {
        //    var id = vm.informesInspeccion.id;
        //    volkswagenApi.listarInformesInspeccionCompleto(id)
        //    .success(function (data) {
        //        vm.informes = data;
        //        console.log(vm.informes);
        //    })
        //}

        vm.verReporte = function (id) {
            $state.go('verReporte', { id: id })
        }

        vm.listarFormatos();
    };
}());