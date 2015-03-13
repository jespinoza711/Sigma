using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Web.Factories.InformesInspeccion.Volkswagen;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionVolkswagenCompletadoController : ApiController
    {

        IInformeInspeccionVolkswagenCompletoRepositorio _informeInspeccionVolkswagenCompletoRepositorio;

        // Constructor
        public InformeInspeccionVolkswagenCompletadoController()
        {
            _informeInspeccionVolkswagenCompletoRepositorio = new InformeInspeccionVolkswagenCompletoRepositorio();
        }

        // Post
        public object Post([FromBody]InformeInspeccionCompletoPostViewModel informeInspeccionCompletoPostViewModel)
        {
            try
            {
                InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto 
                    = new InformeInspeccionVolkswagenCompletoFactory().Crear(informeInspeccionCompletoPostViewModel);                
                _informeInspeccionVolkswagenCompletoRepositorio.GuardarCompleto(informeInspeccionVolkswagenCompleto);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return new
                {
                    Status = 500,
                    Mensaje = "El Informe de Inspeccion no se pudo Completar!",
                    Error = err
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "Informe Inspeccion Volkswagen Completado!"
            };
        }

        // Get - id = informeInspeccionCompletoId
        public object Get(int id)
        {
            IInformeInspeccionVolkswagenRepositorio _informeInspeccionVolkswagenRepositorio = new InformeInspeccionVolkswagenRepositorio();
            InformeInspeccionCompletoGetViewModel informeInspeccionCompletoGetViewModel = new InformeInspeccionCompletoGetViewModel();

            try
            {
                InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto =
                    _informeInspeccionVolkswagenCompletoRepositorio.GetInformeInspeccionCompletoById(id);
                InformeInspeccionVolkswagen informeInspeccionVolkswagen = _informeInspeccionVolkswagenRepositorio.BuscarId(informeInspeccionVolkswagenCompleto.InformeInspeccionId);
                informeInspeccionCompletoGetViewModel.MapearDesde(informeInspeccionVolkswagenCompleto, informeInspeccionVolkswagen);
            }
            catch (Exception e)
            {
                return new
                {
                    Status = "500",
                    Mensaje = "Error: No hay Elementos... O algo salio mal...",
                    Error = e.Message
                };
            }

            return informeInspeccionCompletoGetViewModel;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            InformeInspeccionCompletoGetViewModel informeInspeccionCompletoGetViewModel = new InformeInspeccionCompletoGetViewModel();

            try
            {
                InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto =
                   _informeInspeccionVolkswagenCompletoRepositorio.GetInformeInspeccionCompletoById(id);
                informeInspeccionVolkswagenCompleto.Anular();
                _informeInspeccionVolkswagenCompletoRepositorio.AnularInformeInspeccionCompleto(informeInspeccionVolkswagenCompleto);
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
