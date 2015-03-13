using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios
{
    public interface IInformeInspeccionVolkswagenRepositorio
    {
        // GETs
        List<InformeInspeccionVolkswagen> ListarInformesInspeccion();
        InformeInspeccionVolkswagen BuscarInformeInspeccion(int id);
        // POSTs
        void Guardar(InformeInspeccionVolkswagen informeInspeccionVolkswagen);  
        // PUT
        void Modificar(InformeInspeccionVolkswagen informeInspeccionVolkswagen);
        // DELETE
        void Anular(InformeInspeccionVolkswagen informeInspeccionVolkswagen);
        // BUSQUEDAS
        InformeInspeccionVolkswagen BuscarId(int id);
    }
}
