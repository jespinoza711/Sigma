(function(){
    'use strict';

    angular.module("shared.fordApi",[])
        .factory("fordApi",
                ["$http",
                 fordApi]);

    function fordApi($http)
    {
        var fordApi = {};

        fordApi.nuevo = function () {
            return $http.get("/api/InformeInspeccionFordNuevo");
        }
        
    	fordApi.listarInformesInspeccion = function ()
        {
        	return $http.get("/api/InformeInspeccion/Ford");
        }

    	fordApi.modificar = function (informeInspeccion) {
    	    return $http.put("/api/InformeInspeccion/Ford", informeInspeccion);
        }

    	fordApi.anular = function (id) {
    	    return $http.delete("/api/InformeInspeccion/Ford/" + id);
        }

    	fordApi.guardar = function (informeInspeccion)
    	{
    	    return $http.post("/api/InformeInspeccion/Ford", informeInspeccion);
    	}

    	fordApi.verCompletados = function (id) {
    	    return $http.get("/api/InformeInspeccionFordCompletados/" + id);
    	}

    	fordApi.buscarInformeInspeccion = function (id)
        {
    	    return $http.get("/api/InformeInspeccion/Ford/" + id)
        }

    	fordApi.completar = function (model) {
    	    return $http.post("/api/InformeInspeccionCompleto/Ford", model);
        }

    	fordApi.verInformeParaCompletar = function (id) {
    	    return $http.get("/api/InformeInspeccionCompleto/Ford/" + id);
    	}

    	fordApi.buscarCliente = function (ot) {
    	    return $http.get("/api/SapView/" + ot);
    	}


    	return fordApi;
    }

}());