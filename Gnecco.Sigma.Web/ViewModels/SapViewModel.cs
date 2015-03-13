using Gnecco.Sigma.Core.Shared.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels
{
    public class SapViewModel
    {
        public int ID { get; set; }
        public int OT { get; set; }
        public string FECHAINGRESO { get; set; }
        //public TimeSpan? HORAINGRESO { get; set; }
        //public Int16? HORAINGRESO { get; set; }
        public string HORAINGRESO { get; set; }
        public string PLACA { get; set; }
        public int? KMLLEGADA { get; set; }
        public string FECHAPROMETIDA { get; set; }
        //public TimeSpan? HORAPROMETIDA { get; set; }
        //public Int16? HORAPROMETIDA { get; set; }
        public string HORAPROMETIDA { get; set; }
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

    public class SapViewModelHandler
    {
        public List<SapViewModel> Listado { get; set; }

        public string FormatoHora(string v)
        {
            string r = "SIN HORA";
            string horas;
            string minutos;

            if (v.Length == 0)
            {
                return r;
            }
            else
            {
                if (Int16.Parse(v) >= 1200)
                {
                    minutos = v.Substring(v.Length - 2);
                    horas = v.Substring(0, minutos.Length);
                    //return v + " ----- " + CompletarCero(horas) + ":" + minutos + " PM";
                    return CompletarCero(horas) + ":" + minutos + " PM";
                }
                else
                {
                    if (v.Length == 3)
                    {
                        minutos = v.Substring(v.Length - 2);
                        horas = v.Substring(0, 1);
                    }
                    else
                    {
                        minutos = v.Substring(v.Length - 2);
                        horas = v.Substring(0, 2);
                    }

                    //return v + " ----- " + CompletarCero(horas) + ":" + minutos + " AM";
                    return CompletarCero(horas) + ":" + minutos + " AM";
                }
            }
        }

        public string CompletarCero(string v)
        {
            if (v.Length == 1)
            {
                return "0" + v;
                //return v;
            }
            else
            {
                return v;
            }
        }

        public string FormatoFecha(string v)
        {
            string r;

            if (v.Length > 0)
            {
                r = v.Substring(0, 10);
            }
            else
            {
                r = "";
            }
            return r;
        }

        public void MapearDesde(List<ViewSap> listadoSap)
        {
            this.Listado = (
                from V in listadoSap
                select new SapViewModel
                {
                    ID = V.ID,
                    OT = V.OT,
                    FECHAINGRESO = FormatoFecha(V.FECHAINGRESO.ToString()),
                    //HORAINGRESO = TimeSpan.FromMinutes(long.Parse(VerificarNull(V.HORAINGRESO.ToString()))),
                    HORAINGRESO = FormatoHora(V.HORAINGRESO.ToString()),
                    PLACA = V.PLACA,
                    KMLLEGADA = V.KMLLEGADA,
                    FECHAPROMETIDA = FormatoFecha(V.FECHAPROMETIDA.ToString()),
                    //HORAPROMETIDA = TimeSpan.FromMinutes(long.Parse(VerificarNull(V.HORAPROMETIDA.ToString()))),
                    HORAPROMETIDA = FormatoHora(V.HORAPROMETIDA.ToString()),
                    DNIRUC = V.DNIRUC,
                    CLIENTE = V.CLIENTE,
                    DIRECCION = V.DIRECCION,
                    EMAIL = V.EMAIL,
                    TELEFONO = V.TELEFONO,
                    COMP = V.COMP,
                    VIN = V.VIN,
                    MESINSPECCIONESTATAL = V.MESINSPECCIONESTATAL,
                    ASESORSERVICIO = V.ASESORSERVICIO,
                    MODELO = V.MODELO,
                    ANIO = V.ANIO,
                    MILLAJE = V.MILLAJE,
                    PREVENTIVO = V.PREVENTIVO,
                    CORREECTIVO = V.CORREECTIVO,
                    KM = V.KM,
                    KMS = V.KMS,
                    LETRADISTRIBUCIONMOTOR = V.LETRADISTRIBUCIONMOTOR,
                    FACTURARA = V.FACTURARA,
                    PROPIETARIO = V.PROPIETARIO,
                    BOLETAFACTURA = V.BOLETAFACTURA
                }
            ).ToList();
        }
    }
}