using Gnecco.Sigma.Core.Shared.SAP;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Sap.Configuracion
{
    public class SapConfiguracion : EntityTypeConfiguration<ViewSap>
    {
        public SapConfiguracion()
        {
            ToTable("STR_SIGMA_CONSULTA");
        }
    }
}
