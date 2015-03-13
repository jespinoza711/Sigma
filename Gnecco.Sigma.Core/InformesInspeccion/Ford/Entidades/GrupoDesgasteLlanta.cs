using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class GrupoDesgasteLlanta : GrupoInformeInspeccion
    {
        public List<DetalleGrupoDesgasteLlanta> Detalle { get; private set; }
        public List<DetalleGrupoDesgasteLlanta> DetalleActivo
        {
            get { return Detalle.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList(); }
        }

        public GrupoDesgasteLlanta()
        {
            Descripcion = "Desgaste de Llantas";
            Detalle = new List<DetalleGrupoDesgasteLlanta>();
        }

        public void AgregarModificarDetalle(int detalleId, string descripcion)
        {
            var detalle = Detalle.FirstOrDefault(d => d.Id == detalleId && d.Id != 0);

            if(detalle == null)
            {
                var nuevoDetalle = new DetalleGrupoDesgasteLlanta(descripcion);
                nuevoDetalle.CrearOpciones();
                Detalle.Add(nuevoDetalle);
            }
            else
            {
                detalle.Descripcion = descripcion;
            }
            
        }
    }
}
