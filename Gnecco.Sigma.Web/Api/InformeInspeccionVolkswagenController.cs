using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Web.Factories.InformesInspeccion.Volkswagen;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionVolkswagenController : ApiController
    {
        IInformeInspeccionVolkswagenRepositorio _informeInspeccionVolkswagenRepositorio;

        public InformeInspeccionVolkswagenController()
        {
            _informeInspeccionVolkswagenRepositorio = new InformeInspeccionVolkswagenRepositorio();
        }

        public IEnumerable<InformeInspeccionResumenViewModel> Get()
        {
            List<InformeInspeccionVolkswagen> informeInspeccionVolkswagen 
                = _informeInspeccionVolkswagenRepositorio.ListarInformesInspeccion();
            InformeInspeccionResumenViewModelHandler informeInspeccionResumenViewModel = new InformeInspeccionResumenViewModelHandler();
            informeInspeccionResumenViewModel.MapearDesde(informeInspeccionVolkswagen);
            return informeInspeccionResumenViewModel.InformesInspeccionResumen;
        }

        public object Post([FromBody]InformeInspeccionPostViewModel informeInspeccionPostViewModel)
        {
            try
            {
                InformeInspeccionVolkswagen informeInspeccionVolkswagen
                    = new InformeInspeccionVolkswagenFactory().Crear(informeInspeccionPostViewModel);
                _informeInspeccionVolkswagenRepositorio.Guardar(informeInspeccionVolkswagen);
            }
            catch (Exception)
            {

                return new
                {
                    Status = 500,
                    Mensaje = "Error!"
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "Ok! Correcto!"
            };
        }

        public InformeInspeccionCuerpoCompletoViewModel Get(int id)
        {
            InformeInspeccionVolkswagen informeInspeccionVolkswagen = _informeInspeccionVolkswagenRepositorio.BuscarInformeInspeccion(id);            
            InformeInspeccionCuerpoCompletoViewModel informeInspeccionCuerpoCompletoViewModel = new InformeInspeccionCuerpoCompletoViewModel();
            informeInspeccionCuerpoCompletoViewModel.MapearDesde(informeInspeccionVolkswagen);
            return informeInspeccionCuerpoCompletoViewModel;
        }

        [HttpGet]
        [ActionName("Completados")]
        public IEnumerable<InformeInspeccionCompletoListadoViewModel> Completados(int InformeInspeccionId)
        {
            IInformeInspeccionVolkswagenCompletoRepositorio _informeInspeccionVolkswagenCompletoRepositorio 
                = new InformeInspeccionVolkswagenCompletoRepositorio();
            List<InformeInspeccionVolkswagenCompleto> informeInspeccionVolkswagenCompleto
                = _informeInspeccionVolkswagenCompletoRepositorio.ListarInformesInspeccionCompletosPorInformeInspeccion(InformeInspeccionId);
            InformeInspeccionCompletoListadoViewModelHandler informeInspeccionCompletoListadoViewModelHandler 
                = new InformeInspeccionCompletoListadoViewModelHandler();
            informeInspeccionCompletoListadoViewModelHandler.MapearDesde(informeInspeccionVolkswagenCompleto);
            return informeInspeccionCompletoListadoViewModelHandler.insformesInspeccionCompletos;
        }

        [HttpPut]
        public object Put([FromBody]InformeInspeccionModificarViewModel informeInspeccionModificar)
        {
            try
            {
                InformeInspeccionVolkswagen informeInspeccionVolkswagen 
                    = _informeInspeccionVolkswagenRepositorio.BuscarId(informeInspeccionModificar.InformeInspeccionId);
                informeInspeccionVolkswagen.ModificarDescripcion(informeInspeccionModificar.Descripcion, informeInspeccionModificar.Nombre);
                foreach (var detalle in informeInspeccionModificar.Detalles)
                {
                    List<Opcion> opcionesCondicion = new List<Opcion>();
                    List<Opcion> opcionesIntervaloKm = new List<Opcion>();
                    List<Opcion> opcionesInternas = new List<Opcion>();                    

                    if (detalle.Id <= 0)
                    {
                        if (detalle.OpcionesCondicion != null)
                        {
                            foreach (var OC in detalle.OpcionesCondicion)
                            {
                                opcionesCondicion.Add(new Opcion { Descripcion = OC.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
                            }
                        }

                        if (detalle.OpcionesInternas != null)
                        {
                            foreach (var OI in detalle.OpcionesInternas)
                            {
                                opcionesInternas.Add(new Opcion { Descripcion = OI.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
                            }
                        }

                        if (detalle.OpcionesIntervaloKm != null)
                        {
                            foreach (var OIK in detalle.OpcionesIntervaloKm)
                            {
                                opcionesIntervaloKm.Add(new Opcion { Descripcion = OIK.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm });
                            }
                        }

                        informeInspeccionVolkswagen.AgregarDetalle(detalle.Descripcion, opcionesCondicion, opcionesInternas, opcionesIntervaloKm);
                    }
                    else
                    {
                        if (detalle.OpcionesCondicion != null)
                        {
                            foreach (var OC in detalle.OpcionesCondicion)
                            {
                                opcionesCondicion.Add(new Opcion { Id = OC.Id, Descripcion = OC.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
                            }
                        }

                        if (detalle.OpcionesInternas != null)
                        {
                            foreach (var OI in detalle.OpcionesInternas)
                            {
                                opcionesInternas.Add(new Opcion { Id = OI.Id, Descripcion = OI.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
                            }
                        }

                        if (detalle.OpcionesIntervaloKm != null)
                        {
                            foreach (var OIK in detalle.OpcionesIntervaloKm)
                            {
                                opcionesIntervaloKm.Add(new Opcion { Id = OIK.Id, Descripcion = OIK.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm });
                            }
                        }

                        informeInspeccionVolkswagen.ModificarDetalle(detalle.Id, detalle.Descripcion, opcionesCondicion, opcionesInternas, opcionesIntervaloKm);
                    }
                }

                foreach (var detalle in informeInspeccionModificar.DetallesAnulados)
                {
                    informeInspeccionVolkswagen.AnularDetalle(detalle.Id);
                }

                foreach (var opcion in informeInspeccionModificar.OpcionesAnulados)
                {
                    informeInspeccionVolkswagen.AnularOpcionesDetalle(opcion.Id);
                }

                _informeInspeccionVolkswagenRepositorio.Modificar(informeInspeccionVolkswagen);
            }
            catch (Exception e)
            {
                return new
                {
                    Status = "500",
                    Mensaje = e.Message
                };
            }
            
            return new
            {
                Status = "200",
                Mensaje = "Informe Guardado!"
            };
        }

        // Boton Anular - /InformesInspeccion/Volkswagen/#/
        [System.Web.Http.HttpDelete]
        public object Delete(int id)
        {
            try
            {
                InformeInspeccionVolkswagen informeInspeccionVolkswagen = _informeInspeccionVolkswagenRepositorio.BuscarInformeInspeccion(id);                
                informeInspeccionVolkswagen.Anular();
                _informeInspeccionVolkswagenRepositorio.Anular(informeInspeccionVolkswagen);
            }
            catch (Exception)
            {
                return new
                {
                    Method = "DELETE",
                    Status = "500",
                    Mensaje = "Error!"
                };
            }

            return new
            {
                Method = "DELETE",
                Status = "200",
                Mensaje = "Ok!"
            };
        }
    }
}
