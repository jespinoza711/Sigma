using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class DetalleInformeInspeccionCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionCompleto>
    {
        public DetalleInformeInspeccionCompletoConfiguracion()
        {
            Map<DetalleInformeInspeccionFordCompleto>(m => m.Requires("Tipo").HasValue("Ford"));
        }
    }

    public class DetalleInformeInspeccionFordCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionFordCompleto>
    {
        public DetalleInformeInspeccionFordCompletoConfiguracion()
        {
            HasMany(m => m.Valores).WithRequired().HasForeignKey(m => m.DetalleInformeInspeccionCompletoId);
        }
    }
}
