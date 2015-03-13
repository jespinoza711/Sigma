using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Web.Factories.InformesInspeccion.Nissan;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionNissanCompletadoController : ApiController
    {

        IInformeInspeccionNissanCompletoRepositorio _informeInspeccionNissanCompletoRepositorio;

        public InformeInspeccionNissanCompletadoController()
        {
            this._informeInspeccionNissanCompletoRepositorio = new InformeInspeccionNissanCompletoRepositorio();
        }

        [HttpGet]
        public object Get(int id)
        {
            IInformeInspeccionNissanRepositorio _informeInspeccionNissanRepositorio = new InformeInspeccionNissanRepositorio();
            InformeInspeccionCompletoNissanGetViewModel nissanGetViewModel = new InformeInspeccionCompletoNissanGetViewModel();

            try
            {
                InformeInspeccionNissanCompleto informeInspeccionNissanCompleto = _informeInspeccionNissanCompletoRepositorio.BuscarPorId(id);
                InformeInspeccionNissan informeInspeccionNissan = 
                    _informeInspeccionNissanRepositorio.BuscarInformeInspeccionPorId(informeInspeccionNissanCompleto.InformeInspeccionId);
                nissanGetViewModel.MapearDesde(informeInspeccionNissanCompleto, informeInspeccionNissan);
            }
            catch (Exception)
            {               
                return new
                {
                    Status = "500",
                    Mensaje = "Error: No hay Elementos... O algo salio mal...",
                };
            }

            return nissanGetViewModel;
        }

        [HttpPost]
        public object Post(InformeInspeccionCompletoPostNissanViewModel vm)
        {
            try
            {
                InformeInspeccionNissanCompleto informeInspeccionCompleto   
                    = new InformeInspeccionNissanCompletoFactory().Crear(vm);
                _informeInspeccionNissanCompletoRepositorio.GuardarInformeInspeccionCompleto(informeInspeccionCompleto);
            }
            catch (Exception e)
            {
                return new
                {
                    Status = 500,
                    Mensaje = "ERROR!",
                    Error = e.Message
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "OK!"
            };
        }

        [HttpPut]
        public object Put(InformeInspeccionCompletoPostNissanViewModel vm)
        {
            try
            {
                InformeInspeccionNissanCompleto informeInspeccionCompleto
                    = new InformeInspeccionNissanCompletoFactory().Crear(vm);
                _informeInspeccionNissanCompletoRepositorio.GuardarInformeInspeccionCompleto(informeInspeccionCompleto);
            }
            catch (Exception)
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
                Mensaje = "OK!"
            };
        }

        [HttpDelete]
        public object Delete(int id)
        {
            try
            {
                InformeInspeccionNissanCompleto informeInspeccionNissanCompleto =
                   _informeInspeccionNissanCompletoRepositorio.BuscarPorId(id);
                informeInspeccionNissanCompleto.Anular();
                _informeInspeccionNissanCompletoRepositorio.AnularInformeInspeccionCompleto(informeInspeccionNissanCompleto);
            }
            catch (Exception)
            {

                return new
                {
                    Status = "500",
                    Mensaje = "Error: No hay Elementos... O algo salio mal..."
                };
            }

            return new
            {
                Status = "200",
                Mensaje = "Objeto borrado Correctamente!"
            };
        }
    }
}
