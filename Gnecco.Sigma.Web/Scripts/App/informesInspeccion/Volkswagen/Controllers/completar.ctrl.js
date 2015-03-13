(function(){
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .controller("completarCtrl",
            ["volkswagenApi"
            ,"Mensajes"
            ,"$state"
            , "$stateParams"
            ,"Loader"
            ,completarCtrl]);

    function completarCtrl(volkswagenApi
                        ,Mensajes
                       ,$state
                       , $stateParams
                       , Loader) {
        Loader.Cargar();

        var vm = this;

        vm.model = {};
        //vm.model.descripcion = "";
        //vm.model.intervaloKilometros ="";

        vm.estaModoEdicion = false;

        vm.buscarInformeInspeccion = function(){
            var id = $stateParams.id;
            volkswagenApi.buscarInformeInspeccion(id)
            .success(function(data){
                vm.model = data;
                console.log(data);
                Loader.Cerrar();
            });
        }

        vm.buscarCliente = function () {
            console.log("aasda");
            var ot = vm.model.OT;
            volkswagenApi.buscarCliente(ot)
            .success(function (data) {
                vm.resultados = data;
                console.log(vm.resultados);
                $('#modalOT').modal('hide');
                $('#modalDiscriminador').modal('show');
            });
        }

        vm.cargarDatos = function (resultado) {
            $('#modalDiscriminador').modal('hide');
            vm.model.CLIENTE = resultado.CLIENTE;
            vm.model.OT = resultado.OT;
            vm.model.FECHAINGRESO = resultado.FECHAINGRESO;
            vm.model.HORAINGRESO = resultado.HORAINGRESO;
            vm.model.PLACA = resultado.PLACA;
            vm.model.KMS = resultado.KMS;
            vm.model.FECHAPROMETIDA = resultado.FECHAPROMETIDA;
            vm.model.HORAPROMETIDA = resultado.HORAPROMETIDA;
            vm.model.DNIRUC = resultado.DNIRUC;
            vm.model.DIRECCION = resultado.DIRECCION;
            vm.model.EMAIL = resultado.EMAIL;
            vm.model.TELEFONO = resultado.TELEFONO;
            vm.model.COMP = resultado.COMP;
            vm.model.ID = resultado.ID;
            vm.model.VIN = resultado.VIN;
            console.log(vm.model);

        }

        vm.completar = function () {
            Loader.Cargar();

            vm.model.InformeInspeccionId = $stateParams.id;
            volkswagenApi.completar(vm.model)
            .success(function (data) {
                Loader.Cerrar();
                Mensajes.MensajeCorrecto("Informe completado", vm.index)
                if (data.Status == 200)
                {
                    Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
                }
            });
        }

        

        vm.index = function () {
            $state.go('index');
        }

        vm.cancelar = function () {
            if (confirm("Realmente desea cancelar el llenado de datos?")) {
                vm.index();
            }
        }

        vm.buscarInformeInspeccion();
    };
}());