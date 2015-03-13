using Gnecco.Sigma.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Configuracion;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen
{
    public class VolkswagenContext : BaseContext
    {
        public DbSet<InformeInspeccionVolkswagen> InformeInspeccionVolkswagen { get; set; }
        public DbSet<InformeInspeccionVolkswagenCompleto> InformeInspeccionVolkswagenCompleto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InformeInspeccionConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionCompletoConfiguracion());
            modelBuilder.Configurations.Add(new InformeInspeccionVolkswagenConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionVolkswagenConfiguracion());

            modelBuilder.Configurations.Add(new InformeInspeccionVolkswagenCompletoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionVolkswagenCompletoConfiguracion());

            QuitarNissanDelContext(modelBuilder);
            QuitarFordDelContext(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
