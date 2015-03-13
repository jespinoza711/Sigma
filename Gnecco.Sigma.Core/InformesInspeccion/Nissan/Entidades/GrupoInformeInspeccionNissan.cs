using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class GrupoInformeInspeccionNissan : Gnecco.Sigma.Core.Shared.GrupoInformeInspeccion
    {
        public string TipoGrupo { get; set; }
        public List<DetalleInformeInspeccionNissan> Detalles { get; set; }
        public List<DetalleInformeInspeccionNissan> DetallesActivos
        {
            get
            {
                return Detalles.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
        }

        public GrupoInformeInspeccionNissan()
        {
            Descripcion = "Descripcion Grupo Default";
            IndicadorEstado = EstadoEntidad.Activo;
        }

        #region Metodos
                
        public void AgregarOModificarOpcionesDetalle(int detalleId, List<Opcion> opcionesCheckCalidad, List<Opcion> opcionesCheckRevision, List<Opcion> opcionesMedicion)
        {
            DetalleInformeInspeccionNissan detalle = this.Detalles.Where(d => d.Id == detalleId).First();
            detalle.AgregarOModificarOpciones(opcionesCheckCalidad, opcionesCheckRevision, opcionesMedicion);
        }

        public void Anular()
        {
            IndicadorEstado = EstadoEntidad.Inactivo;
        }

        public void ModificarDescripcion(string nuevaDescripcion)
        {
            base.Descripcion = nuevaDescripcion;
        }

        public void ModificarDetalle(int detalleId, string nuevaDescripcion)
        {
            DetalleInformeInspeccionNissan detalle = this.Detalles.Where(d => d.Id == detalleId).First();
            detalle.Descripcion = nuevaDescripcion;
        }

        public void AnularDetalle(int detalleId)
        {
            DetalleInformeInspeccionNissan detalle = this.Detalles.Where(d => d.Id == detalleId).First();
            detalle.Inactivar();
        }

        public void AgregarDetalle(DetalleInformeInspeccionNissan detalle) 
        {
            this.Detalles.Add(detalle);
        }

        public void AgregarDetalle(string descripcion)
        {
            DetalleInformeInspeccionNissan detalle = new DetalleInformeInspeccionNissan();
            detalle.Descripcion = descripcion;
            detalle.CrearOpciones();
            this.Detalles.Add(detalle);
        }

        public void CrearOpcionesDetalles()
        {
            foreach (var detalleInformeInspeccionVolkswagen in Detalles)
            {
                detalleInformeInspeccionVolkswagen.CrearOpciones();
            }
        }

        internal void AgregarDetalles(List<DetalleInformeInspeccionNissan> detalles)
        {
            foreach (var detalle in detalles)
            {
                this.Detalles.Add(detalle);
            }
        }

        #endregion
    }    
}
