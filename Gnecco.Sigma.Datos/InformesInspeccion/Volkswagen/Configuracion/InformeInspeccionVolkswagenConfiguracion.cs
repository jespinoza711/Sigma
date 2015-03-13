using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion
{
    public class InformeInspeccionConfiguracion : EntityTypeConfiguration<InformeInspeccion>
    {
        public InformeInspeccionConfiguracion()
        {
            Map<InformeInspeccionVolkswagen>(m => m.Requires("Tipo").HasValue("Volkswagen"));
        }
    }

    public class InformeInspeccionVolkswagenConfiguracion : EntityTypeConfiguration<InformeInspeccionVolkswagen>
    {
        public InformeInspeccionVolkswagenConfiguracion()
        {
            HasMany(m => m.Detalles).WithRequired().HasForeignKey(m => m.InformeInspeccionId);
            HasMany(m => m.InformesInspeccionCompletos).WithRequired().HasForeignKey(m => m.InformeInspeccionId);
            Ignore(m => m.DetallesActivos);
        }
    }

    public class DetalleInformeInspeccionConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccion>
    {
        public DetalleInformeInspeccionConfiguracion()
        {
            Map<DetalleInformeInspeccionVolkswagen>(m => m.Requires("Tipo").HasValue("Volkswagen"));
        }
    }

    public class DetalleInformeInspeccionVolkswagenConfiguracion : EntityTypeConfiguration<DetalleInformeInspeccionVolkswagen>
    {
        public DetalleInformeInspeccionVolkswagenConfiguracion()
        {
            HasMany(m => m.Opciones).WithRequired().HasForeignKey(m => m.DetalleInformeInspeccionId);
            Ignore(m => m.OpcionesCondicion);
            Ignore(m => m.OpcionesInternas);
            Ignore(m => m.OpcionesIntervaloKm);
        }
    }
}
