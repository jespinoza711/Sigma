using Gnecco.Sigma.Core.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.Inventario
{
    public class InventarioListadoViewModel
    {
        public int Id { get; set; }
        public string NumeroOT { get; set; }
        public string Asesor { get; set; } // no default
        public string FechaRecepcion { get; set; }
        public string Placa { get; set; }
        public string Propietario { get; set; }
        public string Dni { get; set; }
    }

    public class InventarioListadoViewModelHanlder
    {
        public List<InventarioListadoViewModel> Inventarios { get; set; }

        public void MapearDesde(List<InventarioVehiculo> inventariosVehiculos)
        {
            this.Inventarios = (
                from I in inventariosVehiculos
                select new InventarioListadoViewModel
                {
                    Id = I.Id,
                    NumeroOT = I.NumeroOT,
                    Asesor = I.Asesor,
                    Dni = I.Dni,
                    FechaRecepcion = I.FechaRecepcion,
                    Placa = I.Placa,
                    Propietario = I.Propietario
                }
            ).ToList();
        }

    }
}