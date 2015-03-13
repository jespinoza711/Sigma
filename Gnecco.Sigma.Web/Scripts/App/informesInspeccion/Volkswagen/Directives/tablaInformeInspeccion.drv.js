(function(){
    'use strict';

    angular.module("informesInspeccion.volkswagen")
        .directive('tablaInformeInspeccion',function(){
            return {
                templateUrl : '/Scripts/App/InformesInspeccion/Volkswagen/Templates/tablaInformeInspeccion.tpl.html',
                restrict : 'E',
                scope : {
                    model:'=',
                    estaModoEdicion: '='
                    //agregarFila: '=',
                    //eliminarDetalle: '=',
                    //abrirModalOpcionesInternas: '=',


                },

                controller: function ($scope) {
                    
                    $scope.Detalletmp = {};
                    $scope.Descripcion = "";
                    $scope.eliminarDetalle = function (index) {
                        if (confirm("Realmente desea eliminar esta fila?")) {
                            $scope.model.DetallesAnulados.push($scope.model.Detalles[index]);
                            $scope.model.Detalles.splice(index, 1);
                        }
                    }

                    

                    $scope.abrirModalOpcionesInternas = function (Detalle) {
                        $('#modalOpcionesInternas').modal('show');
                        $scope.Detalletmp = Detalle;
                    }

                    $scope.agregarOpcionesInternas = function (Detalle) {
                        $scope.Detalletmp.OpcionesInternas.push({
                            Descripcion: $scope.Descripcion,
                            Valor: ""
                        });
                        $scope.Descripcion = "";
                        //console.log($scope.Detalletmp);
                        
                    }

                    $scope.guardarOpcionesInternas = function () {

                        $('#modalOpcionesInternas').modal('hide');
                        

                    }

                    $scope.agregarDetalleFila = function (Detalle) {
                        $scope.Detalle.OpcionesInternas.push(Detalle);
                    }

                    $scope.eliminarDetalleEspecial = function (detalle, index) {
                        if (confirm("Realmente desea eliminar este detalle?")) {
                            $scope.model.OpcionesAnulados.push(detalle.OpcionesInternas[index]);
                            detalle.OpcionesInternas.splice(index, 1);
                            console.log($scope.model.OpcionesAnulados);

                        }
                    }
                }
            }
        });
}());