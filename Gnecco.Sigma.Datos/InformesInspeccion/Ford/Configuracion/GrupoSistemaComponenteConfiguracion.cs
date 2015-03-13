using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class GrupoSistemaComponenteConfiguracion : EntityTypeConfiguration<GrupoSistemaComponente>
    {
        public GrupoSistemaComponenteConfiguracion()
        {
            HasMany(m => m.SubGrupos).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionId);
            Ignore(m => m.SubGruposActivo);
        }
    }

    public class SubGrupoSistemaComponenteConfiguracion : EntityTypeConfiguration<SubGrupoSistemaComponente>
    {
        public SubGrupoSistemaComponenteConfiguracion()
        {
            Property(m => m.GrupoInformeInspeccionId).HasColumnName("GrupoInformeInspeccionId");
            HasMany(m => m.Detalle).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionId);
            Ignore(m => m.DetalleActivo);
        }
    }
}