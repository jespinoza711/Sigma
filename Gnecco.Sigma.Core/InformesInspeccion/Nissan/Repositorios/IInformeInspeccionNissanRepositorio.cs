using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios
{
    public interface IInformeInspeccionNissanRepositorio
    {
        // GET
        List<InformeInspeccionNissan> ListarInformesInspeccion();
        InformeInspeccionNissan BuscarInformeInspeccionPorId(int id);
        // POST
        void GuardarInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan);
        // PUT
        void ModificarInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan);
        // DELETE   
        void AnularInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan);

    }
}
