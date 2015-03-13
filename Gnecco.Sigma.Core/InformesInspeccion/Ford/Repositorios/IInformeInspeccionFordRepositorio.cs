using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios
{
    public interface IInformeInspeccionFordRepositorio
    {
        void Guardar(InformeInspeccionFord informeInspeccionFord);
        List<InformeInspeccionFord> BuscarInformesInspeccionFord();

        InformeInspeccionFord Buscar(int id);

        InformeInspeccionFordCompleto BuscarInformeInspeccionCompleto(int id);
    }
}
