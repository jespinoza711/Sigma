using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Datos.Shared
{
    public abstract class BaseContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<BaseContext>(null);
        }

        public BaseContext()
            :base("GneccoCon")
        {

        }

        public override int SaveChanges()
        {
            foreach (var entidad in ChangeTracker.Entries<IEntidad>().ToList())
            {
                if (entidad.Entity.Id <= 0)
                {
                    entidad.State = EntityState.Added;
                }
                else
                {
                    entidad.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        protected void QuitarVolkswagenDelContext(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<InformeInspeccionVolkswagen>();
            modelBuilder.Ignore<DetalleInformeInspeccionVolkswagen>();
            modelBuilder.Ignore<InformeInspeccionVolkswagenCompleto>();
            modelBuilder.Ignore<DetalleInformeInspeccionVolkswagenCompleto>();         
        }

        protected void QuitarNissanDelContext(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<InformeInspeccionNissan>();
            modelBuilder.Ignore<DetalleInformeInspeccionNissan>();
            modelBuilder.Ignore<InformeInspeccionNissanCompleto>();
            modelBuilder.Ignore<DetalleInformeInspeccionNissanCompleto>();
            modelBuilder.Ignore<GrupoInformeInspeccionNissan>();
            modelBuilder.Ignore<GrupoInformeInspeccionNissanCompleto>();
        }

        protected void QuitarFordDelContext(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<InformeInspeccionFord>();
            modelBuilder.Ignore<GrupoDesgasteFreno>();
            modelBuilder.Ignore<SubGrupoDesgasteFreno>();
            modelBuilder.Ignore<DetalleGrupoDesgasteFreno>();
            modelBuilder.Ignore<GrupoArticuloMantenimiento>();
            modelBuilder.Ignore<DetalleGrupoArticuloMantenimiento>();
            modelBuilder.Ignore<GrupoDesgasteLlanta>();
            modelBuilder.Ignore<DetalleGrupoDesgasteLlanta>();
            modelBuilder.Ignore<GrupoSistemaComponente>();
            modelBuilder.Ignore<SubGrupoSistemaComponente>();
            modelBuilder.Ignore<DetalleGrupoSistemaComponente>();
            modelBuilder.Ignore<InformeInspeccionFordCompleto>();
            modelBuilder.Ignore<DetalleInformeInspeccionFordCompleto>();
        }
    }
}
