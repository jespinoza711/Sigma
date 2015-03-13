using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.Inventario
{
    public class InventarioFotoPostViewModel
    {
        public int Id { get; set; }
        public string Ruta { get; set; }
        public int InventarioId { get; set; }
    }
}