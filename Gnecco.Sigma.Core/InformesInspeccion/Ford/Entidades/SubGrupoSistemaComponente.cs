using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class SubGrupoSistemaComponente : GrupoInformeInspeccion
    {
        public int GrupoInformeInspeccionId { get; set; }
        public List<DetalleGrupoSistemaComponente> Detalle { get; private set; }
        public List<DetalleGrupoSistemaComponente> DetalleActivo 
        {
            get { return Detalle.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList(); }
        }
        private SubGrupoSistemaComponente()
        {
            Detalle = new List<DetalleGrupoSistemaComponente>();
            IndicadorEstado = EstadoEntidad.Activo;
        }

        public SubGrupoSistemaComponente(string descripcion)
            :this()
        {
            Descripcion = descripcion;
        }

        public void AgregarModificarDetalle(int detalleId, string descripcion)
        {
            DetalleGrupoSistemaComponente detalle = Detalle.FirstOrDefault(d => d.Id == detalleId && d.Id != 0);

            if (detalle == null)
            {
                var nuevoDetalle = new DetalleGrupoSistemaComponente(descripcion);
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
