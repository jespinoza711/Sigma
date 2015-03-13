using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionCompletoListadoNissanViewModel
    {
        public int Id { get; set; }
        public int InformeInspeccionId { get; set; }
        public string Cliente { get; set; }
        public string FechaMantenimiento { get; set; }
        public string Tecnico { get; set; }
    }

    public class InformeInspeccionCompletoListadoNissanViewModelHandler
    {
        public List<InformeInspeccionCompletoListadoNissanViewModel> insformesInspeccionCompletos { get; set; }

        public void MapearDesde(List<InformeInspeccionNissanCompleto> informeInspeccionNissanCompleto)
        {
            this.insformesInspeccionCompletos = (
                from I in informeInspeccionNissanCompleto
                select new InformeInspeccionCompletoListadoNissanViewModel
                {
                    Id = I.Id,
                    InformeInspeccionId = I.InformeInspeccionId,
                    Cliente = I.Cliente,
                    FechaMantenimiento = I.Fecha.ToString(),
                    Tecnico = I.Tecnico
                }
            ).ToList();
        }
    }
}