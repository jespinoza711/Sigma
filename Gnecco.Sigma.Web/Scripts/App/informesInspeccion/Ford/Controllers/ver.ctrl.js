(function () {
    'use strict';

    angular.module("informesInspeccion.ford")
        .controller("verCtrl",
            ["fordApi"
             , "Mensajes"
             , "$state"
             , "$stateParams"
             , "Loader"
            , NuevoCtrl]);

    function NuevoCtrl(fordApi
                       , Mensajes
                       , $state
                       , $stateParams
                       , Loader) {
        var vm = this;

        Loader.Cargar();

        vm.buscarInformeInspeccion = function () {
            fordApi.buscarInformeInspeccion($stateParams.id)
            .success(function (data) {
                vm.Model = data.Model;
                vm.EstaEdicion = data.EstaEdicion;
                vm.NuevoDetalleGrupoArticuloMantenimiento = data.NuevoDetalleGrupoArticuloMantenimiento;
                vm.NuevoSubGrupoDesgasteFreno = data.NuevoSubGrupoDesgasteFreno;
                vm.NuevoSubGrupoSistemaComponente = data.NuevoSubGrupoSistemaComponente;
                vm.NuevoDetalleGrupoDesgasteFreno = data.NuevoDetalleGrupoDesgasteFreno;
                vm.NuevoDetalleGrupoDesgasteLlanta = data.NuevoDetalleGrupoDesgasteLlanta;
                vm.NuevoDetalleGrupoSistemaComponente = data.NuevoDetalleGrupoSistemaComponente;
                Loader.Cerrar();
            });
        }

        vm.modificar = function () {
            Loader.Cargar();
            fordApi.modificar(vm.Model)
            .success(function (data) {
                Loader.Cerrar();
                if (data.Status = 200) {
                    Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                } else {
                    Mensajes.MensajeError(data.Mensaje);
                }

            });
        }

        vm.buscarInformeInspeccion();

        vm.index = function () {
            $state.go('index');
        }

    };
}());