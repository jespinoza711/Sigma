using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionCompletoGetViewModel
    {
        public int InformeInspeccionId { get; set; }
        public string Comentarios { get; set; }
        public string Fecha { get; set; }
        public string Km { get; set; }
        public string LetraDistribucionMotor { get; set; }
        public string NombreTecnico { get; set; }
        public string Orden { get; set; }
        public string Placa { get; set; }
        public string Vin { get; set; }
        public string IntervaloKilometros { get; set; }
        public string Descripcion { get; set; }
        public List<DetallesGetViewModel> Detalles { get; set; }

        public void MapearDesde(InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto, InformeInspeccionVolkswagen informeInspeccionVolkswagen)
        {
            this.InformeInspeccionId = informeInspeccionVolkswagenCompleto.InformeInspeccionId;
            this.Comentarios = informeInspeccionVolkswagenCompleto.Comentarios;
            this.Fecha = informeInspeccionVolkswagenCompleto.Fecha.ToShortDateString();
            this.NombreTecnico = informeInspeccionVolkswagenCompleto.NombreTecnico;
            this.Km = informeInspeccionVolkswagenCompleto.InformacionVehiculo.Km;
            this.LetraDistribucionMotor = informeInspeccionVolkswagenCompleto.InformacionVehiculo.LetraDistribucionMotor;
            this.Orden = informeInspeccionVolkswagenCompleto.InformacionVehiculo.Orden;
            this.Placa = informeInspeccionVolkswagenCompleto.InformacionVehiculo.Placa;
            this.Vin = informeInspeccionVolkswagenCompleto.InformacionVehiculo.Vin;
            this.IntervaloKilometros = informeInspeccionVolkswagenCompleto.InformacionVehiculo.IntervaloKilometros;
            this.Descripcion = informeInspeccionVolkswagen.Descripcion;
            this.Detalles = (
                    from D in informeInspeccionVolkswagenCompleto.DetallesInformeInspeccionVolkswagenCompleto
                    select new DetallesGetViewModel
                    {
                        Id = D.DetalleInformeInspeccionId,
                        Descripcion = D.DetalleInformeInspeccionVolkswagen.Descripcion,
                        OpcionesCondicion = 
                        (
                            from VOC in D.Valores
                            where VOC.Opcion.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionCondicion
                            select new ValoresOpcionesGetViewModel
                            {
                                Id = VOC.Id,
                                Descripcion = VOC.Opcion.Descripcion,
                                Valor = VOC.Valor,
                                OpcionId = VOC.OpcionId,
                                DetalleInformeInspeccionCompletoId = VOC.DetalleInformeInspeccionCompletoId
                            }
                        ).ToList(),
                        OpcionesInternas =
                        (
                            from VOI in D.Valores
                            where VOI.Opcion.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionInterna
                            select new ValoresOpcionesGetViewModel
                            {
                                Id = VOI.Id,
                                Descripcion = VOI.Opcion.Descripcion,
                                Valor = VOI.Valor,
                                OpcionId = VOI.OpcionId,
                                DetalleInformeInspeccionCompletoId = VOI.DetalleInformeInspeccionCompletoId
                            }
                        ).ToList(),
                        OpcionesIntervaloKm =
                        (
                            from VOK in D.Valores
                            where VOK.Opcion.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionesIntervaloKm
                            select new ValoresOpcionesGetViewModel
                            {
                                Id = VOK.Id,
                                Descripcion = VOK.Opcion.Descripcion,
                                Valor = VOK.Valor,
                                OpcionId = VOK.OpcionId,
                                DetalleInformeInspeccionCompletoId = VOK.DetalleInformeInspeccionCompletoId
                            }
                        ).ToList(),
                    }
                ).ToList();
        }
    }

    public class DetallesGetViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<ValoresOpcionesGetViewModel> OpcionesCondicion { get; set; }
        public List<ValoresOpcionesGetViewModel> OpcionesInternas { get; set; }
        public List<ValoresOpcionesGetViewModel> OpcionesIntervaloKm { get; set; }
    }

    public class ValoresOpcionesGetViewModel
    {
        public int Id { get; set; }
        public int DetalleInformeInspeccionCompletoId { get; set; }
        public int OpcionId { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    }
}