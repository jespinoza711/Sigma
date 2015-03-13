using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios
{
    public interface IInformeInspeccionNissanCompletoRepositorio
    {
        // POST
        void GuardarInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto);
        // GET
        InformeInspeccionNissanCompleto BuscarPorId(int id);
        List<InformeInspeccionNissanCompleto> ListarInformesInspeccion(int informeInspeccionId);
        // PUT
        void ModificarInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto);
        // DELETE   
        void AnularInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto);
    }
}
