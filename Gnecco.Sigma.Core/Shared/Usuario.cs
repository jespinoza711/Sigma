using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class Usuario : IEntidad
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string IndicadorEstado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Perfil { get; set; }
        public string Pass { get; set; }

        public Usuario()
        {
            this.IndicadorEstado = EstadoEntidad.Activo;
            this.Pass = "123456";
        }
    }

    public class Perfil
    {
        public const string Administrador = "Administrador";
        public const string Tecnico = "Tecnico";
        public const string Asesor = "Asesor";
    }
}
