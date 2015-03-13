using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class InformeInspeccionCompleto : IEntidad
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IndicadorEstado { get; set; }
        
        public InformeInspeccionCompleto()
        {
            IndicadorEstado = EstadoEntidad.Activo;
            Fecha = DateTime.Now;
        }

        public virtual void Anular()
        {
            this.IndicadorEstado = EstadoEntidad.Inactivo;
        }
    }
}
