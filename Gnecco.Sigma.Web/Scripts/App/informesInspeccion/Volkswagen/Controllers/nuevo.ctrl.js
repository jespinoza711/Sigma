(function(){
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("nuevoCtrl",
            ["volkswagenApi"
            ,"Mensajes"
            ,"$state"
            ,NuevoCtrl]);

    function NuevoCtrl(volkswagenApi
                        ,Mensajes
                       ,$state){
        var vm = this;
        vm.model = {};
        vm.estaModoEdicion = true;

        vm.model.Detalles = [];
        vm.model.FilaEspecial = [];
        vm.model.DetallesAnulados = [];
        vm.model.OpcionesAnulados = [];
        vm.model.FilasAnuladas = [];
        vm.model.Descripcion = "";
        vm.model.OpcionesIntervaloKm = [];


       vm.agregarFila = function () {
            vm.model.Detalles.push({
                Descripcion: "",
                OpcionesCondicion: [
                    {
                        "Descripcion": "Ok",
                    },
                    {
                        "Descripcion": "No Ok",
                    },
                    {
                        "Descripcion": "Corregido",
                    }
                ],
                OpcionesInternas: [],
                OpcionesIntervalokm: [
                    {
                        "Descripcion": "Intervalo km"
                    }
                ]
            });
        };

        vm.eliminarFilaEspecial = function (index) {
            if (confirm("Realmente desea eliminar esta fila?")) {
                vm.model.FilasAnuladas.push(vm.model.FilaEspecial[index]);
                vm.model.FilaEspecial.splice(index, 1);
            }
        }

        vm.guardar = function(){
            volkswagenApi.guardar(vm.model)
            .success(function(data){
                Mensajes.MensajeCorrecto("Informe guardado", vm.index)

            });
        }

        vm.index = function(){
            $state.go('index');
        }

    };
}());