using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class InformeInspeccion : IEntidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string IndicadorEstado { get; private set; }

        public InformeInspeccion()
        {
            IndicadorEstado = EstadoEntidad.Activo;
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Campo para discriminar la herencia si es Volkswagen, Ford, etc..
        /// </summary>
        //public string Tipo { get; set; }

       // public List<InformeInspeccionCompleto> InformesInspeccionCompleto { get; set; }

        public void Anular()
        {
            this.IndicadorEstado = EstadoEntidad.Inactivo;
        }
    }
}
