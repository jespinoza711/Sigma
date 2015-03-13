using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionCuerpoCompletoViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<DetalleInformeInspeccionViewModel> Detalles { get; set; }

        public void MapearDesde(InformeInspeccionVolkswagen informeInspeccionVolkswagen)
        {
            Descripcion = informeInspeccionVolkswagen.Descripcion;
            Nombre = informeInspeccionVolkswagen.Nombre;
            Detalles = (
                from D in informeInspeccionVolkswagen.DetallesActivos
                select new DetalleInformeInspeccionViewModel
                {
                    Id = D.Id,
                    Descripcion = D.Descripcion,
                    OpcionCondicionSeleccionada = string.Empty,
                    OpcionesCondicion =
                    (
                        from OC in D.OpcionesCondicion
                        select new OpcionInformeInspeccionViewModel
                        {
                            Id = OC.Id,
                            Descripcion = OC.Descripcion,
                            Valor = string.Empty
                        }
                    ).ToList(),
                    OpcionesInternas =
                    (
                        from OI in D.OpcionesInternas
                        select new OpcionInformeInspeccionViewModel
                        {
                            Id = OI.Id,
                            Descripcion = OI.Descripcion,
                            Valor = string.Empty
                        }
                    ).ToList(),
                    OpcionesIntervaloKm =
                    (
                        from OIK in D.OpcionesIntervaloKm
                        select new OpcionInformeInspeccionViewModel
                        {
                            Id = OIK.Id,
                            Descripcion = OIK.Descripcion,
                            Valor = string.Empty
                        }
                    ).ToList()
                }
            ).ToList();
        }
    }

    public class DetalleInformeInspeccionViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string OpcionCondicionSeleccionada { get; set; }
        public List<OpcionInformeInspeccionViewModel> OpcionesCondicion { get; set; }
        public List<OpcionInformeInspeccionViewModel> OpcionesInternas { get; set; }
        public List<OpcionInformeInspeccionViewModel> OpcionesIntervaloKm { get; set; }
    }

    public class OpcionInformeInspeccionViewModel
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Valor { get; set; }
    }
}