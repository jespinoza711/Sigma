using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class GrupoInformeInspeccionNissanCompleto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int InformeInspeccionCompletoId { get; set; }
        public int GrupoInformeInspeccionId { get; set; }
        public GrupoInformeInspeccionNissan GrupoinformeInspeccionNissan { get; set; }
        public List<DetalleInformeInspeccionNissanCompleto> DetallesInformeInspeccionNissanCompleto { get; set; }

        public GrupoInformeInspeccionNissanCompleto()
        {

        }

        public GrupoInformeInspeccionNissanCompleto(int grupoInformeInspeccionId, List<DetalleInformeInspeccionNissanCompleto> detalles)
        {
            this.GrupoInformeInspeccionId = grupoInformeInspeccionId;
            this.DetallesInformeInspeccionNissanCompleto = detalles;
        }
    }
}
