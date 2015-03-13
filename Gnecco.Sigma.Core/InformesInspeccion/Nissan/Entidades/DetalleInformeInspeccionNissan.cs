using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class DetalleInformeInspeccionNissan : DetalleInformeInspeccion
    {
        #region Propiedades
        public int? InformeInspeccionId { get; set; }
        public int GrupoInformeInspeccionNissanId { get; set; }        
        public List<Opcion> Opciones { get; set; }
        public List<Opcion> OpcionesCheckRevision 
        {
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckRevision && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
        }
        public List<Opcion> OpcionesMedicion 
        { 
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionNissan.OpcionMedicion && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
        }
        public List<Opcion> OpcionesCheckCalidad 
        {
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckCalidad && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
        }
        #endregion

        #region Constructor
        public DetalleInformeInspeccionNissan()
        {
            this.Descripcion = "Descripcion Default";
        }
        #endregion

        #region Metodos
        public void Anular()
        {
            base.IndicadorEstado = EstadoEntidad.Inactivo;
        }

        public void CrearOpciones()
        {
            Opciones.Add(new Opcion { Descripcion = "REVISADO OK", CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
            Opciones.Add(new Opcion { Descripcion = "REQUIERE ATENCION EN PROXIMA VISITA", CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
            Opciones.Add(new Opcion { Descripcion = "REQUIERE ATENCION INMEDIATA", CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision });
        }

        public void AgregarOpciones(List<Opcion> opciones)
        {
            this.Opciones = opciones;
        }

        public void AgregarOpciones(List<Opcion> opcionesCheckCalidad, List<Opcion> opcionesCheckRevision, List<Opcion> OpcionMedicion)
        {
            foreach (var OCC in opcionesCheckCalidad)
            {
                this.Opciones.Add(new Opcion
                    {
                        Descripcion = OCC.Descripcion,
                        CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad
                    });
            }

            foreach (var OCR in opcionesCheckRevision)
            {
                this.Opciones.Add(new Opcion 
                    { 
                        Descripcion = OCR.Descripcion,
                        CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision
                    });
            }

            foreach (var OM in OpcionMedicion)
            {
                this.Opciones.Add(new Opcion 
                    { 
                        Descripcion = OM.Descripcion,
                        CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion
                    });
            }
        }

        public void AgregarOModificarOpciones(List<Opcion> opcionesCheckCalidad, List<Opcion> opcionesCheckRevision, List<Opcion> OpcionMedicion)
        {
            foreach (var opcion in opcionesCheckCalidad)
            {
                if (opcion.Id <= 0)
                {
                    this.Opciones.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad
                        });
                }
                else
                {
                    Opcion O = this.Opciones.Where(o => o.Id == opcion.Id).First();
                    O.Descripcion = opcion.Descripcion;
                    O.CodigoAgrupacion = TipoOpcionNissan.OpcionCheckCalidad;
                }
            }

            foreach (var opcion in opcionesCheckRevision)
            {
                if (opcion.Id <= 0)
                {
                    this.Opciones.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision
                        });
                }
                else
                {
                    Opcion O = this.Opciones.Where(o => o.Id == opcion.Id).First();
                    O.Descripcion = opcion.Descripcion;
                    O.CodigoAgrupacion = TipoOpcionNissan.OpcionCheckRevision;
                }
            }

            foreach (var opcion in OpcionMedicion)
            {
                if (opcion.Id <= 0)
                {
                    this.Opciones.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion
                        });
                }
                else
                {
                    Opcion O = this.Opciones.Where(o => o.Id == opcion.Id).First();
                    O.Descripcion = opcion.Descripcion;
                    O.CodigoAgrupacion = TipoOpcionNissan.OpcionMedicion;
                }
            }
        }
        #endregion
    }

    public class TipoOpcionNissan
    {
        public const int OpcionCheckRevision = 4;
        public const int OpcionMedicion = 5;
        public const int OpcionCheckCalidad = 6;
    }
}
