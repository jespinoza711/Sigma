using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class GrupoDesgasteFreno : GrupoInformeInspeccion
    {
        public List<SubGrupoDesgasteFreno> SubGrupos { get; private set; }
        public List<SubGrupoDesgasteFreno> SubGruposActivo 
        {
            get { return SubGrupos.Where(s => s.IndicadorEstado == EstadoEntidad.Activo).ToList(); }
        }
        public GrupoDesgasteFreno()
        {
            Descripcion = "Desgaste de Frenos";
            SubGrupos = new List<SubGrupoDesgasteFreno>();
        }

        public void AgregarSubGrupo(SubGrupoDesgasteFreno subGrupoDesgasteFreno)
        {
            SubGrupos.Add(subGrupoDesgasteFreno);
        }

        public SubGrupoDesgasteFreno ObtenerSubGrupo(int subGrupoId)
        {
            return SubGrupos.FirstOrDefault(s => s.Id == subGrupoId);
        }

        public void InactivarSubGrupo(int subGrupoId)
        {
            var subGrupo = SubGrupos.First(s => s.Id == subGrupoId);
            subGrupo.Inactivar();
        }
    }
}
