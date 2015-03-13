using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios
{
    public interface IInformeInspeccionFordCompletoRepositorio
    {
        void Guardar(InformeInspeccionFordCompleto informeInspeccionFordCompleto);
        List<InformeInspeccionFordCompleto> BuscarInformesInspeccionCompletoDeInformeInspeccion(int informeInspeccionId);
    }
}
