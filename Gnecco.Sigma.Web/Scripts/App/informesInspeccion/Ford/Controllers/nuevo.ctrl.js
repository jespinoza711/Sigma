(function () {
    'use strict';

    angular.module("informesInspeccion.ford")
        .controller("nuevoCtrl",
            ["fordApi"
             , "Mensajes"
             , "$state"
             ,"Loader"
            , NuevoCtrl]);

    function NuevoCtrl(fordApi
                       ,Mensajes
                       ,$state
                       ,Loader) {
        var vm = this;
        
        Loader.Cargar();

        vm.nuevo = function () {
            fordApi.nuevo()
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

        vm.guardar = function () {
            Loader.Cargar();
            fordApi.guardar(vm.Model)
            .success(function (data) {
                Loader.Cerrar();
                if (data.Status = 200) {
                    Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                } else {
                    Mensajes.MensajeError(data.Mensaje);
                }
                
            });
        }

        vm.nuevo();

        vm.index = function () {
            $state.go('index');
        }

    };
}());