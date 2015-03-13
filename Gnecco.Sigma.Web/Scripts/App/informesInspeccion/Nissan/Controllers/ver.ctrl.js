(function () {
    'use strict';

    angular.module("informesInspeccion.nissan")
        .controller("verCtrl",
            ["nissanApi"
            , "$state"
            , "$stateParams"
            , "Mensajes"
            , "Loader"
            , VerCtrl]);

    function VerCtrl(nissanApi
                       , $state
                       , $stateParams
                       , Mensajes
                       , Loader) {
        Loader.Cargar();

        var vm = this;

        vm.model = {};
        vm.estaModoEdicion = true;

        vm.index = function () {
            $state.go('index');
        }

        vm.buscarInformeInspeccion = function () {
            var id = $stateParams.id;
            nissanApi.buscarInformeInspeccion(id)
            .success(function (data) {
                vm.model = data;
                vm.model.DetallesAnulados = [];
                vm.model.GruposAnulados = [];
                vm.model.OpcionesAnulados = [];
                vm.model.Detalles = data.Detalles;
                console.log(data);
                Loader.Cerrar();
            });
        }

        vm.agregarGrupo = function () {
            vm.model.Grupos.push({
                DescripcionGrupo: vm.DescripcionGrupo,
                Detalles: []
            });
            vm.DescripcionGrupo = "";

        }

        vm.agregarGrupoEspecial = function () {
            console.log("aaa");
            vm.model.GruposEspeciales.push({
                DescripcionGrupo: vm.DescripcionGrupo,
                Detalles: []
            });
            vm.DescripcionGrupo = "";
        }

        vm.agregarGrupoCalidad = function () {
            console.log("calidad");
            vm.model.GruposCalidad.push({
                DescripcionGrupo: vm.DescripcionGrupo,
                Detalles: []
            });
            vm.DescripcionGrupo = "";
        }


        vm.agregarDetalle = function (grupo) {
            grupo.Detalles.push({
                Descripcion: "",
                OpcionesCheckRevision: [
                   {
                       "Descripcion": "Revisado Ok",
                   },
                   {
                       "Descripcion": "Requiere atencion en proxima visita",
                   },
                   {
                       "Descripcion": "Requiere atencion inmediata",
                   }
                ]
            });

        }

        vm.agregarDetalleAccesorios = function (grupo) {
            grupo.Detalles.push({
                Descripcion: "",
                OpcionesCheckRevision: [
                   {
                       "Descripcion": "Revisado Ok",
                   },
                   {
                       "Descripcion": "Requiere atencion en proxima visita",
                   },
                   {
                       "Descripcion": "Requiere atencion inmediata",
                   }
                ],
                OpcionesMedicion: [
                    {
                        "Descripcion": "mm"
                    }
                ]
            });

        }

        vm.agregarDetalleCalidad = function (grupo) {
            grupo.Detalles.push({
                Descripcion: "",
                OpcionesCheckCalidad: [
                    {
                        "Descripcion": "Ok"
                    }
                ]
            });

        }

        vm.eliminarDetalle = function (index, grupo) {
            if (confirm("Realmente desea eliminar esta fila?")) {
                debugger;
                vm.model.DetallesAnulados.push(grupo.Detalles[index])
                grupo.Detalles.splice(index, 1);
            }
            console.log(vm.model.DetallesAnulados);
        }

        vm.guardar = function () {
            Loader.Cargar();

            vm.model.InformeInspeccionId = $stateParams.id;
            nissanApi.modificar(vm.model)
            .success(function (data) {
                Loader.Cerrar();
                Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
            });
        }

        vm.buscarInformeInspeccion();
    };
}());