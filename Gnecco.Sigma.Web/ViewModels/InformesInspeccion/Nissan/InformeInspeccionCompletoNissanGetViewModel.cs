using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionCompletoNissanGetViewModel
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string IndicadorEstado { get; set; }
        public int InformeInspeccionId { get; set; }
        public int Preventivo { get; set; }
        public int Correctivo { get; set; }
        public string Kms { get; set; }
        public string NumeroOT { get; set; }
        public string Cliente { get; set; }
        public string Tecnico { get; set; }
        public string Placa { get; set; }
        public string ResultadosMantenimiento { get; set; }
        public string Descripcion { get; set; }
        public List<GrupoCompletoNissanGetViewModel> Grupos { get; set; }
        public List<GrupoCompletoNissanGetViewModel> GruposCalidad { get; set; }
        public List<GrupoCompletoNissanGetViewModel> GruposEspeciales { get; set; }

        public void MapearDesde(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto, InformeInspeccionNissan informeInspeccionNissan)
        {
            this.Id = informeInspeccionNissanCompleto.Id;
            this.Fecha = informeInspeccionNissanCompleto.Fecha.ToShortDateString();
            this.IndicadorEstado = informeInspeccionNissanCompleto.IndicadorEstado;
            this.InformeInspeccionId = informeInspeccionNissanCompleto.InformeInspeccionId;
            this.Preventivo = informeInspeccionNissanCompleto.Preventivo;
            this.Correctivo = informeInspeccionNissanCompleto.Correctivo;
            this.Kms = informeInspeccionNissanCompleto.Kms;
            this.NumeroOT = informeInspeccionNissanCompleto.NumeroOT;
            this.Cliente = informeInspeccionNissanCompleto.Cliente;
            this.Tecnico = informeInspeccionNissanCompleto.Tecnico;
            this.Placa = informeInspeccionNissanCompleto.Placa;
            this.ResultadosMantenimiento = informeInspeccionNissanCompleto.ResultadosMantenimiento;
            this.Descripcion = informeInspeccionNissan.Descripcion;
            this.GruposEspeciales = (
                    from G in informeInspeccionNissanCompleto.GruposInformeInspeccionNissanCompleto
                    where G.GrupoinformeInspeccionNissan.TipoGrupo == TipoGrupoInformeInspeccionNissan.Medicion
                    select new GrupoCompletoNissanGetViewModel
                    {
                        Id = G.Id, // Id de GrupoCompletoNissanGetViewModel
                        Descripcion = G.GrupoinformeInspeccionNissan.Descripcion,
                        TipoGrupo = G.GrupoinformeInspeccionNissan.TipoGrupo,
                        Detalles = (
                            from D in G.DetallesInformeInspeccionNissanCompleto
                            select new DetalleCompletoNissanGetViewModel
                            {
                                Id = D.Id,
                                Descripcion = D.DetalleInformeInspeccionNissan.Descripcion,
                                OpcionesCheckCalidad =
                                (
                                    from OCC in D.Valores
                                    where OCC.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckCalidad
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCC.Id,
                                        OpcionId = OCC.OpcionId,
                                        Descripcion = OCC.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OCC.DetalleInformeInspeccionCompletoId,
                                        Valor = OCC.Valor
                                    }
                                ).ToList(),

                                OpcionesCheckRevision =
                                (
                                    from OCR in D.Valores
                                    where OCR.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckRevision
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCR.Id,
                                        OpcionId = OCR.OpcionId,
                                        Descripcion = OCR.Opcion.Descripcion,
                                        Valor = OCR.Valor,
                                        DetalleInformeInspeccionCompletoId = OCR.DetalleInformeInspeccionCompletoId
                                    }
                                ).ToList(),

                                OpcionesMedicion =
                                (
                                    from OM in D.Valores
                                    where OM.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionMedicion
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OM.Id,
                                        OpcionId = OM.OpcionId,
                                        Descripcion = OM.Opcion.Descripcion,
                                        Valor = OM.Valor,
                                        DetalleInformeInspeccionCompletoId = OM.DetalleInformeInspeccionCompletoId
                                    }
                                ).ToList()
                            }
                        ).ToList()
                    }
                ).ToList();
            this.GruposCalidad = (
                    from G in informeInspeccionNissanCompleto.GruposInformeInspeccionNissanCompleto
                    where G.GrupoinformeInspeccionNissan.TipoGrupo == TipoGrupoInformeInspeccionNissan.Calidad
                    select new GrupoCompletoNissanGetViewModel
                    {
                        Id = G.Id, // Id de GrupoCompletoNissanGetViewModel
                        Descripcion = G.GrupoinformeInspeccionNissan.Descripcion,
                        TipoGrupo = G.GrupoinformeInspeccionNissan.TipoGrupo,
                        Detalles = (
                            from D in G.DetallesInformeInspeccionNissanCompleto
                            select new DetalleCompletoNissanGetViewModel
                            {
                                Id = D.Id,
                                Descripcion = D.DetalleInformeInspeccionNissan.Descripcion,
                                OpcionesCheckCalidad =
                                (
                                    from OCC in D.Valores
                                    where OCC.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckCalidad
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCC.Id,
                                        OpcionId = OCC.OpcionId,
                                        Descripcion = OCC.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OCC.DetalleInformeInspeccionCompletoId,
                                        Valor = OCC.Valor
                                    }
                                ).ToList(),

                                OpcionesCheckRevision =
                                (
                                    from OCR in D.Valores
                                    where OCR.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckRevision
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCR.Id,
                                        OpcionId = OCR.OpcionId,
                                        Descripcion = OCR.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OCR.DetalleInformeInspeccionCompletoId,
                                        Valor = OCR.Valor
                                    }
                                ).ToList(),

                                OpcionesMedicion =
                                (
                                    from OM in D.Valores
                                    where OM.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionMedicion
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OM.Id,
                                        OpcionId = OM.OpcionId,
                                        Descripcion = OM.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OM.DetalleInformeInspeccionCompletoId,
                                        Valor = OM.Valor
                                    }
                                ).ToList()
                            }
                        ).ToList()
                    }
                ).ToList();
            this.Grupos = (
                    from G in informeInspeccionNissanCompleto.GruposInformeInspeccionNissanCompleto
                    where G.GrupoinformeInspeccionNissan.TipoGrupo == TipoGrupoInformeInspeccionNissan.Revision
                    select new GrupoCompletoNissanGetViewModel
                    {
                        Id = G.Id, // Id de GrupoCompletoNissanGetViewModel
                        Descripcion = G.GrupoinformeInspeccionNissan.Descripcion,
                        TipoGrupo = G.GrupoinformeInspeccionNissan.TipoGrupo,
                        Detalles = (
                            from D in G.DetallesInformeInspeccionNissanCompleto
                            select new DetalleCompletoNissanGetViewModel 
                            { 
                                Id = D.Id, 
                                Descripcion = D.DetalleInformeInspeccionNissan.Descripcion,
                                OpcionesCheckCalidad = 
                                (
                                    from OCC in D.Valores
                                    where OCC.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckCalidad
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCC.Id,
                                        OpcionId = OCC.OpcionId,
                                        Descripcion = OCC.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OCC.DetalleInformeInspeccionCompletoId,
                                        Valor = OCC.Valor
                                    }
                                ).ToList(),

                                OpcionesCheckRevision =
                                (
                                    from OCR in D.Valores
                                    where OCR.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionCheckRevision
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OCR.Id,
                                        OpcionId = OCR.OpcionId,
                                        Descripcion = OCR.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OCR.DetalleInformeInspeccionCompletoId,
                                        Valor = OCR.Valor,
                                    }
                                ).ToList(),

                                OpcionesMedicion =
                                (
                                    from OM in D.Valores
                                    where OM.Opcion.CodigoAgrupacion == TipoOpcionNissan.OpcionMedicion
                                    select new ValorOpcionCompletoNissanGetViewModel
                                    {
                                        Id = OM.Id,
                                        OpcionId = OM.OpcionId,
                                        Descripcion = OM.Opcion.Descripcion,
                                        DetalleInformeInspeccionCompletoId = OM.DetalleInformeInspeccionCompletoId,
                                        Valor = OM.Valor
                                    }
                                ).ToList()
                            }
                        ).ToList()
                    }
                ).ToList();
        }
    }

    public class GrupoCompletoNissanGetViewModel
    {
        public int Id { get; set; }
        public string TipoGrupo { get; set; }
        public string Descripcion { get; set; }
        public List<DetalleCompletoNissanGetViewModel> Detalles { get; set; }
    }

    public class DetalleCompletoNissanGetViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<ValorOpcionCompletoNissanGetViewModel> OpcionesCheckCalidad { get; set; }
        public List<ValorOpcionCompletoNissanGetViewModel> OpcionesCheckRevision { get; set; }
        public List<ValorOpcionCompletoNissanGetViewModel> OpcionesMedicion { get; set; }
    }

    public class ValorOpcionCompletoNissanGetViewModel
    {
        public int Id { get; set; }
        public int OpcionId { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public int DetalleInformeInspeccionCompletoId { get; set; }
    }
}