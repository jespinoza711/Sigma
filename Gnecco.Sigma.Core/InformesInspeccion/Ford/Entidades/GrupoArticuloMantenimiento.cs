using System.Collections.Generic;
using Gnecco.Sigma.Core.Shared;
using System.Linq;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class GrupoArticuloMantenimiento : GrupoInformeInspeccion
    {
        public List<DetalleGrupoArticuloMantenimiento> Detalle { get; private set; }
        public List<DetalleGrupoArticuloMantenimiento> DetalleActivo 
        {
            get { return Detalle.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList(); }     
        }

        public GrupoArticuloMantenimiento()
        {
            Descripcion = "Articulos de Mantenimiento que necesitan revision en esta visita";
            Detalle = new List<DetalleGrupoArticuloMantenimiento>();
        }

        public void AgregarModificarDetalle(int detalleId, string descripcion)
        {
            DetalleGrupoArticuloMantenimiento detalle = Detalle.FirstOrDefault(d => d.Id == detalleId && d.Id != 0);
            if (detalle == null)
            {
                var nuevoDetalle = new DetalleGrupoArticuloMantenimiento(descripcion);
                nuevoDetalle.CrearOpciones();
                Detalle.Add(nuevoDetalle);
            }
            else
            {
                detalle.Descripcion = descripcion;
            }
            
        }

        public void InactivarDetalle(int detalleId)
        {
            var detalle = Detalle.First(d => d.Id == detalleId);
            detalle.Inactivar();
        }
    }
}
