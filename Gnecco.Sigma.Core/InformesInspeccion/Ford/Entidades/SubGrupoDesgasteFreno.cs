using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class SubGrupoDesgasteFreno : GrupoInformeInspeccion
    {
        public int GrupoInformeInspeccionId { get; set; }
        public List<DetalleGrupoDesgasteFreno> Detalle { get; set; }
        public List<DetalleGrupoDesgasteFreno> DetalleActivo
        {
            get { return Detalle.Where(d => d.IndicadorEstado == EstadoEntidad.Activo).ToList(); }
        }

        private SubGrupoDesgasteFreno()
        {
            Detalle = new List<DetalleGrupoDesgasteFreno>();
            IndicadorEstado = EstadoEntidad.Activo;
        }

        public SubGrupoDesgasteFreno(string descripcion)
            :this()
        {
            Descripcion = descripcion;
        }

        public void AgregarModificarDetalle(int detalleId, string descripcion)
        {
            DetalleGrupoDesgasteFreno detalle = Detalle.FirstOrDefault(d => d.Id == detalleId && d.Id != 0);
            if (detalle == null)
            {
                var nuevoDetalle = new DetalleGrupoDesgasteFreno(descripcion);
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
