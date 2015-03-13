using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionResumenNissanViewModelHandler
    {
        public List<InformeInspeccionResumenNissanViewModel> InformesInspeccionResumen { get; set; }

        public void MapearDesde(List<InformeInspeccionNissan> informeInspeccion)
        {
            this.InformesInspeccionResumen = (
                from R in informeInspeccion
                select new InformeInspeccionResumenNissanViewModel
                {
                    Id = R.Id.ToString(),
                    Nombre = R.Nombre,
                    FechaCreacion = R.FechaCreacion.ToShortDateString(),
                    Estado = R.IndicadorEstado == "A" ? "Activo" : "Inactivo"
                }
            ).ToList();
        }
    }

    public class InformeInspeccionResumenNissanViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
    }
}