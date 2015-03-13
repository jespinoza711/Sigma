using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades
{
    public class DetalleInformeInspeccionNissanCompleto : Gnecco.Sigma.Core.Shared.DetalleInformeInspeccionCompleto
    {
        public int GrupoInformeInspeccionCompletoId { get; set; }
        public int DetalleInformeInspeccionId { get; set; }
        public DetalleInformeInspeccionNissan DetalleInformeInspeccionNissan { get; set; }

        public DetalleInformeInspeccionNissanCompleto()
        {

        }

        public DetalleInformeInspeccionNissanCompleto(int detalleInformeInspeccionId, List<ValorOpcion> valoresOpcion)
        {
            this.DetalleInformeInspeccionId = detalleInformeInspeccionId;
            this.Valores = valoresOpcion;
        }

        public void AgregarDetalleValores(int detalleInformeInspeccionId, List<ValorOpcion> valoresOpcion) 
        {
            this.DetalleInformeInspeccionId = detalleInformeInspeccionId;
            this.Valores = valoresOpcion;
        }
    }
}
