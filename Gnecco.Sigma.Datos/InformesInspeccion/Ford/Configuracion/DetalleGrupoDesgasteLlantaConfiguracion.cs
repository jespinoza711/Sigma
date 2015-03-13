using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class DetalleGrupoDesgasteLlantaConfiguracion
        : EntityTypeConfiguration<DetalleGrupoDesgasteLlanta>
    {
        public DetalleGrupoDesgasteLlantaConfiguracion()
        {
            Property(m => m.GrupoInformeInspeccionId).HasColumnName("GrupoInformeInspeccionId");
            HasMany(m => m.Opciones).WithRequired().HasForeignKey(m => m.DetalleInformeInspeccionId);
            Ignore(m => m.OpcionesDesgaste);
            Ignore(m => m.OpcionesReparacion);
        }
    }
}