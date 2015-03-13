(function(){
    'use strict';

    angular.module("shared.nissanApi",[])
        .factory("nissanApi",
                ["$http",
                 nissanApi]);

    function nissanApi($http)
    {
    	var nissanApi = {};
        
        nissanApi.listarInformesInspeccion = function()
        {
        	return $http.get("/api/InformeInspeccion/Nissan");
        }

        nissanApi.modificar = function (informeInspeccion) {
            return $http.put("/api/InformeInspeccion/Nissan", informeInspeccion);
        }

        nissanApi.anular = function (id) {
            return $http.delete("/api/InformeInspeccion/Nissan/" + id);
        }

    	nissanApi.guardar = function(informeInspeccion)
    	{
    	    return $http.post("/api/InformeInspeccion/Nissan", informeInspeccion);
    	    console.log(informeInspeccion);
    	}

    	nissanApi.verCompletados = function (id) {
    	    return $http.get("/api/CompletadosNissan/" + id);
    	}

        nissanApi.buscarInformeInspeccion = function(id)
        {
            return $http.get("/api/InformeInspeccion/Nissan/" + id)
        }

        nissanApi.completar = function (model) {
            return $http.post("/api/InformeInspeccionCompleto/Nissan", model);
        }

        nissanApi.listarInformesInspeccionCompleto = function (id) {
            return $http.get("/api/InformeInspeccionCompleto/Nissan/" + id);
        }

        nissanApi.buscarCliente = function (ot) {
            return $http.get("/api/SapView/" + ot);
        }

        return nissanApi;
    }

}());