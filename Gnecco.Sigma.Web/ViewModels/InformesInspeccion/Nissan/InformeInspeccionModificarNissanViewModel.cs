using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionModificarNissanViewModel
    {
        public int InformeInspeccionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<GrupoModificarNissanViewModel> Grupos { get; set; }
        public List<GrupoModificarNissanViewModel> GruposCalidad { get; set; }
        public List<GrupoModificarNissanViewModel> GruposEspeciales { get; set; }
        public List<GrupoModificarNissanViewModel> GruposAnulados { get; set; }
        public List<DetalleModificarNissanViewModel> DetallesAnulados { get; set; }
        public List<OpcionModificarNissanViewModel> OpcionesAnulados { get; set; }
    }

    public class GrupoModificarNissanViewModel
    {
        public int Id { get; set; } // Id de Grupo
        //public string TipoGrupo { get; set; }
        public string DescripcionGrupo { get; set; }
        public List<DetalleModificarNissanViewModel> Detalles { get; set; }
    }

    public class DetalleModificarNissanViewModel
    {
        public int Id { get; set; } // Id de Detalle
        public string Descripcion { get; set; }
        public List<OpcionModificarNissanViewModel> OpcionesCheckCalidad { get; set; }
        public List<OpcionModificarNissanViewModel> OpcionesCheckRevision { get; set; }
        public List<OpcionModificarNissanViewModel> OpcionesMedicion { get; set; }
    }

    public class OpcionModificarNissanViewModel
    {
        public int Id { get; set; } // Id de Opcion
        public string Descripcion { get; set; }
    }
}