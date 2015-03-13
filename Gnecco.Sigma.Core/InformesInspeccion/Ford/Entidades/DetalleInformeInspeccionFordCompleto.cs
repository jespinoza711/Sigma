using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class DetalleInformeInspeccionFordCompleto : DetalleInformeInspeccionCompleto
    {
        public int InformeInspeccionCompletoId { get; set; }
        public int DetalleInformeInspeccionId { get; private set; }

        private DetalleInformeInspeccionFordCompleto()
        {

        }

        public DetalleInformeInspeccionFordCompleto(int detalleInformeInspeccionId
                                                    ,List<ValorOpcion> valores)
        {
            DetalleInformeInspeccionId = detalleInformeInspeccionId;
            Valores = valores;
        }
    }
}
