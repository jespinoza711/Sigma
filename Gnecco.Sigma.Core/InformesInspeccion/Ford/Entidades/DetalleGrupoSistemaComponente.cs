using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Static;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class DetalleGrupoSistemaComponente : DetalleInformeInspeccion
    {
        public int GrupoInformeInspeccionId { get; set; }
        public List<Opcion> Opciones { get; private set; }

        public List<Opcion> OpcionesAtencion
        {
            get { return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionFord.Atencion).ToList(); } 
        }

        public List<Opcion> OpcionesReparacion
        {
            get { return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionFord.Reparacion).ToList(); }
        }

        private DetalleGrupoSistemaComponente()
        {
            Opciones = new List<Opcion>();
            IndicadorEstado = EstadoEntidad.Activo;
        }

        public DetalleGrupoSistemaComponente(string descripcion)
            :this()
        {
            Descripcion = descripcion;
        }

        public void CrearOpciones()
        {
            Opciones.Add(new Opcion("Verificado y Aprobado en este momento",TipoOpcionFord.Atencion));
            Opciones.Add(new Opcion("Puede requerir futura atencion", TipoOpcionFord.Atencion));
            Opciones.Add(new Opcion("Requiere atencion inmediata", TipoOpcionFord.Atencion));

            Opciones.Add(new Opcion("Reparado",TipoOpcionFord.Reparacion));
        }
    }
}
