(function () {
    'use strict';

    angular.module("informesInspeccion.inventarioVehiculos")
        .controller("nuevoCtrl",
            ["inventarioVehiculosApi"
            , "$state"
            , "Mensajes"
            , "Loader"
            , NuevoCtrl]);

    function NuevoCtrl(inventarioVehiculosApi
                       , $state
                       , Mensajes
                       , Loader) {

        var vm = this;
        vm.model = {};
        vm.model.Cenicero = false;
        vm.model.TapaSol = false;
        vm.model.Encendedor = false;
        vm.model.PlumillasDuchas = false;
        vm.model.Radio = false;
        vm.model.Escapines = false;
        vm.model.MascaraRadio = false;
        vm.model.EmblMascara = false;
        vm.model.Antena = false;
        vm.model.TapaAceite = false;
        vm.model.TarjetaPropiedad = false;
        vm.model.TapaTanqueComb = false;
        vm.model.Soat = false;
        vm.model.TapaRadiador = false;
        vm.model.SeguroRueda = false;
        vm.model.TapaDepRefrg = false;
        vm.model.VasosRueda = false;
        vm.model.TapaDepLiqFren = false;
        vm.model.LucesBajas = false;
        vm.model.LlantaRepuesto = false;
        vm.model.LucesAltas = false;
        vm.model.GataPalanca = false;
        vm.model.Neblineros = false;
        vm.model.LlaveRueda = false;
        vm.model.Claxon = false;
        vm.model.EmblMaletera = false;
        vm.model.Espejos = false;
        vm.model.Herramientas = false;
        vm.model.PisosJebeAlfombra = false;
        vm.model.CajaCd = false;
        vm.model.CorteCorriente = false;
        vm.model.Botiquin = false;
        vm.model.LunasElectricasDelt = false;
        vm.model.Extintor = false;
        vm.model.LunasElectricasPost = false;
        vm.model.Triangulo = false;
        vm.model.SistVentilador = false;
        vm.model.CableBateria = false;
        vm.model.Tacometro = false;
        vm.model.CableRemolque = false;

        //vm.listarInformesInspeccion = function () {
        //    inventarioVehiculosApi.listarInformesInspeccion()
        //    .success(function (data) {
        //        vm.informesInspeccion = data;
        //        console.log(vm.informesInspeccion);
        //    });
        //}

        vm.resultados = [];
        vm.model.Coordenadas = [];
        vm.model.CoordenadasGasolina = [];
        vm.model.EstadosAut = [
            {
                Valor: "Rayado"
            },
            {
                Valor: "Abollado"
            },
            {
                valor: "Falta"
            }
        ]
        
        vm.buscarCliente = function () {
            var ot = vm.model.OT;
            inventarioVehiculosApi.buscarCliente(ot)
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
            vm.model.KMLLEGADA = resultado.KMLLEGADA;
            vm.model.FECHAPROMETIDA = resultado.FECHAPROMETIDA;
            vm.model.HORAPROMETIDA = resultado.HORAPROMETIDA;
            vm.model.DNIRUC = resultado.DNIRUC;
            vm.model.DIRECCION = resultado.DIRECCION;
            vm.model.EMAIL = resultado.EMAIL;
            vm.model.TELEFONO = resultado.TELEFONO;
            vm.model.COMP = resultado.COMP;
            vm.model.ID = resultado.ID;

        }

        vm.agregarCoordenada = function () {
            var estadoTemp = $("#estadoAutoparte").val();

            EstadoAutoparte = estadoTemp;
            dibujarCirculo(clickedX, clickedY);
            var nuevaCoordenada = {
                PointLeft: Coordenadas[Coordenadas.length - 1].PointLeft,
                PointTop: Coordenadas[Coordenadas.length - 1].PointTop,
                PointRight: Coordenadas[Coordenadas.length - 1].PointRight,
                PointBottom: Coordenadas[Coordenadas.length - 1].PointBottom,
                Orden: vm.model.Coordenadas.length + 1,
                EstadoAutoparte: estadoTemp,
                Comentario: tipoEstado
            }
            vm.model.Coordenadas.push(nuevaCoordenada);
            console.log(vm.model.Coordenadas);
            $('#modalAutoparte').modal('hide');
        }

        vm.agregarCoordenadaGasolina = function () {
            dibujarCirculoGasolina(clickedX, clickedY);
            var nuevaCoordenada = {
                PointLeft: CoordenadasGasolina[CoordenadasGasolina.length - 1].PointLeft,
                PointTop: CoordenadasGasolina[CoordenadasGasolina.length - 1].PointTop,
                PointRight: CoordenadasGasolina[CoordenadasGasolina.length - 1].PointRight,
                PointBottom: CoordenadasGasolina[CoordenadasGasolina.length - 1].PointBottom,
                Orden: vm.model.Coordenadas.length + 1,
                EstadoAutoparte: "bien",
                Comentario: "comentario"
            }
            vm.model.CoordenadasGasolina.push(nuevaCoordenada);
            console.log(CoordenadasGasolina);
            $('#modalGasolina').modal('hide');
        }

        vm.eliminarCoordenada = function () {
            $('#modalAutoparte').modal('hide');
            Coordenadas.splice(Coordenadas.length - 1, 1);
            dibujarCirculos(Coordenadas);
        }

        vm.nuevo = function () {
            $state.go('nuevo');
        }

        vm.verCompletados = function () {
            $state.go('verCompletados');
        }

        vm.ver = function (id) {
            $state.go('ver', { id: id })
        }

        vm.verCompletados = function (id) {
            $state.go('verCompletados', { id: id })
        }

        vm.completar = function (id) {
            $state.go('completar', { id: id })
        }

        vm.guardar = function () {
            Loader.Cargar();
            vm.model.Base64Firma = signaturePad.toDataURL();
            inventarioVehiculosApi.guardar(vm.model)
            .success(function (data) {
                console.log(data);
                Loader.Cerrar();
                Mensajes.MensajeCorrecto("Inventario Guardado", vm.index);
            })
            .error(function (data, status) {
                Mensajes.MensajeError("Fecha erronea", vm.index);
            });
        }

        

        //vm.anular = function (id) {
        //    if (confirm("Realmente desea anular el informe?")) {
        //        Loader.Cargar();

        //        inventarioVehiculosApi.anular(id)
        //        .success(function (data) {
        //            Loader.Cerrar();

        //            if (data.Status == 200) {
        //                Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
        //            }
        //        });

        //    }
        //}

        vm.index = function () {
            $state.go('index');
        }

        vm.abrirModal = function () {
            $('#modalOT').modal('show');
        }

        //vm.buscarCliente();
    };
}());