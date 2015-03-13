using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionPostNissanViewModel
    {
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public List<GrupoPostNissanViewModel> Grupos { get; set; }
        public List<GrupoPostNissanViewModel> GruposCalidad { get; set; }
        public List<GrupoPostNissanViewModel> GruposEspeciales { get; set; }
    }

    public class GrupoPostNissanViewModel
    {
        public string DescripcionGrupo { get; set; }
        public List<DetalleInformeInspeccionPostNissanViewModel> Detalles { get; set; }
    }

    public class DetalleInformeInspeccionPostNissanViewModel
    {
        public string Descripcion { get; set; }
        public List<OpcionesPostNissanViewModel> OpcionesCheckRevision { get; set; }
        public List<OpcionesPostNissanViewModel> OpcionesMedicion { get; set; }
        public List<OpcionesPostNissanViewModel> OpcionesCheckCalidad { get; set; }
    }

    public class OpcionesPostNissanViewModel
    {
        public string Descripcion { get; set; }
    }
}