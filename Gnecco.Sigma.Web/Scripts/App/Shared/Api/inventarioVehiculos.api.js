(function(){
    'use strict';

    angular.module("shared.inventarioVehiculosApi",[])
        .factory("inventarioVehiculosApi",
                ["$http",
                 inventarioVehiculosApi]);

    function inventarioVehiculosApi($http)
    {
        var inventarioVehiculosApi = {};
        
    	inventarioVehiculosApi.listarInventarios = function ()
        {
        	return $http.get("/api/Inventario");
        }

    	inventarioVehiculosApi.modificar = function (informeInspeccion) {
    	    return $http.put("/api/Inventario", informeInspeccion);
        }

    	inventarioVehiculosApi.anular = function (id) {
    	    return $http.delete("/api/Inventario/" + id);
        }

    	inventarioVehiculosApi.guardar = function (inventario)
    	{
    	    return $http.post("/api/Inventario", inventario);
    	}

    	inventarioVehiculosApi.verCompletados = function (id) {
    	    return $http.get("/api/Inventario/Completados/" + id);
    	}

    	inventarioVehiculosApi.buscarInventario = function (id)
        {
    	    return $http.get("/api/Inventario/" + id)
        }

    	inventarioVehiculosApi.completar = function (model) {
    	    return $http.post("/api/Inventario", model);
        }

    	inventarioVehiculosApi.listarInformesInspeccionCompleto = function (id) {
    	    return $http.get("/api/InventarioCompleto/" + id);
    	}

    	inventarioVehiculosApi.buscarCliente = function (ot) {
    	    return $http.get("/api/SapView/" + ot);
    	}


    	return inventarioVehiculosApi;
    }

}());