using Gnecco.Sigma.Core.Shared.Estaticos;

namespace Gnecco.Sigma.Core.Shared
{
    public class DetalleInformeInspeccion : IEntidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string IndicadorEstado { get; set; }

        public DetalleInformeInspeccion()
        {
            this.IndicadorEstado = EstadoEntidad.Activo;
        }

        public void Inactivar()
        {
            this.IndicadorEstado = EstadoEntidad.Inactivo;
        }
    }

}
