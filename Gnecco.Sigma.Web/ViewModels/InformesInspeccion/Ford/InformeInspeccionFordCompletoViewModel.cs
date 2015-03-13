using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford
{
    public class InformeInspeccionFordCompletoViewModel
    {
        public string NombreCliente { get; set; }
        public string CorreoElectronico { get; set; }
        public string Fecha { get; set; }
        public string RoTag { get; set; }
        public string MesInspeccionEstatal { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Millaje { get; set; }
        public string Vin { get; set; }
        public string Placa { get; set; }

        public List<DetalleViewModel> DetalleGrupoArticuloMantenimiento { get; set; }
        public List<DetalleViewModel> DetalleGrupoSistemaComponente { get; set; }
        public List<DetalleViewModel> DetalleGrupoDesgasteFreno { get; set; }
        public List<DetalleViewModel> DetalleGrupoDesgasteLlanta { get; set; }

        public InformeInspeccionFordCompletoViewModel()
        {
            DetalleGrupoArticuloMantenimiento = new List<DetalleViewModel>();
            DetalleGrupoDesgasteFreno = new List<DetalleViewModel>();
            DetalleGrupoDesgasteLlanta = new List<DetalleViewModel>();
            DetalleGrupoSistemaComponente = new List<DetalleViewModel>();
        }

        public class DetalleViewModel
        {
            public int Id { get; set; }
            public List<OpcionViewModel> Opciones { get; set; }

            public DetalleViewModel()
            {
                Opciones = new List<OpcionViewModel>();
            }
        }

        public class OpcionViewModel
        {
            public int Id { get; set; }
            public string Valor { get; set; }
        }
    }
}