using System.Collections.Generic;
using System.Web.Http;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford;
using System;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionFordController : ApiController
    {
        private readonly IInformeInspeccionFordRepositorio _informeInspeccionFordRepositorio;
        public InformeInspeccionFordController()
        {
            _informeInspeccionFordRepositorio = new InformeInspeccionFordRepositorio();
        }

        [HttpGet]
        public IEnumerable<InformeInspeccionFordGetViewModel.InformeInspeccionFordViewModel> Get()
        {
            List<InformeInspeccionFord> informesInspeccionFord =
                _informeInspeccionFordRepositorio.BuscarInformesInspeccionFord();
            InformeInspeccionFordGetViewModel informeInspeccionFordGetViewModel = new InformeInspeccionFordGetViewModel();
            informeInspeccionFordGetViewModel.MapearDesde(informesInspeccionFord);
            return informeInspeccionFordGetViewModel.InformesInspeccion;
        }

        [HttpGet]
        public InformeInspeccionFordViewModel Get(int id)
        {
            InformeInspeccionFord informeInspeccionFord = _informeInspeccionFordRepositorio.Buscar(id);
            InformeInspeccionFordViewModel informeInspeccionFordGetIdViewModel
                = new InformeInspeccionFordViewModel(informeInspeccionFord);
            informeInspeccionFordGetIdViewModel.EstaEdicion = true;
            return informeInspeccionFordGetIdViewModel;
        }

        [HttpPost]
        public object Post([FromBody]InformeInspeccionFordViewModel.Modelo informeInspeccionFordViewModel)
        {
            try
            {
                InformeInspeccionFord informeInspeccionFord = informeInspeccionFordViewModel.CrearInformeInspeccionFord();
                _informeInspeccionFordRepositorio.Guardar(informeInspeccionFord);
            }
            catch (Exception ex)
            {
                return new
                {
                    Status = 500,
                    Mensaje = "ERROR!"
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "Informe Inspeccion Guardado!"
            };
        }

        [HttpPut]
        public object Put([FromBody]InformeInspeccionFordViewModel.Modelo informeInspeccionFordViewModel)
        {
            try
            {
                InformeInspeccionFord informeInspeccionFord = _informeInspeccionFordRepositorio.Buscar(informeInspeccionFordViewModel.Id);
                informeInspeccionFordViewModel.EditarInformeInspeccionFord(informeInspeccionFord);
                _informeInspeccionFordRepositorio.Guardar(informeInspeccionFord);
            }
            catch (Exception ex) 
            {
                return new
                {
                    Status = 500,
                    Mensaje = "ERROR!"
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "Informe Inspeccion Guardado!"
            };
        }        
    }
}
