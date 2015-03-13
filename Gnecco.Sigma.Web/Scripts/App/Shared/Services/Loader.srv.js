(function () {
    'use strict';

    angular.module("shared.utils")
        .factory("Loader",
                [Loader]);

    function Loader() {
        var Loader = {};

        Loader.Cargar = function () {
            window.loading_screen = window.pleaseWait({
                logo: "/Images/logo-sistema.png",
                backgroundColor: '#1d8bc2',
                loadingHtml: "<div class='sk-spinner sk-spinner-wave'><div class='sk-rect1'></div><div class='sk-rect2'></div><div class='sk-rect3'></div><div class='sk-rect4'></div><div class='sk-rect5'></div></div>"
            });
        };

        Loader.Cerrar = function () {
            window.loading_screen.finish();
        };

        return Loader;
    }

}());