using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades
{
    public class InformeInspeccionVolkswagen : InformeInspeccion
    {
        // Propiedades
        public List<DetalleInformeInspeccionVolkswagen> Detalles { get; set; }
        public List<InformeInspeccionVolkswagenCompleto> InformesInspeccionCompletos { get; set; }
        public List<DetalleInformeInspeccionVolkswagen> DetallesActivos 
        {
            get 
            {
                return Detalles.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList();
            } 
        }

        // Constructores
        public InformeInspeccionVolkswagen()
        {

        }

        public InformeInspeccionVolkswagen(string descripcion, string nombre)
        {
            base.Descripcion = descripcion;
            base.Nombre = nombre;
        }


        // Metodos o Acciones
        public void ModificarDescripcion(string nuevaDescripcion, string nombre)
        {
            base.Descripcion = nuevaDescripcion;
            base.Nombre = nombre;
        }

        public void ModificarDetalle(int detalleId, string nuevaDescripcion, 
            List<Opcion> opcionesCondicion, List<Opcion> opcionesInternas, List<Opcion> opcionesIntervaloKm)
       {
            DetalleInformeInspeccionVolkswagen detalle = this.Detalles.Where(d => d.Id == detalleId).First();
            detalle.Descripcion = nuevaDescripcion;
            detalle.ModificarOpciones(opcionesCondicion, opcionesInternas, opcionesIntervaloKm);
        }

        public void ModificarDetalle(int detalleId, string nuevaDescripcion)
        {
            DetalleInformeInspeccionVolkswagen detalle = this.Detalles.Where(d => d.Id == detalleId).First();            
            detalle.Descripcion = nuevaDescripcion;
        }

        public void AnularDetalle(int detalleId)
        {
            DetalleInformeInspeccionVolkswagen detalle = this.Detalles.Where(d => d.Id == detalleId).First();
            detalle.Inactivar();
        }

        public void AnularOpcionesDetalle(int opcionId)
        {
            foreach (var detalle in this.Detalles)
            {
                if (detalle.Opciones.Any(o => o.Id == opcionId))
                {
                    Opcion opcion = detalle.Opciones.Where(o => o.Id == opcionId).First();
                    opcion.Anular();
                }
                else 
                {
                    //break;
                }
            }
        }

        public void CrearOpcionesDetalles()
        {
            foreach (var detalleInformeInspeccionVolkswagen in Detalles)
            {
                detalleInformeInspeccionVolkswagen.CrearOpciones();
            }
        }

        public void AgregarDetalle(string descripcion)
        {
            DetalleInformeInspeccionVolkswagen detalle = new DetalleInformeInspeccionVolkswagen();
            detalle.Descripcion = descripcion;
            this.Detalles.Add(detalle);
        }        

        public void AgregarDetalle(string descripcion, List<Opcion> opcionesCondicion, List<Opcion> opcionesInternas, List<Opcion> opcionesIntervaloKm)
        {
            DetalleInformeInspeccionVolkswagen detalle = new DetalleInformeInspeccionVolkswagen();
            detalle.Descripcion = descripcion;            
            detalle.AgregrarOpciones(opcionesCondicion, opcionesInternas, opcionesIntervaloKm);
            this.Detalles.Add(detalle);
        }
    }

}
