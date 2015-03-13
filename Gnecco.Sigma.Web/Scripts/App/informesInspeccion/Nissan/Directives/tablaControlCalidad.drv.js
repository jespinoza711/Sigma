(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .directive('tablaControlCalidad',function(){
            return {
                templateUrl : '/Scripts/App/InformesInspeccion/Nissan/Templates/tablaControlCalidad.tpl.html',
                restrict : 'E',
                scope : {
                    gruposCalidad: '=',
                    agregarGrupoCalidad: '=',
                    agregarDetalleCalidad: '=',
                    estaModoEdicion: '=',
                    eliminarDetalle: '='


                }
            }
        });
}());