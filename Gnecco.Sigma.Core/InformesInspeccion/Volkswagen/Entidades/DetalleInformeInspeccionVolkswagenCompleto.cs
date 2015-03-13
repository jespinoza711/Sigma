using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades
{
    public class DetalleInformeInspeccionVolkswagenCompleto : DetalleInformeInspeccionCompleto
    {
        public int InformeInspeccionCompletoId { get; set; }
        public int DetalleInformeInspeccionId { get; set; }
        public DetalleInformeInspeccionVolkswagen DetalleInformeInspeccionVolkswagen { get; private set; }

        public DetalleInformeInspeccionVolkswagenCompleto()
        {

        }

        public DetalleInformeInspeccionVolkswagenCompleto(int detalleInformeInspeccionId,
            List<ValorOpcion> valoresOpcionCondicion, List<ValorOpcion> valoresOpcionIntervaloKm, List<ValorOpcion> valoresOpcionInternas)
        {
            DetalleInformeInspeccionId = detalleInformeInspeccionId;
            Valores = valoresOpcionCondicion.Concat(valoresOpcionIntervaloKm).Concat(valoresOpcionInternas).ToList();
        }
    }
}