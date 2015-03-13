using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionFordCompletadosController : ApiController
    {
        IInformeInspeccionFordCompletoRepositorio _informeInspeccionFordCompletoRepositorio;

        public InformeInspeccionFordCompletadosController()
        {
            _informeInspeccionFordCompletoRepositorio = new InformeInspeccionFordCompletoRepositorio();
        }

        public VerCompletosViewModel Get(int id)
        {
            List<InformeInspeccionFordCompleto> informesInepeccionFordCompletos 
                = _informeInspeccionFordCompletoRepositorio
                .BuscarInformesInspeccionCompletoDeInformeInspeccion(id);
            VerCompletosViewModel verCompletosViewModel = new VerCompletosViewModel();
            verCompletosViewModel.MapearDesde(informesInepeccionFordCompletos);
            return verCompletosViewModel;
        }
    }
}
