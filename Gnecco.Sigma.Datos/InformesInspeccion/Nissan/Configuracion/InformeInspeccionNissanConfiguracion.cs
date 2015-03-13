using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Configuracion
{
    public class InformeInspeccionConfiguracion : EntityTypeConfiguration<InformeInspeccion>
    {
        public InformeInspeccionConfiguracion()
        {
            Map<InformeInspeccionNissan>(m => m.Requires("Tipo").HasValue("Nissan"));
        }
    }

    public class InformeInspeccionNissanConfiguracion : EntityTypeConfiguration<InformeInspeccionNissan>
    {
        public InformeInspeccionNissanConfiguracion()
        {
            HasMany(m => m.GruposDetallesInformeInspeccionNissan).WithRequired().HasForeignKey(m => m.InformeInspeccionId);
            HasMany(m => m.InformesInspeccionCompletos).WithRequired().HasForeignKey(m => m.InformeInspeccionId);
            Ignore(m => m.GruposActivos);
            Ignore(m => m.GruposCalidad);
            Ignore(m => m.GruposMedicion);
            Ignore(m => m.GruposRevision);
        }
    }

    public class DetalleInformeInspeccionConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccion>
    {
        public DetalleInformeInspeccionConfiguracion()
        {
            Map<DetalleInformeInspeccionNissan>(m => m.Requires("Tipo").HasValue("Nissan"));
        }
    }

    public class DetalleInformeInspeccionNissanConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionNissan>
    {
        public DetalleInformeInspeccionNissanConfiguracion()
        {
            HasMany(m => m.Opciones).WithRequired().HasForeignKey(m => m.DetalleInformeInspeccionId);
            Property(m => m.GrupoInformeInspeccionNissanId).HasColumnName("GrupoInformeInspeccionId");
            Ignore(m => m.OpcionesCheckCalidad);
            Ignore(m => m.OpcionesCheckRevision);
            Ignore(m => m.OpcionesMedicion);
        }
    }

    public class GrupoDetalleInformeInspeccionNissanConfiguracion : EntityTypeConfiguration<GrupoInformeInspeccionNissan>
    {
        public GrupoDetalleInformeInspeccionNissanConfiguracion()
        {
            ToTable("GrupoInformeInspeccion");
            HasKey(m => m.Id);
            HasMany(m => m.Detalles).WithRequired().HasForeignKey(m => m.GrupoInformeInspeccionNissanId);
            Ignore(m => m.DetallesActivos);
        }
    }
}
