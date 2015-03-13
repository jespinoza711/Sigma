using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion
{
    public class InformeInspeccionVolkswagenCompletoConfiguracion : EntityTypeConfiguration<InformeInspeccionVolkswagenCompleto>
    {
        public InformeInspeccionVolkswagenCompletoConfiguracion()
        {
            Map(m =>
            {
                m.Properties(p => new { p.Id, p.InformeInspeccionId, p.Fecha, p.IndicadorEstado});
                m.Requires("Tipo").HasValue("Volkswagen");
                m.ToTable("InformeInspeccionCompleto");
            }).
            Map(m => 
            {
                m.Properties(p => new { p.Id, p.NombreTecnico, p.Comentarios });
                m.Property(p => p.InformacionVehiculo.Vin).HasColumnName("Vin");
                m.Property(p => p.InformacionVehiculo.Placa).HasColumnName("Placa");
                m.Property(p => p.InformacionVehiculo.Orden).HasColumnName("Orden");
                m.Property(p => p.InformacionVehiculo.LetraDistribucionMotor).HasColumnName("LetraDistribucionMotor");
                m.Property(p => p.InformacionVehiculo.Km).HasColumnName("Km");
                m.Property(p => p.InformacionVehiculo.IntervaloKilometros).HasColumnName("IntervaloKilometros");
                m.Property(p => p.InformacionVehiculo.Cliente).HasColumnName("Cliente");
                m.ToTable("InformeInspeccionVolkswagenCompleto");
            });

            HasMany(m => m.DetallesInformeInspeccionVolkswagenCompleto).WithRequired().HasForeignKey(m => m.InformeInspeccionCompletoId);
        }
    }

    public class DetalleInformeInspeccionVolkswagenCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionVolkswagenCompleto>
    {
        public DetalleInformeInspeccionVolkswagenCompletoConfiguracion()
        {
            HasRequired(m => m.DetalleInformeInspeccionVolkswagen).WithMany().HasForeignKey(m => m.DetalleInformeInspeccionId);
        }
    }
}
