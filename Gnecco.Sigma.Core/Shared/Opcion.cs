using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared
{
    public class Opcion : IEntidad
    {
        public int Id { get; set; }
        public int DetalleInformeInspeccionId { get; set; }
        public string Descripcion { get; set; }
        public int CodigoAgrupacion { get; set; }
        public string IndicadorEstado { get; set; }

        public Opcion()
        {
            this.IndicadorEstado = Estaticos.EstadoEntidad.Activo;
        }

        public Opcion(string descripcion, int codigoAgrupcion)
            :this()
        {
            this.Descripcion = descripcion;
            this.CodigoAgrupacion = codigoAgrupcion;
        }

        public void Anular()
        {
            this.IndicadorEstado = Estaticos.EstadoEntidad.Inactivo;
        }
    }
}
