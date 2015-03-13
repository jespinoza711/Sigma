using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Web.Factories.InformesInspeccion.Nissan;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InformeInspeccionNissanController : ApiController
    {
        IInformeInspeccionNissanRepositorio _informeInspeccionNissanRepositorio;

        public InformeInspeccionNissanController()
        {
            _informeInspeccionNissanRepositorio = new InformeInspeccionNissanRepositorio();
        }

        [HttpGet]
        public IEnumerable<InformeInspeccionResumenNissanViewModel> Get()
        {
            List<InformeInspeccionNissan> informeInspeccion
                = _informeInspeccionNissanRepositorio.ListarInformesInspeccion();
            InformeInspeccionResumenNissanViewModelHandler informeInspeccionResumenViewModel = new InformeInspeccionResumenNissanViewModelHandler();
            informeInspeccionResumenViewModel.MapearDesde(informeInspeccion);
            return informeInspeccionResumenViewModel.InformesInspeccionResumen;
        }

        //[HttpGet]
        //[ActionName("CompletadosCompletados")]
        //public IEnumerable<InformeInspeccionCompletoListadoNissanViewModel> CompletadosCompletados(int id)
        //{
        //    IInformeInspeccionNissanCompletoRepositorio _informInspeccionNissanCompletoRepositorio
        //        = new InformeInspeccionNissanCompletoRepositorio();
        //    List<InformeInspeccionNissanCompleto> informesInspeccionNissanCompleto
        //        = _informInspeccionNissanCompletoRepositorio.ListarInformesInspeccion(id);
        //    InformeInspeccionCompletoListadoNissanViewModelHandler handler
        //        = new InformeInspeccionCompletoListadoNissanViewModelHandler();
        //    handler.MapearDesde(informesInspeccionNissanCompleto);
        //    return handler.insformesInspeccionCompletos;
        //}

        [HttpGet]
        public object Get(int id)
        {
            InformeInspeccionNissan informe = new InformeInspeccionNissan();
            InformeInspeccionCuerpoCompletoNissanViewModel informeCuerpoCompletoNissan = new InformeInspeccionCuerpoCompletoNissanViewModel();
                 
            try
            {
                informe = _informeInspeccionNissanRepositorio.BuscarInformeInspeccionPorId(id);
                informeCuerpoCompletoNissan.MapearDesde(informe);
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

            return informeCuerpoCompletoNissan;
        }

        [HttpPost]
        public object Post([FromBody]InformeInspeccionPostNissanViewModel informeInspeccionPostsNissanViewModel)
        {            
            try
            {
                InformeInspeccionNissan informeNissan = new InformeInspeccionNissanFactory().Crear(informeInspeccionPostsNissanViewModel);
                _informeInspeccionNissanRepositorio.GuardarInformeInspeccion(informeNissan);
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

        [HttpDelete]
        public object Delete(int id)
        {
            try
            {
                InformeInspeccionNissan informeInspeccionNissan = _informeInspeccionNissanRepositorio.BuscarInformeInspeccionPorId(id);
                informeInspeccionNissan.Anular();
                _informeInspeccionNissanRepositorio.AnularInformeInspeccion(informeInspeccionNissan);
            }
            catch (Exception e)
            {
                return new
                {
                    Method = "DELETE",
                    Status = "500",
                    Mensaje = e.Message
                };
            }

            return new
            {
                Method = "DELETE",
                Status = "200",
                Mensaje = "Ok!"
            };
        }

        [HttpPut]
        public object Put([FromBody] InformeInspeccionModificarNissanViewModel viewModel)
        {
            try
            {
                InformeInspeccionNissan informeInspeccionNissan = _informeInspeccionNissanRepositorio.BuscarInformeInspeccionPorId(viewModel.InformeInspeccionId);

                informeInspeccionNissan.ModificarNombreDescripcion(viewModel.Nombre, viewModel.Descripcion);
                foreach (var G in viewModel.Grupos)
                {
                    List<DetalleInformeInspeccionNissan> detalles = new List<DetalleInformeInspeccionNissan>();

                    if (G.Id <= 0) // Todos los Objectos son nuevos
                    {
                        foreach (var D in G.Detalles)
                        {
                            DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                            List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                            List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                            List<Opcion> OpcionesMedicion = new List<Opcion>();

                            if (D.OpcionesCheckCalidad != null)
                            {
                                foreach (var OCC in D.OpcionesCheckCalidad)
                                {
                                    OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                }
                            }

                            if (D.OpcionesCheckRevision != null)
                            {
                                foreach (var OCR in D.OpcionesCheckRevision)
                                {
                                    OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                }
                            }

                            if (D.OpcionesMedicion != null)
                            {
                                foreach (var OM in D.OpcionesMedicion)
                                {
                                    OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                }
                            }

                            detalle.Descripcion = D.Descripcion;
                            detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList();
                            detalles.Add(detalle);
                            //detalle.AgregarOpciones(OpcionesCheckCalidad, OpcionesCheckRevision, OpcionesMedicion);
                        }

                        informeInspeccionNissan.AgregarGrupo(G.DescripcionGrupo, detalles, TipoGrupoInformeInspeccionNissan.Revision);
                    }
                    else
                    {
                        foreach (var D in G.Detalles)
                        {
                            if (D.Id <= 0) // Grupo Existe, pero es un nuevo Detalle, Nuevas Opciones
                            {
                                DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                    }
                                }

                                detalle.Descripcion = D.Descripcion;
                                detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList();                                
                                informeInspeccionNissan.AgregarDetalleEnGrupo(G.Id, detalle);
                            }
                            else // Grupo Existe, Detalle Existe, se agrega o modifica opciones
                            {
                                informeInspeccionNissan.ModificarDescripcionDetalleEnGrupo(G.Id, D.Id, D.Descripcion);

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion
                                        {
                                            Id = OCC.Id,
                                            Descripcion = OCC.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad
                                        });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion
                                        {
                                            Id = OCR.Id,
                                            Descripcion = OCR.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision
                                        });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion
                                        {
                                            Id = OM.Id,
                                            Descripcion = OM.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion
                                        });
                                    }
                                }

                                informeInspeccionNissan.AgregarOModificarOpcionesDetalleEnGrupo(G.Id, D.Id, OpcionesCheckCalidad, OpcionesCheckRevision, OpcionesMedicion);
                            }
                        }

                        informeInspeccionNissan.ModificarGrupo(G.Id, G.DescripcionGrupo, TipoGrupoInformeInspeccionNissan.Revision);
                    }
                }

                foreach (var G in viewModel.GruposCalidad)
                {
                    List<DetalleInformeInspeccionNissan> detalles = new List<DetalleInformeInspeccionNissan>();

                    if (G.Id <= 0) // Todos los Objectos son nuevos
                    {
                        foreach (var D in G.Detalles)
                        {
                            DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                            List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                            List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                            List<Opcion> OpcionesMedicion = new List<Opcion>();

                            if (D.OpcionesCheckCalidad != null)
                            {
                                foreach (var OCC in D.OpcionesCheckCalidad)
                                {
                                    OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                }
                            }

                            if (D.OpcionesCheckRevision != null)
                            {
                                foreach (var OCR in D.OpcionesCheckRevision)
                                {
                                    OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                }
                            }

                            if (D.OpcionesMedicion != null)
                            {
                                foreach (var OM in D.OpcionesMedicion)
                                {
                                    OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                }
                            }

                            detalle.Descripcion = D.Descripcion;
                            detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList();                            
                            detalles.Add(detalle);
                        }

                        informeInspeccionNissan.AgregarGrupo(G.DescripcionGrupo, detalles, TipoGrupoInformeInspeccionNissan.Calidad);
                    }
                    else
                    {
                        foreach (var D in G.Detalles)
                        {
                            if (D.Id <= 0) // Grupo Existe, pero es un nuevo Detalle, Nuevas Opciones
                            {
                                DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                    }
                                }

                                detalle.Descripcion = D.Descripcion;
                                detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList();
                                informeInspeccionNissan.AgregarDetalleEnGrupo(G.Id, detalle);
                            }
                            else // Grupo Existe, Detalle Existe, se agrega o modifica opciones
                            {
                                informeInspeccionNissan.ModificarDescripcionDetalleEnGrupo(G.Id, D.Id, D.Descripcion);

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion
                                        {
                                            Id = OCC.Id,
                                            Descripcion = OCC.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad
                                        });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion
                                        {
                                            Id = OCR.Id,
                                            Descripcion = OCR.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision
                                        });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion
                                        {
                                            Id = OM.Id,
                                            Descripcion = OM.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion
                                        });
                                    }
                                }

                                informeInspeccionNissan.AgregarOModificarOpcionesDetalleEnGrupo(G.Id, D.Id, OpcionesCheckCalidad, OpcionesCheckRevision, OpcionesMedicion);
                            }
                        }

                        informeInspeccionNissan.ModificarGrupo(G.Id, G.DescripcionGrupo, TipoGrupoInformeInspeccionNissan.Calidad);
                    }
                }

                foreach (var G in viewModel.GruposEspeciales)
                {
                    List<DetalleInformeInspeccionNissan> detalles = new List<DetalleInformeInspeccionNissan>();

                    if (G.Id <= 0) // Todos los Objectos son nuevos
                    {
                        foreach (var D in G.Detalles)
                        {
                            DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                            List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                            List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                            List<Opcion> OpcionesMedicion = new List<Opcion>();

                            if (D.OpcionesCheckCalidad != null)
                            {
                                foreach (var OCC in D.OpcionesCheckCalidad)
                                {
                                    OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                }
                            }

                            if (D.OpcionesCheckRevision != null)
                            {
                                foreach (var OCR in D.OpcionesCheckRevision)
                                {
                                    OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                }
                            }

                            if (D.OpcionesMedicion != null)
                            {
                                foreach (var OM in D.OpcionesMedicion)
                                {
                                    OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                }
                            }

                            detalle.Descripcion = D.Descripcion;
                            detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList();
                            detalles.Add(detalle);
                            //detalle.AgregarOpciones(OpcionesCheckCalidad, OpcionesCheckRevision, OpcionesMedicion);
                        }

                        informeInspeccionNissan.AgregarGrupo(G.DescripcionGrupo, detalles, TipoGrupoInformeInspeccionNissan.Medicion);
                    }
                    else
                    {
                        foreach (var D in G.Detalles)
                        {
                            if (D.Id <= 0) // Grupo Existe, pero es un nuevo Detalle, Nuevas Opciones
                            {
                                DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion { Descripcion = OCC.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion { Descripcion = OCR.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion { Descripcion = OM.Descripcion, CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion });
                                    }
                                }

                                detalle.Descripcion = D.Descripcion;                                
                                detalle.Opciones = OpcionesCheckCalidad.Concat(OpcionesCheckRevision).Concat(OpcionesMedicion).ToList(); 
                                informeInspeccionNissan.AgregarDetalleEnGrupo(G.Id, detalle);
                            }
                            else // Grupo Existe, Detalle Existe, se agrega o modifica opciones
                            {
                                informeInspeccionNissan.ModificarDescripcionDetalleEnGrupo(G.Id, D.Id, D.Descripcion);

                                List<Opcion> OpcionesCheckCalidad = new List<Opcion>();
                                List<Opcion> OpcionesCheckRevision = new List<Opcion>();
                                List<Opcion> OpcionesMedicion = new List<Opcion>();

                                if (D.OpcionesCheckCalidad != null)
                                {
                                    foreach (var OCC in D.OpcionesCheckCalidad)
                                    {
                                        OpcionesCheckCalidad.Add(new Opcion
                                        {
                                            Id = OCC.Id,
                                            Descripcion = OCC.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad
                                        });
                                    }
                                }

                                if (D.OpcionesCheckRevision != null)
                                {
                                    foreach (var OCR in D.OpcionesCheckRevision)
                                    {
                                        OpcionesCheckRevision.Add(new Opcion
                                        {
                                            Id = OCR.Id,
                                            Descripcion = OCR.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision
                                        });
                                    }
                                }

                                if (D.OpcionesMedicion != null)
                                {
                                    foreach (var OM in D.OpcionesMedicion)
                                    {
                                        OpcionesMedicion.Add(new Opcion
                                        {
                                            Id = OM.Id,
                                            Descripcion = OM.Descripcion,
                                            CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion
                                        });
                                    }
                                }

                                informeInspeccionNissan.AgregarOModificarOpcionesDetalleEnGrupo(G.Id, D.Id, OpcionesCheckCalidad, OpcionesCheckRevision, OpcionesMedicion);
                            }
                        }

                        informeInspeccionNissan.ModificarGrupo(G.Id, G.DescripcionGrupo, TipoGrupoInformeInspeccionNissan.Medicion);
                    }
                }

                if (viewModel.GruposAnulados != null)
                {
                    foreach (var G in viewModel.GruposAnulados)
                    {
                        informeInspeccionNissan.AnularGrupo(G.Id);
                    }
                }

                if (viewModel.DetallesAnulados != null)
                {
                    foreach (var D in viewModel.DetallesAnulados)
                    {
                        //informeInspeccionNissan.AnularDetalleEnGrupo(D.Id);

                        foreach (var grupo in informeInspeccionNissan.GruposDetallesInformeInspeccionNissan)
                        {
                            foreach (var detalle in grupo.Detalles)
                            {
                                if (detalle.Id == D.Id)
                                {
                                    //detalle.Inactivar();
                                    detalle.IndicadorEstado = EstadoEntidad.Inactivo;
                                }
                            }
                        }
                    }
                }

                if (viewModel.OpcionesAnulados != null)
                {
                    foreach (var O in viewModel.OpcionesAnulados)
                    {
                        informeInspeccionNissan.AnularOpcionEnGrupo(O.Id);
                    }
                }

                _informeInspeccionNissanRepositorio.ModificarInformeInspeccion(informeInspeccionNissan);
            }
            catch (Exception e)
            {
                return new
                {
                    Status = 500,
                    Mensaje = e.Message
                };
            }

            return new
            {
                Status = 200,
                Mensaje = "OK!"
            };
        }
    }
}
