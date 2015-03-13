using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionCompletoPostNissanViewModel
    {
        public string Tipo { get; set; }
        public int InformeInspeccionId { get; set; }
        public int PREVENTIVO { get; set; }
        public int CORRECTIVO { get; set; }
        public string KM { get; set; }
        public string OT { get; set; }
        public string CLIENTE { get; set; }
        public string Tecnico { get; set; }
        public string PLACA { get; set; }
        public string ResultadosMantenimiento { get; set; }
        public List<GrupoInformeInspeccionCompletoPostNissanViewModel> Grupos { get; set; }
        public List<GrupoInformeInspeccionCompletoPostNissanViewModel> GruposCalidad { get; set; }
        public List<GrupoInformeInspeccionCompletoPostNissanViewModel> GruposEspeciales { get; set; }
    }

    public class GrupoInformeInspeccionCompletoPostNissanViewModel
    {
        public int Id { get; set; }
        public List<DetalleInformeInspeccionCompletoNissanViewModel> Detalles { get; set; }
    }

    public class DetalleInformeInspeccionCompletoNissanViewModel
    {
        public int Id { get; set; }
        public List<ValorOpcionesNissanViewModel> OpcionesCheckRevision { get; set; }
        public List<ValorOpcionesNissanViewModel> OpcionesMedicion { get; set; }
        public List<ValorOpcionesNissanViewModel> OpcionesCheckCalidad { get; set; }
    }

    public class ValorOpcionesNissanViewModel
    {
        public int Id { get; set; }
        public string Valor { get; set; }
    }
}