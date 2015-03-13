using Gnecco.Sigma.Core.Shared.SAP;
using Gnecco.Sigma.Datos.Sap.Configuracion;
using Gnecco.Sigma.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Sap
{
    public class SapViewContext : SapContext
    {
        public DbSet<ViewSap> ViewSap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SapConfiguracion());
            base.OnModelCreating(modelBuilder);
        }
    }
}
