using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Usuario.Configuracion
{
    public class UsuarioConfiguracion : EntityTypeConfiguration<Gnecco.Sigma.Core.Shared.Usuario>
    {
        public UsuarioConfiguracion()
        {
            ToTable("Usuario");            
        }
    }
}
