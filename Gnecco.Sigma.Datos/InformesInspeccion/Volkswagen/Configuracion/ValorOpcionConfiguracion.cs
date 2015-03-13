using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using System.Data.Entity.ModelConfiguration;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion
{
    public class ValorOpcionConfiguracion : EntityTypeConfiguration<ValorOpcion>
    {
        public ValorOpcionConfiguracion()
        {
            //HasMany(m => m.OpcionId).WithRequired().HasForeignKey(m => m.);
            HasRequired(t => t.Opcion).WithMany().HasForeignKey(m => m.OpcionId);
        }
    }
}
