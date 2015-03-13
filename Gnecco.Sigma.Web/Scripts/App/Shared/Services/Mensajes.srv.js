(function () {
    'use strict';

    angular.module("shared.utils", [])
        .factory("Mensajes",
                [Mensajes]);

    function Mensajes() {
        var Mensajes = {};

        Mensajes.MensajeCorrecto = function (mensaje,callback) {
            swal({
                title: mensaje,
                
                type: "success",
                confirmButtonColor: "#1D8BC2",
                confirmButtonText: "Ok !"
            },
            callback);
        };

        Mensajes.MensajeError = function (mensaje) {
            swal({
                title: mensaje,

                type: "error",
                confirmButtonColor: "#e74c3c",
                confirmButtonText: "OK"
            });
        };

        return Mensajes;
    }

}());