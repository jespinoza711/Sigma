using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Configuracion
{
    public class InformeInspeccionNissanCompletoConfiguracion : EntityTypeConfiguration<InformeInspeccionNissanCompleto>
    {
        public InformeInspeccionNissanCompletoConfiguracion()
        {
            Map(m =>
            {
                m.Properties(p => new { p.Id, p.Fecha, p.IndicadorEstado });
                m.Property(p => p.InformeInspeccionId);
                //m.Property(p => p.Fecha).HasColumnName("Fecha");
                //m.Property(p => p.IndicadorEstado).HasColumnName("IndicadorEstado");
                m.Requires("Tipo").HasValue("Nissan");
                m.ToTable("InformeInspeccionCompleto");
            }).
            Map(m =>
            {
                m.Properties(p => new { p.Id, p.Tecnico });
                m.Property(p => p.Cliente).HasColumnName("Cliente");
                m.Property(p => p.Correctivo).HasColumnName("Correctivo");
                m.Property(p => p.Preventivo).HasColumnName("Preventivo");
                m.Property(p => p.Kms).HasColumnName("Kms");
                m.Property(p => p.NumeroOT).HasColumnName("NumeroOT");
                //m.Property(p => p.Tecnico).HasColumnName("Tecnico");
                m.Property(p => p.Placa).HasColumnName("Placa");
                m.Property(p => p.ResultadosMantenimiento).HasColumnName("ResultadosMantenimiento");
                m.ToTable("InformeInspeccionNissanCompleto");
            });

            HasMany(m => m.GruposInformeInspeccionNissanCompleto).WithRequired().HasForeignKey(m => m.InformeInspeccionCompletoId);
        }
    }

    public class GrupoInformeInspeccionNissanCompletoConfiguracion : EntityTypeConfiguration<GrupoInformeInspeccionNissanCompleto>
    {
        public GrupoInformeInspeccionNissanCompletoConfiguracion()
        {
            ToTable("GrupoInformeInspeccionCompleto");
            HasKey(m => m.Id);
            HasMany(m => m.DetallesInformeInspeccionNissanCompleto).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionCompletoId);
            HasRequired(m => m.GrupoinformeInspeccionNissan).WithMany().HasForeignKey(m => m.GrupoInformeInspeccionId);
        }
    }

    public class DetalleInformeInspeccionNissanCompletoConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionNissanCompleto>
    {
        public DetalleInformeInspeccionNissanCompletoConfiguracion()
        {
            HasRequired(m => m.DetalleInformeInspeccionNissan).WithMany().HasForeignKey(m => m.DetalleInformeInspeccionId);
        }
    }
}
