using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Configuracion
{
    public class InformeInspeccionCompletoConfiguracion : EntityTypeConfiguration<InformeInspeccionCompleto>
    {
        public InformeInspeccionCompletoConfiguracion()
        {
            Map<InformeInspeccionNissanCompleto>(m => m.Requires("Tipo").HasValue("Nissan"));
        }
    }

    public class DetalleInformeInspeccionCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionCompleto>
    {
        public DetalleInformeInspeccionCompletoConfiguracion()
        {
            Map<DetalleInformeInspeccionNissanCompleto>(m => m.Requires("Tipo").HasValue("Nissan"));
        }
    }
}
