using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class DetalleInformeInspeccionCompleto : IEntidad
    {
        public int Id { get; set; }
        public List<ValorOpcion> Valores { get; protected set; }
    }
}
