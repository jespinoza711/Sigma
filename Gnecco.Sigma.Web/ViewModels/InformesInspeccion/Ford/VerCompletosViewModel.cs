using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford
{
    public class VerCompletosViewModel
    {
        public List<InformeInspeccionFordCompletoViewModel> InformesInspeccionCompleto { get; set; }

        public VerCompletosViewModel()
        {
            InformesInspeccionCompleto = new List<InformeInspeccionFordCompletoViewModel>();
        }

        public void MapearDesde(List<InformeInspeccionFordCompleto> informesInspeccionFordCompleto)
        {
            InformesInspeccionCompleto.Clear();

            foreach (var informeInspeccionFordCompleto in informesInspeccionFordCompleto)
            {
                InformesInspeccionCompleto.Add(new InformeInspeccionFordCompletoViewModel(informeInspeccionFordCompleto));
            }
        }

        public class InformeInspeccionFordCompletoViewModel
        {
            public int Id { get; set; }
            public string NombreCliente { get; set; }
            public string Fecha { get; set; }
            public string NombreTecnico { get; set; }

            public InformeInspeccionFordCompletoViewModel(InformeInspeccionFordCompleto informeInspeccionFordCompleto)
            {
                MapearDesde(informeInspeccionFordCompleto);
            }
            public void MapearDesde(InformeInspeccionFordCompleto informeInspeccionFordCompleto)
            {
                Id = informeInspeccionFordCompleto.Id;
                NombreCliente = informeInspeccionFordCompleto.Cliente.Nombre;
                Fecha = informeInspeccionFordCompleto.Fecha.ToShortDateString();
                NombreTecnico = informeInspeccionFordCompleto.Tecnico;
            }
        }
    }
}