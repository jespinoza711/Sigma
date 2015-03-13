using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionCompletoListadoViewModel
    {
        public int Id { get; set; }
        public int InformeInspeccionId { get; set; }
        public string Cliente { get; set; }
        public string FechaMantenimiento { get; set; }
        public string Tecnico { get; set; }
    }

    public class InformeInspeccionCompletoListadoViewModelHandler
    {
        public List<InformeInspeccionCompletoListadoViewModel> insformesInspeccionCompletos { get; set; }

        public void MapearDesde(List<InformeInspeccionVolkswagenCompleto> informeInspeccionVolkswagenCompleto)
        {
            this.insformesInspeccionCompletos = (
                from I in informeInspeccionVolkswagenCompleto
                select new InformeInspeccionCompletoListadoViewModel
                {
                    Id = I.Id,
                    InformeInspeccionId = I.InformeInspeccionId,
                    Cliente = I.InformacionVehiculo.Cliente,
                    FechaMantenimiento = I.Fecha.ToString(),
                    Tecnico = I.NombreTecnico
                }
            ).ToList();
        }
    }
}