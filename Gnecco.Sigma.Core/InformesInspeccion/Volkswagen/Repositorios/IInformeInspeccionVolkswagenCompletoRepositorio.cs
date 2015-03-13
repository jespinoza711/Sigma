using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios
{
    public interface IInformeInspeccionVolkswagenCompletoRepositorio
    {        
        void GuardarCompleto(InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto);
        InformeInspeccionVolkswagenCompleto GetInformeInspeccionCompletoById(int informeInspeccionId);
        List<InformeInspeccionVolkswagenCompleto> ListarInformesInspeccionCompletosPorInformeInspeccion(int id);
        void AnularInformeInspeccionCompleto(InformeInspeccionVolkswagenCompleto informInspeccionVolkswagenCompleto);
    }
}
