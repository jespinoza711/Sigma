using System.Data.Entity;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Configuracion;
using Gnecco.Sigma.Datos.Shared;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford
{
    public class FordContext : BaseContext
    {
        public DbSet<GrupoInformeInspeccion> GrupoInformeInspeccion { get; set; }
        public DbSet<InformeInspeccionFord> InformeInspeccionFord { get; set; }
        public DbSet<InformeInspeccionFordCompleto> InformeInspeccionFordCompleto { get; set; }
        public DbSet<GrupoArticuloMantenimiento> GrupoArticuloMantenimiento { get; set; }
        public DbSet<GrupoSistemaComponente> GrupoSistemaComponente { get; set; }
        public DbSet<GrupoDesgasteFreno> GrupoDesgasteFreno { get; set; }
        public DbSet<GrupoDesgasteLlanta> GrupoDesgasteLlanta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InformeInspeccionConfiguracion());
            modelBuilder.Configurations.Add(new InformeInspeccionFordConfiguracion());
            

            modelBuilder.Configurations.Add(new GrupoInformeInspeccionConfiguracion());

            modelBuilder.Configurations.Add(new GrupoDesgasteFrenoConfiguracion());
            modelBuilder.Configurations.Add(new SubGrupoDesgasteFrenoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleGrupoDesgasteFrenoConfiguracion());

            modelBuilder.Configurations.Add(new GrupoArticuloMantenimientoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleGrupoArticuloMantenimientoConfiguracion());

            modelBuilder.Configurations.Add(new GrupoDesgasteLlantaConfiguracion());
            modelBuilder.Configurations.Add(new DetalleGrupoDesgasteLlantaConfiguracion());

            modelBuilder.Configurations.Add(new GrupoSistemaComponenteConfiguracion());
            modelBuilder.Configurations.Add(new SubGrupoSistemaComponenteConfiguracion());
            modelBuilder.Configurations.Add(new DetalleGrupoSistemaComponenteConfiguracion());

            modelBuilder.Configurations.Add(new DetalleInformeInspeccionConfiguracion());

            modelBuilder.Configurations.Add(new InformeInspeccionFordCompletoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionFordCompletoConfiguracion());
            modelBuilder.Configurations.Add(new DetalleInformeInspeccionCompletoConfiguracion());
            
            QuitarNissanDelContext(modelBuilder);
            QuitarVolkswagenDelContext(modelBuilder);

            //modelBuilder.Ignore<GrupoDesgasteFreno>();
            //modelBuilder.Ignore<GrupoDesgasteLlanta>();
            //modelBuilder.Ignore<GrupoSistemaComponente>();
            //modelBuilder.Ignore<SubGrupoDesgasteFreno>();
            //modelBuilder.Ignore<SubGrupoSistemaComponente>();
            //modelBuilder.Ignore<DetalleGrupoDesgasteFreno>();
            //modelBuilder.Ignore<DetalleGrupoDesgasteLlanta>();
            //modelBuilder.Ignore<DetalleGrupoSistemaComponente>();

            //    m => m.Requires("CodigoAgrupacion").HasValue(TipoGrupoInformeInspeccionFord.Frenos));
            //Map<GrupoDesgasteLlanta>(
            //    m => m.Requires("CodigoAgrupacion").HasValue(TipoGrupoInformeInspeccionFord.Llanta));
            //Map<GrupoSistemaComponente>(
            //    m => m.Requires("CodigoAgrupacion").HasValue(TipoGrupoInformeInspeccionFord.SistemasComponentes));
            //Map<SubGrupoDesgasteFreno>(
            //    m => m.Requires("CodigoAgrupacion").HasValue(TipoGrupoInformeInspeccionFord.SubGrupoDesgasteFreno));
            //Map<SubGrupoSistemaComponente>(
            //    m => m.Requires("CodigoAgrupacion").HasValue(TipoGrupoInformeInspeccionFord.SubGrupoSistemaComponente));
            base.OnModelCreating(modelBuilder);
        }
    }
}
