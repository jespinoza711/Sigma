using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class DetalleInformeInspeccionConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccion>
    {
        public DetalleInformeInspeccionConfiguracion()
        {
            Map<DetalleGrupoArticuloMantenimiento>(m => m.Requires("Tipo").HasValue("GrupoArticuloMantenimiento"));
            Map<DetalleGrupoDesgasteFreno>(m => m.Requires("Tipo").HasValue("GrupoDesgasteFreno"));
            Map<DetalleGrupoDesgasteLlanta>(m => m.Requires("Tipo").HasValue("GrupoDesgasteLlanta"));
            Map<DetalleGrupoSistemaComponente>(m => m.Requires("Tipo").HasValue("GrupoSistemaComponente"));
        }
    }
}
