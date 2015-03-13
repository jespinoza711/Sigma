using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionModificarViewModel
    {
        public int InformeInspeccionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<DetallesModificarViewModel> Detalles { get; set; }
        public List<DetallesModificarViewModel> DetallesAnulados { get; set; }
        public List<OpcionesModificarViewModel> OpcionesAnulados { get; set; }

        public InformeInspeccionModificarViewModel()
        {
            Detalles = new List<DetallesModificarViewModel>();
            DetallesAnulados = new List<DetallesModificarViewModel>();
            OpcionesAnulados = new List<OpcionesModificarViewModel>();
        }
    }

    public class DetallesModificarViewModel
    {
        public int Id { get; set; } //Id del Detalle
        public string Descripcion { get; set; }
        public List<OpcionesModificarViewModel> OpcionesCondicion { get; set; }
        public List<OpcionesModificarViewModel> OpcionesInternas { get; set; }
        public List<OpcionesModificarViewModel> OpcionesIntervaloKm { get; set; }
    }

    public class OpcionesModificarViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}