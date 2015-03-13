using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class ValorOpcion : IEntidad
    {
        public int Id { get; set; }
        public int OpcionId { get; set; }
        public int DetalleInformeInspeccionCompletoId { get; set; }
        public string Valor { get; set; }
        public Opcion Opcion { get; set; }

        public ValorOpcion()
        {

        }

        public ValorOpcion(int opcionId, string valor)
        {
            Valor = valor;
            OpcionId = opcionId;
        }
    }
}
