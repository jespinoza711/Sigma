using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class InformeInspeccionNissanCompleto : Gnecco.Sigma.Core.Shared.InformeInspeccionCompleto
    {
        public int InformeInspeccionId { get; set; }
        public int Preventivo { get; set; }
        public int Correctivo { get; set; }
        public string Kms { get; set; }
        public string NumeroOT { get; set; }
        public string Cliente { get; set; }
        public string Tecnico { get; set; }
        public string Placa { get; set; }
        public string ResultadosMantenimiento { get; set; }
        public List<GrupoInformeInspeccionNissanCompleto> GruposInformeInspeccionNissanCompleto { get; set; }

        public InformeInspeccionNissanCompleto()
        {
            
        }

    }
}
