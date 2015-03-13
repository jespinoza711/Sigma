(function(){
    'use strict';

    angular.module("shared.volkswagenApi",[])
        .factory("volkswagenApi",
                ["$http",
                 volkswagenApi]);

    function volkswagenApi($http)
    {
    	var volkswagenApi = {};
        
        volkswagenApi.listarInformesInspeccion = function()
        {
        	return $http.get("/api/InformeInspeccion/Volkswagen");
        }

        volkswagenApi.modificar = function (informeInspeccion) {
            return $http.put("/api/InformeInspeccion/Volkswagen", informeInspeccion);
        }

        volkswagenApi.anular = function (id) {
            return $http.delete("/api/InformeInspeccion/Volkswagen/" + id);
        }

    	volkswagenApi.guardar = function(informeInspeccion)
    	{
    	    return $http.post("/api/InformeInspeccion/Volkswagen", informeInspeccion);
    	}

    	volkswagenApi.verCompletados = function (id) {
    	    return $http.get("/api/InformeInspeccion/Volkswagen/Completados/" + id);
    	}

        volkswagenApi.buscarInformeInspeccion = function(id)
        {
            return $http.get("/api/InformeInspeccion/Volkswagen/" + id)
        }

        volkswagenApi.completar = function (model) {
            return $http.post("/api/InformeInspeccionCompleto/Volkswagen", model);
        }

        volkswagenApi.listarInformesInspeccionCompleto = function (id) {
            return $http.get("/api/InformeInspeccionCompleto/Volkswagen/" + id);
        }

        volkswagenApi.buscarCliente = function (ot) {
            return $http.get("/api/SapView/" + ot);
        }
        

		return volkswagenApi;
    }

}());