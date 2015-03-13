using Gnecco.Sigma.Datos.Shared;
using Gnecco.Sigma.Datos.Usuario.Configuracion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Usuario
{
    public class UsuarioContext : BaseContext
    {
        public DbSet<Gnecco.Sigma.Core.Shared.Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguracion());

            base.OnModelCreating(modelBuilder);
        }
    }
}
