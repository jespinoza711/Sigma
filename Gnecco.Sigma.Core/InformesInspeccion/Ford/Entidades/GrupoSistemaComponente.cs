using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class GrupoSistemaComponente : GrupoInformeInspeccion
    {
        public List<SubGrupoSistemaComponente> SubGrupos { get; private set; }
        public List<SubGrupoSistemaComponente> SubGruposActivo 
        {
            get { return SubGrupos.Where(s => s.IndicadorEstado == EstadoEntidad.Activo).ToList(); }
        }

        public GrupoSistemaComponente()
        {
            Descripcion = "Revisar los siguientes Sistemas/Componentes";
            SubGrupos = new List<SubGrupoSistemaComponente>();
        }

        public void AgregarSubGrupo(SubGrupoSistemaComponente subGrupoSistemaComponente)
        {
            SubGrupos.Add(subGrupoSistemaComponente);
        }

        public SubGrupoSistemaComponente ObtenerSubGrupo(int subGrupoId)
        {
            return SubGrupos.FirstOrDefault(s => s.Id == subGrupoId);
        }
    }
}
