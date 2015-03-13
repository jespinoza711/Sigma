using Gnecco.Sigma.Core.Inventario;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Inventario.Configuracion
{
    public class InventarioConfiguracion : EntityTypeConfiguration<InventarioVehiculo>
    {
        public InventarioConfiguracion()
        {
            ToTable("Inventario");
            HasMany(m => m.Coordenadas).WithRequired().HasForeignKey(m => m.InventarioId);
            HasMany(m => m.Fotos).WithRequired().HasForeignKey(m => m.InventarioId);
        }
    }
}
