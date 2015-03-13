using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion
{
    public class InformeInspeccionCompletoConfiguracion : EntityTypeConfiguration<InformeInspeccionCompleto>
    {
        public InformeInspeccionCompletoConfiguracion()
        {
            Map<InformeInspeccionVolkswagenCompleto>(m => m.Requires("Tipo").HasValue("Volkswagen"));
        }
    }

    public class DetalleInformeInspeccionCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionCompleto>
    {
        public DetalleInformeInspeccionCompletoConfiguracion()
        {
            Map<DetalleInformeInspeccionVolkswagenCompleto>(m => m.Requires("Tipo").HasValue("Volkswagen"));
        }
    }
}
