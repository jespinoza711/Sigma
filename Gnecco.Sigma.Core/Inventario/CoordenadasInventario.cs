using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Inventario
{
    public class CoordenadasInventario
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public decimal PointLeft { get; set; }
        public decimal PointTop { get; set; }
        public decimal PointRight { get; set; }
        public decimal PointBottom { get; set; }
        public int Orden { get; set; }
        public string EstadoAutoparte { get; set; } // Rayado, Abollado, Falta
        public string Comentario { get; set; }
        public bool Tipo { get; set; }

        public CoordenadasInventario()
        {
            this.Comentario = "Comentario Default";
        }
    }
}
