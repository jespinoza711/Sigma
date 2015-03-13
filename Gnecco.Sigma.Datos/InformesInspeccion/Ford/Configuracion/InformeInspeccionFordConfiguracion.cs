using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class InformeInspeccionConfiguracion : EntityTypeConfiguration<InformeInspeccion>
    {
        public InformeInspeccionConfiguracion()
        {
            Map<InformeInspeccionFord>(m => m.Requires("Tipo").HasValue("Ford"));
        }
    }
    public class InformeInspeccionFordConfiguracion : EntityTypeConfiguration<InformeInspeccionFord>
    {
        public InformeInspeccionFordConfiguracion()
        {
            HasMany(m => m.Grupos).WithRequired().HasForeignKey(m => m.InformeInspeccionId);
            Ignore(m => m.GrupoArticuloMantenimiento);
            Ignore(m => m.GrupoSistemaComponente);
            Ignore(m => m.GrupoDesgasteLlanta);
            Ignore(m => m.GrupoDesgasteFreno);
        }
    }
}
