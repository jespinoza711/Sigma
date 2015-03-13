using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Web.Factories.InformesInspeccion.Nissan
{
    public class InformeInspeccionNissanFactory
    {
        public InformeInspeccionNissan Crear(InformeInspeccionPostNissanViewModel informeInspeccionPostNissanViewModel) 
        {
            InformeInspeccionNissan informeInspeccion = new InformeInspeccionNissan();            
            List<GrupoInformeInspeccionNissan> grupos = new List<GrupoInformeInspeccionNissan>();

            #region GruposRevision
            foreach (var grupo in informeInspeccionPostNissanViewModel.Grupos)
            {
                GrupoInformeInspeccionNissan grupoInformeInspeccion = new GrupoInformeInspeccionNissan();
                List<DetalleInformeInspeccionNissan> detallesInformeInspeccionNissan = new List<DetalleInformeInspeccionNissan>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissan detalleInformeInspeccionNissan = new DetalleInformeInspeccionNissan();
                    List<Opcion> opcionesCheckRevision = new List<Opcion>();
                    List<Opcion> opcionesMedicion = new List<Opcion>();
                    List<Opcion> opcionesCalidad = new List<Opcion>();

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckRevision)
                        {
                            opcionesCheckRevision.Add(new Opcion
                                {
                                    CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision,
                                    Descripcion = opcion.Descripcion
                                }
                            );
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var opcion in detalle.OpcionesMedicion)
                        {
                            opcionesMedicion.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckCalidad)
                        {
                            opcionesCalidad.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    detalleInformeInspeccionNissan.Descripcion = detalle.Descripcion;
                    detalleInformeInspeccionNissan.AgregarOpciones(opcionesCheckRevision.ToList());
                    detallesInformeInspeccionNissan.Add(detalleInformeInspeccionNissan);
                }

                grupoInformeInspeccion.Descripcion = grupo.DescripcionGrupo;
                grupoInformeInspeccion.Detalles = detallesInformeInspeccionNissan;
                grupoInformeInspeccion.IndicadorEstado = EstadoEntidad.Activo;
                grupoInformeInspeccion.TipoGrupo = TipoGrupoInformeInspeccionNissan.Revision;
                grupos.Add(grupoInformeInspeccion);
            }
            #endregion

            #region GruposCalidad
            foreach (var grupo in informeInspeccionPostNissanViewModel.GruposCalidad)
            {
                GrupoInformeInspeccionNissan grupoInformeInspeccion = new GrupoInformeInspeccionNissan();
                List<DetalleInformeInspeccionNissan> detallesInformeInspeccionNissan = new List<DetalleInformeInspeccionNissan>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissan detalleInformeInspeccionNissan = new DetalleInformeInspeccionNissan();
                    List<Opcion> opcionesCheckRevision = new List<Opcion>();
                    List<Opcion> opcionesMedicion = new List<Opcion>();
                    List<Opcion> opcionesCalidad = new List<Opcion>();

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckRevision)
                        {
                            opcionesCheckRevision.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var opcion in detalle.OpcionesMedicion)
                        {
                            opcionesMedicion.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckCalidad)
                        {
                            opcionesCalidad.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    detalleInformeInspeccionNissan.Descripcion = detalle.Descripcion;
                    detalleInformeInspeccionNissan.AgregarOpciones(opcionesCalidad.ToList());
                    detallesInformeInspeccionNissan.Add(detalleInformeInspeccionNissan);
                }

                grupoInformeInspeccion.Descripcion = grupo.DescripcionGrupo;
                grupoInformeInspeccion.Detalles = detallesInformeInspeccionNissan;
                grupoInformeInspeccion.IndicadorEstado = EstadoEntidad.Activo;
                grupoInformeInspeccion.TipoGrupo = TipoGrupoInformeInspeccionNissan.Calidad;
                grupos.Add(grupoInformeInspeccion);
            }
            #endregion

            #region GruposEspeciales
            foreach (var grupo in informeInspeccionPostNissanViewModel.GruposEspeciales)
            {
                GrupoInformeInspeccionNissan grupoInformeInspeccion = new GrupoInformeInspeccionNissan();
                List<DetalleInformeInspeccionNissan> detallesInformeInspeccionNissan = new List<DetalleInformeInspeccionNissan>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissan detalleInformeInspeccionNissan = new DetalleInformeInspeccionNissan();
                    List<Opcion> opcionesCheckRevision = new List<Opcion>();
                    List<Opcion> opcionesMedicion = new List<Opcion>();
                    List<Opcion> opcionesCalidad = new List<Opcion>();

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckRevision)
                        {
                            opcionesCheckRevision.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var opcion in detalle.OpcionesMedicion)
                        {
                            opcionesMedicion.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var opcion in detalle.OpcionesCheckCalidad)
                        {
                            opcionesCalidad.Add(new Opcion
                            {
                                CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad,
                                Descripcion = opcion.Descripcion
                            }
                            );
                        }
                    }

                    detalleInformeInspeccionNissan.Descripcion = detalle.Descripcion;
                    detalleInformeInspeccionNissan.AgregarOpciones(opcionesCheckRevision.Concat(opcionesMedicion).ToList());
                    detallesInformeInspeccionNissan.Add(detalleInformeInspeccionNissan);
                }

                grupoInformeInspeccion.Descripcion = grupo.DescripcionGrupo;
                grupoInformeInspeccion.Detalles = detallesInformeInspeccionNissan;
                grupoInformeInspeccion.IndicadorEstado = EstadoEntidad.Activo;
                grupoInformeInspeccion.TipoGrupo = TipoGrupoInformeInspeccionNissan.Medicion;
                grupos.Add(grupoInformeInspeccion);
            }
            #endregion

            informeInspeccion.Nombre = informeInspeccionPostNissanViewModel.Nombre;
            informeInspeccion.Descripcion = informeInspeccionPostNissanViewModel.Descripcion;
            informeInspeccion.GruposDetallesInformeInspeccionNissan = grupos;

            return informeInspeccion;
        }
    }
}