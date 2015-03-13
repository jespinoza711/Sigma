using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionResumenViewModelHandler
    {
        public List<InformeInspeccionResumenViewModel> InformesInspeccionResumen { get; set; }

        public void MapearDesde(List<InformeInspeccionVolkswagen> informeInspeccionVolkwagen)
        {
            this.InformesInspeccionResumen = (
                from R in informeInspeccionVolkwagen
                select new InformeInspeccionResumenViewModel
                {
                    Id = R.Id.ToString(),
                    Nombre = R.Nombre,
                    FechaCreacion = R.FechaCreacion.ToShortDateString(),
                    Estado = R.IndicadorEstado == "A" ? "Activo" : "Inactivo"
                }
            ).ToList();
        }
    }

    public class InformeInspeccionResumenViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
    }
}