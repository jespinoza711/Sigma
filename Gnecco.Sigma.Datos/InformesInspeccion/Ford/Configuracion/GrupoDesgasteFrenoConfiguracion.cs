using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class GrupoDesgasteFrenoConfiguracion : EntityTypeConfiguration<GrupoDesgasteFreno>
    {
        public GrupoDesgasteFrenoConfiguracion()
        {
            HasMany(m => m.SubGrupos).WithOptional().HasForeignKey(m => m.GrupoInformeInspeccionId);
            Ignore(m => m.SubGruposActivo);
        }
    }

    public class SubGrupoDesgasteFrenoConfiguracion : EntityTypeConfiguration<SubGrupoDesgasteFreno>
    {
        public SubGrupoDesgasteFrenoConfiguracion()
        {
            Property(m => m.GrupoInformeInspeccionId).HasColumnName("GrupoInformeInspeccionId");
            HasMany(m => m.Detalle).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionId);
            Ignore(m => m.DetalleActivo);
        }
    }
}