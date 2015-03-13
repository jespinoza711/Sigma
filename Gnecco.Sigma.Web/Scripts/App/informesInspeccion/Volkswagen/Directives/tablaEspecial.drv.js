(function () {
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .directive('tablaEspecial', function () {
            return {
                templateUrl: '/Scripts/App/InformesInspeccion/Volkswagen/Templates/tablaEspecial.tpl.html',
                restrict: 'E',
                scope: {
                    model: '=',
                    estaModoEdicion: '=',
                    agregarFilaEspecial: '=',
                    eliminarFilaEspecial: '='
                }
            }
        });
}());