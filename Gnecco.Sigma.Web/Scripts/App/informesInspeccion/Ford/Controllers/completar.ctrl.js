(function(){
    'use strict';

    angular.module("informesInspeccion.ford")
        .controller("completarCtrl",
            ["fordApi"
            , "Mensajes"
            , "$state"
            , "$stateParams"
            , "Loader"
            ,completarCtrl]);

    function completarCtrl(fordApi
                       , Mensajes
                       , $state
                       , $stateParams
                       , Loader) {
        var vm = this;
        Loader.Cargar();

        vm.verInformeParaCompletar = function () {
            var id = $stateParams.id;
            fordApi.buscarInformeInspeccion(id)
            .success(function(data){
                vm.Model = data.Model;
                vm.Model.InformeInspeccionId = id;
                console.log(vm.Model);
                vm.EstaEdicion = false;
                Loader.Cerrar();
            });
        }

        vm.buscarCliente = function () {
            console.log("aasda");
            var ot = vm.model.OT;
            fordApi.buscarCliente(ot)
            .success(function (data) {
                vm.resultados = data;
                console.log(vm.resultados);
                $('#modalOT').modal('hide');
                $('#modalDiscriminador').modal('show');
            });
        }

        vm.cargarDatos = function (resultado) {
            $('#modalDiscriminador').modal('hide');
            vm.Model.CLIENTE = resultado.CLIENTE;
            vm.Model.OT = resultado.OT;
            vm.Model.FECHAINGRESO = resultado.FECHAINGRESO;
            vm.Model.HORAINGRESO = resultado.HORAINGRESO;
            vm.Model.PLACA = resultado.PLACA;
            vm.Model.KMLLEGADA = resultado.KMLLEGADA;
            vm.Model.FECHAPROMETIDA = resultado.FECHAPROMETIDA;
            vm.Model.HORAPROMETIDA = resultado.HORAPROMETIDA;
            vm.Model.DNIRUC = resultado.DNIRUC;
            vm.Model.DIRECCION = resultado.DIRECCION;
            vm.Model.EMAIL = resultado.EMAIL;
            vm.Model.TELEFONO = resultado.TELEFONO;
            vm.Model.COMP = resultado.COMP;
            vm.Model.ID = resultado.ID;
            vm.Model.VIN = resultado.VIN;
            vm.Model.MILLAJE = resultado.MILLAJE;
            vm.Model.MODELO = resultado.MODELO;
            vm.Model.ANIO = resultado.ANIO;
            vm.Model.MESINPECCIONESTATAL = resultado.MESINPECCIONESTATAL;
            console.log(vm.model);

        }

        vm.completar = function () {
            Loader.Cargar();
            fordApi.completar(JSON.stringify(vm.Model))
            .success(function (data) {
                if (data.Status == 200) {
                    Mensajes.MensajeCorrecto(data.Mensaje, function () {
                        $state.go('index');
                        console.log(vm.Model);
                    });
                }
                Loader.Cerrar();
            });
        }

        vm.CrearModelCompletado = function(){

            vm.ModelCompletado.DetalleGrupoArticuloMantenimiento = [];
            vm.ModelCompletado.DetalleGrupoDesgasteFreno = [];
            vm.ModelCompletado.DetalleGrupoDesgasteLlanta = [];
            vm.ModelCompletado.DetalleGrupoSistemaComponente = [];

            var CrearOpciones = function(opciones){
                var opcionesCreadas = [];
                angular.forEach(opciones,function(opcion){
                    opcionesCreadas.push({ Id : opcion.Id, Valor : opcion.Valor });
                });
                return opcionesCreadas;
            }

            angular.forEach(vm.Model.GrupoArticuloMantenimiento.Detalle,function(detalle){             

                var opcionesDesgaste = CrearOpciones(detalle.OpcionesDesgaste);
                var opcionesReparacion = CrearOpciones(detalle.OpcionesReparacion);

                vm.ModelCompletado.DetalleGrupoArticuloMantenimiento.push({
                    Id: detalle.Id,
                    Opciones: opcionesDesgaste.concat(opcionesReparacion)
                });
            });

            angular.forEach(vm.Model.GrupoDesgasteFreno.SubGrupos, function (subGrupo) {

                angular.forEach(subGrupo.Detalle, function (detalle) {
                    var opcionesAtencion = CrearOpciones(detalle.OpcionesAtencion);
                    var opcionesReparacion = CrearOpciones(detalle.OpcionesReparacion);

                    vm.ModelCompletado.DetalleGrupoDesgasteFreno.push({
                        Id: detalle.Id,
                        Opciones : opcionesAtencion.concat(opcionesReparacion)
                    });
                });

            });

            angular.forEach(vm.Model.GrupoDesgasteLlanta.Detalle, function (detalle) {
                var opcionesDesgaste = CrearOpciones(detalle.OpcionesDesgaste);
                var opcionesReparacion = CrearOpciones(detalle.OpcionesReparacion);

                vm.ModelCompletado.DetalleGrupoDesgasteLlanta.push({
                    Id: detalle.Id,
                    Opciones: opcionesDesgaste.concat(opcionesReparacion)
                });
            });

            angular.forEach(vm.Model.GrupoSistemaComponente.SubGrupos, function (subGrupo) {
                angular.forEach(subGrupo.Detalle, function (detalle) {

                    var opcionesAtencion = CrearOpciones(detalle.OpcionesAtencion);
                    var opcionesReparacion = CrearOpciones(detalle.OpcionesReparacion);

                    vm.ModelCompletado.DetalleGrupoSistemaComponente.push({
                        Id: detalle.Id,
                        Opciones: opcionesAtencion.concat(opcionesReparacion)
                    });
                });
            });
        }

        vm.verInformeParaCompletar();
    };
}());