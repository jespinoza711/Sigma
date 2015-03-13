using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.Inventario;
using Gnecco.Sigma.Datos.Inventario.Configuracion;

namespace Gnecco.Sigma.Datos.Inventario
{
    public class InventarioContext : Gnecco.Sigma.Datos.Shared.BaseContext
    {
        public DbSet<InventarioVehiculo> Inventario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InventarioConfiguracion());
            base.OnModelCreating(modelBuilder);
        }
    }
}
