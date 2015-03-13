using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Configuracion;
using Gnecco.Sigma.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan
{
    public class NissanContext : BaseContext
    {
        public DbSet<InformeInspeccionNissan> InformeInspeccionNissan { get; set; }
        public DbSet<InformeInspeccionNissanCompleto> InformeInspeccionNissanCompleto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InformeInspeccionConfiguracion());
            modelBuilder.Configurations.Add(new GrupoInformeInspeccionNissanCompletoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionCompletoConfiguracion());
            modelBuilder.Configurations.Add(new InformeInspeccionNissanConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionConfiguracion());
            modelBuilder.Configurations.Add(new GrupoDetalleInformeInspeccionNissanConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionNissanConfiguracion());
            modelBuilder.Configurations.Add(new InformeInspeccionNissanCompletoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionNissanCompletoConfiguracion());

            QuitarVolkswagenDelContext(modelBuilder);
            QuitarFordDelContext(modelBuilder);

            base.OnModelCreating(modelBuilder);            
        }
    }
}
