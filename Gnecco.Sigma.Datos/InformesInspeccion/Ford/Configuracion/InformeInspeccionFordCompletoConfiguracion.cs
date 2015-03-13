using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion
{
    public class InformeInspeccionFordCompletoConfiguracion : EntityTypeConfiguration<InformeInspeccionFordCompleto>
    {
        public InformeInspeccionFordCompletoConfiguracion()
        {
            Map(m =>
            {
                m.Properties(p => new { p.Id, p.Fecha, p.IndicadorEstado });
                m.Property(p => p.InformeInspeccionId);
                m.Requires("Tipo").HasValue("Ford");
                m.ToTable("InformeInspeccionCompleto");
            }).
            Map(m =>
            {
                m.Property(p => p.Cliente.Nombre).HasColumnName("NombreCliente");
                m.Property(p => p.Cliente.CorreoElectronico).HasColumnName("CorreoCliente");
                m.Property(p => p.InformacionVehiculoFord.Anio).HasColumnName("Anio");
                m.Property(p => p.InformacionVehiculoFord.Marca).HasColumnName("Marca");
                m.Property(p => p.InformacionVehiculoFord.Millaje).HasColumnName("Millaje");
                m.Property(p => p.InformacionVehiculoFord.Modelo).HasColumnName("Modelo");
                m.Property(p => p.InformacionVehiculoFord.Placa).HasColumnName("Placa");
                m.Property(p => p.InformacionVehiculoFord.Vin).HasColumnName("Vin");
                m.Properties(p => new { p.Comentarios, p.AsesorServicio, p.Tecnico, p.RoTag, p.MesInspeccionEstatal });
                m.ToTable("InformeInspeccionFordCompleto");
            });

            HasMany(m => m.DetalleCompleto).WithRequired().HasForeignKey(m => m.InformeInspeccionCompletoId);
            HasRequired(m => m.InformeInspeccionFord).WithMany().HasForeignKey(m => m.InformeInspeccionId);
        }
    }
}
