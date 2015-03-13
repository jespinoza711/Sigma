using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Static;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class GrupoInformeInspeccionConfiguracion : EntityTypeConfiguration<GrupoInformeInspeccion>
    {
        public GrupoInformeInspeccionConfiguracion()
        {
            //HasKey(m => m.Id);
            Map<GrupoArticuloMantenimiento>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.ArticulosMantenimiento));
            Map<GrupoDesgasteFreno>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.Frenos));
            Map<GrupoDesgasteLlanta>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.Llanta));
            Map<GrupoSistemaComponente>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.SistemasComponentes));
            Map<SubGrupoDesgasteFreno>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.SubGrupoDesgasteFreno));
            Map<SubGrupoSistemaComponente>(
                m => m.Requires("TipoGrupo").HasValue(TipoGrupoInformeInspeccionFord.SubGrupoSistemaComponente));
        }
    }
}
