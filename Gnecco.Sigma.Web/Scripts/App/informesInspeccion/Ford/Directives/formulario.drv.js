(function () {
    'use strict';

    angular.module("informesInspeccion.ford")
        .directive('formulario', function () {
            return {
                templateUrl: '/Scripts/App/InformesInspeccion/Ford/Templates/formulario.tpl.html',
                restrict: 'E',
                scope: {
                    vm: '='
                },
                controller: function ($scope) {                    
                    $scope.NombreSubGrupoSistemaComponente = "";
                    $scope.NombreSubGrupoDesgasteFreno = "";

                    $scope.GrupoArticuloMantenimiento = {
                        AgregarDetalle : function () {
                            var nuevoDetalle = {};
                            angular.copy($scope.vm.NuevoDetalleGrupoArticuloMantenimiento, nuevoDetalle);
                            $scope.vm.Model.GrupoArticuloMantenimiento.Detalle.push(
                                nuevoDetalle
                            );
                        },
                        EliminarDetalle : function (index,detalle) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                $scope.vm.Model.DetalleGrupoArticuloMantenimientoAnulado.push(detalle.Id);
                                $scope.vm.Model.GrupoArticuloMantenimiento.Detalle.splice(index, 1);
                            }
                        }
                    }

                    $scope.GrupoSistemaComponente = {
                        AgregarSubGrupo: function () {
                            var nuevoSubGrupo = {};
                            angular.copy($scope.vm.NuevoSubGrupoSistemaComponente, nuevoSubGrupo);
                            nuevoSubGrupo.Descripcion = $scope.NombreSubGrupoSistemaComponente;
                            $scope.vm.Model.GrupoSistemaComponente.SubGrupos.push(
                                nuevoSubGrupo
                            );
                            $scope.NombreSubGrupoSistemaComponente = "";
                        },
                        EliminarSubGrupo: function (index,subGrupo) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                if (confirm("Al Eliminar este Sistema/Componente se eliminaran todos los Detalles que contenga ¿Esta seguro que desea eliminar este registro?"))
                                {
                                    $scope.vm.Model.SubGrupoSistemaComponenteAnulado.push(subGrupo.Id);
                                    $scope.vm.Model.GrupoSistemaComponente.SubGrupos.splice(index, 1);
                                }
                            }
                        },
                        AgregarDetalle: function (subGrupo) {
                            var nuevoDetalle = {};
                            angular.copy($scope.vm.NuevoDetalleGrupoSistemaComponente, nuevoDetalle);
                            subGrupo.Detalle.push(
                                nuevoDetalle
                            );
                        },
                        EliminarDetalle: function (index, subGrupo, detalle) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                $scope.vm.Model.DetalleGrupoSistemaComponenteAnulado.push(detalle.Id);
                                subGrupo.Detalle.splice(index, 1);
                            }
                        }
                    }

                    $scope.GrupoDesgasteLlanta = {
                        AgregarDetalle: function () {
                            var nuevoDetalle = {};
                            angular.copy($scope.vm.NuevoDetalleGrupoDesgasteLlanta, nuevoDetalle);
                            $scope.vm.Model.GrupoDesgasteLlanta.Detalle.push(
                                nuevoDetalle
                            );
                        },
                        EliminarDetalle: function (index, detalle) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                $scope.vm.Model.DetalleGrupoDesgasteLlantaAnulado.push(detalle.Id);
                                $scope.vm.Model.GrupoDesgasteLlanta.Detalle.splice(index, 1);
                            }
                        }
                    }

                    $scope.GrupoDesgasteFreno = {
                        AgregarSubGrupo: function () {
                            var nuevoSubGrupo = {};
                            angular.copy($scope.vm.NuevoSubGrupoDesgasteFreno, nuevoSubGrupo);
                            nuevoSubGrupo.Descripcion = $scope.NombreSubGrupoDesgasteFreno;
                            $scope.vm.Model.GrupoDesgasteFreno.SubGrupos.push(
                                nuevoSubGrupo
                            );
                            $scope.NombreSubGrupoDesgasteFreno = "";
                        },
                        EliminarSubGrupo: function (index, subGrupo) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                if (confirm("Al Eliminar este Sistema/Componente se eliminaran todos los Detalles que contenga ¿Esta seguro que desea eliminar este registro?"))
                                {
                                    $scope.vm.Model.SubGrupoDesgasteFrenoAnulado.push(subGrupo.Id);
                                    $scope.vm.Model.GrupoDesgasteFreno.SubGrupos.splice(index, 1);
                                }
                            }
                        },
                        AgregarDetalle: function (subGrupo) {
                            var nuevoDetalle = {};
                            angular.copy($scope.vm.NuevoDetalleGrupoDesgasteFreno, nuevoDetalle);
                            subGrupo.Detalle.push(
                                nuevoDetalle
                            );
                        },
                        EliminarDetalle: function (index, subGrupo, detalle) {
                            if (confirm("¿Realmente desea eliminar este registro?")) {
                                $scope.vm.Model.DetalleGrupoDesgasteFrenoAnulado.push(detalle.Id);
                                subGrupo.Detalle.splice(index, 1);
                            }
                        }
                    }
                    
                }
            }
        });
}());