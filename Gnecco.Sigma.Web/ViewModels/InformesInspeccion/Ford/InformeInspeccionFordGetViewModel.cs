using System.Collections.Generic;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford
{
    public class InformeInspeccionFordGetViewModel
    {
        public List<InformeInspeccionFordViewModel> InformesInspeccion { get; set; }

        public InformeInspeccionFordGetViewModel()
        {
            InformesInspeccion = new List<InformeInspeccionFordViewModel>();
        }

        public void MapearDesde(List<InformeInspeccionFord> informesInspeccionFord)
        {
            foreach (var informeInspeccionFord in informesInspeccionFord)
            {
                InformesInspeccion.Add(new InformeInspeccionFordViewModel(informeInspeccionFord));
            }
        }
        public class InformeInspeccionFordViewModel
        {
            public int Id { get; set; }
            public string NombreInforme { get; set; }
            public string FechaCreacion { get; set; }
            public string Estado { get; set; }

            public InformeInspeccionFordViewModel(InformeInspeccionFord informeInspeccionFord)
            {
                Id = informeInspeccionFord.Id;
                NombreInforme = informeInspeccionFord.Nombre;
                FechaCreacion = informeInspeccionFord.FechaCreacion.ToShortDateString();
                Estado = informeInspeccionFord.IndicadorEstado;
            }
        }
    }
}