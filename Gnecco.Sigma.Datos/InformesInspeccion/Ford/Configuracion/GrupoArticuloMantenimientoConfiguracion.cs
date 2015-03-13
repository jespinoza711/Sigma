using System.Data.Entity.ModelConfiguration;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class GrupoArticuloMantenimientoConfiguracion : EntityTypeConfiguration<GrupoArticuloMantenimiento>
    {
        public GrupoArticuloMantenimientoConfiguracion()
        {
            HasMany(m => m.Detalle).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionId);
            Ignore(m => m.DetalleActivo);
        }
    }
}