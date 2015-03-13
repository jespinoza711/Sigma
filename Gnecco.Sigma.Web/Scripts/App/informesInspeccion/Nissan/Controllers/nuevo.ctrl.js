(function(){
    'use strict';

    angular.module("informesInspeccion.nissan")
        .controller("nuevoCtrl",
            ["nissanApi"
             , "Mensajes"
             , "Loader"
             ,"$state"
            ,NuevoCtrl]);

    function NuevoCtrl(nissanApi
                        ,Mensajes
                        ,Loader
                       , $state) {

        var vm = this;
        vm.model = {};
        vm.estaModoEdicion = true;

        //vm.model.DetallesAnulados = [];
        //vm.model.GruposAnulados = [];
        vm.model.Grupos = [];
        vm.model.GruposCalidad = [];
        vm.model.GruposEspeciales = [];
        vm.model.Descripcion = "Default";
        vm.model.DetallesAnulados = [];

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

            nissanApi.guardar(vm.model)
            .success(function(data){
                console.log(data);
                Loader.Cerrar();
                Mensajes.MensajeCorrecto(data.Mensaje, vm.index);
            });
        }

        vm.index = function(){
            $state.go('index');
        }

    };
}());