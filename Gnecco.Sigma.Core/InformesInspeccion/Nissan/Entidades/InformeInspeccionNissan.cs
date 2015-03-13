using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class InformeInspeccionNissan : Gnecco.Sigma.Core.Shared.InformeInspeccion
    {
        // Propiedades
        #region Propiedades
        public List<InformeInspeccionNissanCompleto> InformesInspeccionCompletos { get; set; }
        public List<GrupoInformeInspeccionNissan> GruposDetallesInformeInspeccionNissan { get; set; }
        public List<GrupoInformeInspeccionNissan> GruposActivos { 
            get 
            {
                return GruposDetallesInformeInspeccionNissan.Where(g => g.IndicadorEstado == EstadoEntidad.Activo).ToList();
            } 
        }
        public List<GrupoInformeInspeccionNissan> GruposRevision {
            get
            {
                return GruposDetallesInformeInspeccionNissan.Where(g => g.IndicadorEstado == EstadoEntidad.Activo 
                    && g.TipoGrupo == TipoGrupoInformeInspeccionNissan.Revision).ToList();
            }
        }
        public List<GrupoInformeInspeccionNissan> GruposCalidad
        {
            get
            {
                return GruposDetallesInformeInspeccionNissan.Where(g => g.IndicadorEstado == EstadoEntidad.Activo
                    && g.TipoGrupo == TipoGrupoInformeInspeccionNissan.Calidad).ToList();
            }
        }
        public List<GrupoInformeInspeccionNissan> GruposMedicion
        {
            get
            {
                return GruposDetallesInformeInspeccionNissan.Where(g => g.IndicadorEstado == EstadoEntidad.Activo
                    && g.TipoGrupo == TipoGrupoInformeInspeccionNissan.Medicion).ToList();
            }
        }
        #endregion

        // Constructor
        public InformeInspeccionNissan()
        {
            base.Descripcion = "Descripcion Default";
        }

        // Metodos
        #region Metodos              
        public void AgregarOModificarOpcionesDetalleEnGrupo(int idGrupo, int idDetalle,
            List<Opcion> opcionesCheckCalidad, List<Opcion> opcionesCheckRevision, List<Opcion> opcionesMedicion)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(g => g.Id == idGrupo).First();
            grupo.AgregarOModificarOpcionesDetalle(idDetalle, opcionesCheckCalidad, opcionesCheckRevision, opcionesMedicion);
        }

        public void ModificarDescripcionDetalleEnGrupo(int idGrupo, int idDetalle, string descripcion)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(g => g.Id == idGrupo).First();
            grupo.ModificarDetalle(idDetalle, descripcion);            
        }

        public void AgregarDetalleEnGrupo(int idGrupo, DetalleInformeInspeccionNissan detalle)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(g => g.Id == idGrupo).First();
            grupo.AgregarDetalle(detalle);
        }

        public void ModificarNombreDescripcion(string nombre, string descripcion)
        {
            base.Nombre = nombre;
            base.Descripcion = descripcion;
        }

        public void AgregarGrupo(string descripcion)
        {
            GrupoInformeInspeccionNissan grupo = new GrupoInformeInspeccionNissan();
            grupo.Descripcion = descripcion;
            this.GruposDetallesInformeInspeccionNissan.Add(grupo);
        }

        public void AgregarGrupo(string descripcion, List<DetalleInformeInspeccionNissan> detalles)
        {
            GrupoInformeInspeccionNissan grupo = new GrupoInformeInspeccionNissan();
            grupo.Descripcion = descripcion;
            grupo.AgregarDetalles(detalles);
            this.GruposDetallesInformeInspeccionNissan.Add(grupo);
        }

        public void AgregarGrupo(string descripcion,  List<DetalleInformeInspeccionNissan> detalles, string grupoTipo)
        {
            GrupoInformeInspeccionNissan grupo = new GrupoInformeInspeccionNissan();
            grupo.Descripcion = descripcion;
            grupo.TipoGrupo = grupoTipo;
            //grupo.AgregarDetalles(detalles);
            grupo.Detalles = detalles;
            this.GruposDetallesInformeInspeccionNissan.Add(grupo);
        }
        
        public void AgregarGrupo(GrupoInformeInspeccionNissan grupo)
        {
            this.GruposDetallesInformeInspeccionNissan.Add(grupo);
        }

        public void ModificarDescripcion(string descripcion)
        {
            base.Descripcion = descripcion;
        }

        public void AnularGrupo(int grupoId)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(d => d.Id == grupoId).First();
            grupo.Anular();
        }

        public void AnularDetalleEnGrupo(int detalleId)
        {
            foreach (var grupo in this.GruposDetallesInformeInspeccionNissan)
            {
                if (grupo.Detalles.Any(d => d.Id == detalleId))
                {
                    DetalleInformeInspeccionNissan detalle = grupo.Detalles.Where(d => d.Id == detalleId).First();
                    detalle.Anular();
                }
                else { }
            }
        }

        public void AnularOpcionEnGrupo(int opcionId)
        {
            foreach (var grupo in this.GruposDetallesInformeInspeccionNissan)
            {
                foreach (var detalle in grupo.Detalles)
                {
                    if (detalle.Opciones.Any(o => o.Id == opcionId))
                    {
                        Opcion opcion = detalle.Opciones.Where(o => o.Id == opcionId).First();
                        opcion.Anular();
                    }
                    else { }
                }
            }
        }

        public void ModificarGrupo(int grupoId, string descripcion)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(d => d.Id == grupoId).First();
            grupo.Descripcion = descripcion;
        }

        public void ModificarGrupo(int grupoId, string descripcion, string tipoGrupo)
        {
            GrupoInformeInspeccionNissan grupo = this.GruposDetallesInformeInspeccionNissan.Where(d => d.Id == grupoId).First();
            grupo.TipoGrupo = tipoGrupo;
            grupo.Descripcion = descripcion;
        }
        #endregion
    }

    public class TipoGrupoInformeInspeccionNissan
    {
        public const string Revision = "Revision";
        public const string Calidad = "Calidad";
        public const string Medicion = "Medicion";
    }
}
