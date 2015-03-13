using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class CompletadosNissanController : ApiController
    {
        public object Get(int id)
        {
            IInformeInspeccionNissanCompletoRepositorio _informInspeccionNissanCompletoRepositorio
                = new InformeInspeccionNissanCompletoRepositorio();
            List<InformeInspeccionNissanCompleto> informesInspeccionNissanCompleto
                = _informInspeccionNissanCompletoRepositorio.ListarInformesInspeccion(id);
            InformeInspeccionCompletoListadoNissanViewModelHandler handler
                = new InformeInspeccionCompletoListadoNissanViewModelHandler();
            handler.MapearDesde(informesInspeccionNissanCompleto);
            return handler.insformesInspeccionCompletos;
        }
    }
}
