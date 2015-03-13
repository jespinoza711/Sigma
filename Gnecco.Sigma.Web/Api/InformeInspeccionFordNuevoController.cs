using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionFordNuevoController : ApiController
    {
        [HttpGet]
        public InformeInspeccionFordViewModel Get()
        {
            InformeInspeccionFordViewModel informeInspeccionFordViewModel = new InformeInspeccionFordViewModel();
            informeInspeccionFordViewModel.EstaEdicion = true;
            return informeInspeccionFordViewModel;
        }
    }
}
