using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Shared.SAP
{
    public class ViewSap
    {
        public int ID { get; set; }
        public int OT { get; set; }
        public DateTime? FECHAINGRESO { get; set; }
        public Int16? HORAINGRESO { get; set; }
        public string PLACA { get; set; }
        public int? KMLLEGADA { get; set; }
        public DateTime? FECHAPROMETIDA { get; set; }
        public Int16? HORAPROMETIDA { get; set; }
        public string DNIRUC { get; set; }
        public string CLIENTE { get; set; }
        public string DIRECCION { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string COMP { get; set; }
        
        public string VIN { get; set; }
        public string MESINSPECCIONESTATAL { get; set; }
        public string ASESORSERVICIO { get; set; }
        public string MODELO { get; set; }
        public Int16? ANIO { get; set; }
        public object MILLAJE { get; set; }
        public object PREVENTIVO { get; set; }
        public object CORREECTIVO { get; set; }
        public object KM { get; set; }
        public object KMS { get; set; }
        public string LETRADISTRIBUCIONMOTOR { get; set; }
        public object FACTURARA { get; set; }
        public string PROPIETARIO { get; set; }
        public object BOLETAFACTURA { get; set; }
        
    }
}
