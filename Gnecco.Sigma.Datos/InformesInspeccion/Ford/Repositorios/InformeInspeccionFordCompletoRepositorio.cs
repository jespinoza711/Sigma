using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios
{
    public class InformeInspeccionFordCompletoRepositorio : IInformeInspeccionFordCompletoRepositorio
    {
        FordContext _fordContext;
        public InformeInspeccionFordCompletoRepositorio()
        {
            _fordContext = new FordContext();
        }

        public void Guardar(InformeInspeccionFordCompleto informeInspeccionFordCompleto)
        {
            int codigoTemporal = 0;
            foreach (var detalle in informeInspeccionFordCompleto.DetalleCompleto)
            {
                if (detalle.Id <= 0)
                {
                    detalle.Id = --codigoTemporal;
                }

                foreach (var valor in detalle.Valores)
                {
                    if(valor.Id <= 0)
                    {
                        valor.Id = --codigoTemporal;
                    }
                    valor.DetalleInformeInspeccionCompletoId = detalle.Id;
                }
            }

            _fordContext.InformeInspeccionFordCompleto.Attach(informeInspeccionFordCompleto);
            _fordContext.SaveChanges();
        }

        public List<InformeInspeccionFordCompleto> BuscarInformesInspeccionCompletoDeInformeInspeccion(int informeInspeccionId)
        {
            return _fordContext.InformeInspeccionFordCompleto
                        .Where(i => i.IndicadorEstado == EstadoEntidad.Activo &&
                                i.InformeInspeccionId == informeInspeccionId)
                                .ToList();
        }
    }
}
