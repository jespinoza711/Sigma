(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .directive('tablaGrupoEspecial',function(){
            return {
                templateUrl : '/Scripts/App/InformesInspeccion/Nissan/Templates/tablaGrupoEspecial.tpl.html',
                restrict : 'E',
                scope : {
                    gruposEspeciales: '=',
                    agregarGrupoEspecial: '=',
                    agregarDetalleAccesorios: '=',
                    estaModoEdicion: '=',
                    eliminarDetalle: '='
                }
            }
        });
}());