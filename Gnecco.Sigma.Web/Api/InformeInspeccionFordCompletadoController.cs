using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionFordCompletadoController : ApiController
    {
        IInformeInspeccionFordRepositorio _informeInspeccionFordRepositorio;
        IInformeInspeccionFordCompletoRepositorio _informeInspeccionFordCompletoRepositorio;
        public InformeInspeccionFordCompletadoController()
        {
            _informeInspeccionFordRepositorio = new InformeInspeccionFordRepositorio();
            _informeInspeccionFordCompletoRepositorio = new InformeInspeccionFordCompletoRepositorio();
        }

        [HttpGet]
        public InformeInspeccionFordViewModel Get(int id)
        {
            //InformeInspeccionFord informeInspeccionFord = _informeInspeccionFordRepositorio.Buscar(id);
            //InformeInspeccionFordViewModel informeInspeccionFordViewModel
            //    = new InformeInspeccionFordViewModel(informeInspeccionFord);

            //informeInspeccionFordViewModel.EstaEdicion = false;
            //return informeInspeccionFordViewModel;
            InformeInspeccionFordCompleto informeInspeccionFordCompleto = _informeInspeccionFordRepositorio.BuscarInformeInspeccionCompleto(id);
            InformeInspeccionFordViewModel informeInspeccionFordViewModel
                = new InformeInspeccionFordViewModel(informeInspeccionFordCompleto);

            informeInspeccionFordViewModel.EstaEdicion = false;
            return informeInspeccionFordViewModel;
        }

        [HttpPost]
        public object Post([FromBody]InformeInspeccionFordViewModel.Modelo informeInspeccionFordViewModel)
        {
            try
            {
                InformeInspeccionFordCompleto informeInspeccionFordCompleto = informeInspeccionFordViewModel.CrearInformeInspeccionCompleto();
                _informeInspeccionFordCompletoRepositorio.Guardar(informeInspeccionFordCompleto);
            }
            catch(Exception ex)
            {
                return new { Status = 200, Mensaje = "Ocurrio un error inesperado" };
            }
            
            return new { Status = 200, Mensaje = "El Informe de Inspeccion se completo correctamente!" };
        }
    }
}
