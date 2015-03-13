using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Static;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class DetalleGrupoDesgasteLlanta : DetalleInformeInspeccion
    {
        public int GrupoInformeInspeccionId { get; set; }
        public List<Opcion> Opciones { get; private set; }
        public List<Opcion> OpcionesDesgaste
        {
            get { return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionFord.Desgaste).ToList(); }
        }

        public List<Opcion> OpcionesReparacion
        {
            get { return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionFord.Reparacion).ToList(); }
        }

        private DetalleGrupoDesgasteLlanta()
        {
            Opciones = new List<Opcion>();
            IndicadorEstado = EstadoEntidad.Activo;
        }

        public DetalleGrupoDesgasteLlanta(string descripcion)
            :this()
        {
            Descripcion = descripcion;
        }

        public void CrearOpciones()
        {
            Opciones.Add(new Opcion("Vencido", TipoOpcionFord.Desgaste));
            Opciones.Add(new Opcion("Reparado", TipoOpcionFord.Reparacion));
        }
    }
}
