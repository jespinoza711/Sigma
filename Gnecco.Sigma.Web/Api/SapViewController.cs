using Gnecco.Sigma.Core.Shared.SAP;
using Gnecco.Sigma.Datos.Sap.Reporsitorios;
using Gnecco.Sigma.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class SapViewController : ApiController
    {
        // El ID viene ser "OT", por standart REST se usara ID
        // ID = OT
        public IEnumerable<SapViewModel> Get(int id)
        {
            SapViewRepositorio _sap = new SapViewRepositorio();
            List<ViewSap> listado = _sap.ListarByOT(id);
            SapViewModelHandler listado2 = new SapViewModelHandler();
            listado2.MapearDesde(listado);
            return listado2.Listado;
        }
    }
}
