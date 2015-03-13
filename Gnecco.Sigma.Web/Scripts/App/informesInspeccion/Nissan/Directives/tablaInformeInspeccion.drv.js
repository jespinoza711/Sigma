(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .directive('tablaInformeInspeccion',function(){
            return {
                templateUrl : '/Scripts/App/InformesInspeccion/Nissan/Templates/tablaInformeInspeccion.tpl.html',
                restrict : 'E',
                scope : {
                    grupos: '=',
                    agregarGrupo: '=',
                    agregarDetalle: '=',
                    estaModoEdicion: '=',
                    eliminarDetalle: '='
                }
            }
        });
}());