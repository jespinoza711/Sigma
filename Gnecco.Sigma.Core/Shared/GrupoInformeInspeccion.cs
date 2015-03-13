using Gnecco.Sigma.Core.Shared.Estaticos;
namespace Gnecco.Sigma.Core.Shared
{
    public class GrupoInformeInspeccion : IEntidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int InformeInspeccionId { get; set; }
        public string IndicadorEstado { get; set; }

        public GrupoInformeInspeccion()
        {
            IndicadorEstado = EstadoEntidad.Activo;
        }

        public void EditarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void Inactivar()
        {
            IndicadorEstado = EstadoEntidad.Inactivo;
        }
    }
}
