using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionCompletoPostViewModel
    {
        public string Tipo { get; set; }
        public int InformeInspeccionId { get; set; }
        public string Comentarios { get; set; }
        public string Fecha { get; set; }
        public string KMS { get; set; }
        public string LETRADISTRIBUCIONMOTOR { get; set; }
        public string CLIENTE { get; set; }
        public string NombreTecnico { get; set; }
        public string OT { get; set; }
        public string PLACA { get; set; }
        public string VIN { get; set; }
        public string IntervaloKilometros { get; set; }
        public List<DetallesCompletosPostViewModel> Detalles { get; set; }
    }

    public class DetallesCompletosPostViewModel
    {
        public int Id { get; set; }        
        public List<ValoresOpcionesPostViewModel> OpcionesCondicion { get; set; }
        public List<ValoresOpcionesPostViewModel> OpcionesInternas { get; set; }
        public List<ValoresOpcionesPostViewModel> OpcionesIntervaloKm { get; set; }
    }

    public class ValoresOpcionesPostViewModel
    {
        public int Id { get; set; }
        public string Valor { get; set; }
    }
}