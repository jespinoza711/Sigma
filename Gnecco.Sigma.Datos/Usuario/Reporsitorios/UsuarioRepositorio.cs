using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Usuario.Reporsitorios
{
    public class UsuarioRepositorio
    {
        private readonly UsuarioContext _context;

        public UsuarioRepositorio()
        {
            _context = new UsuarioContext();
        }

        public Gnecco.Sigma.Core.Shared.Usuario LoginUsuario(string nombreUsuario, string pass)
        {
            return (
                    from U in _context.Usuario
                    where U.NombreUsuario == nombreUsuario && U.Pass == pass
                    select U
                ).First();
        }
    }
}
