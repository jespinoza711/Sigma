using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan
{
    public class InformeInspeccionCuerpoCompletoNissanViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<GrupoInformeInspeccionCuerpoCompletoNissanViewModel> Grupos { get; set; }
        public List<GrupoInformeInspeccionCuerpoCompletoNissanViewModel> GruposCalidad { get; set; }
        public List<GrupoInformeInspeccionCuerpoCompletoNissanViewModel> GruposEspeciales { get; set; }

        public void MapearDesde(InformeInspeccionNissan informeInspeccionNissan)
        {
            Descripcion = informeInspeccionNissan.Descripcion;
            Nombre = informeInspeccionNissan.Nombre;
            GruposEspeciales = (
                from G in informeInspeccionNissan.GruposMedicion
                select new GrupoInformeInspeccionCuerpoCompletoNissanViewModel
                {
                    Id = G.Id,
                    DescripcionGrupo = G.Descripcion,
                    TipoGrupo = G.TipoGrupo,
                    Detalles = (
                        from D in G.DetallesActivos
                        select new DetalleInformeInspeccionCuerpoCompletoNissanViewModel
                        {
                            Id = D.Id,                    
                            IndicadorEstado = D.IndicadorEstado,
                            Descripcion = D.Descripcion,
                            OpcionesCheckCalidad =
                            (
                                from OCC in D.OpcionesCheckCalidad
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCC.Id,
                                    Descripcion = OCC.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesCheckRevision =
                            (
                                from OCR in D.OpcionesCheckRevision
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCR.Id,
                                    Descripcion = OCR.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesMedicion =
                            (
                                from OM in D.OpcionesMedicion
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OM.Id,
                                    Descripcion = OM.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList()
                        }
                    ).ToList()
                }
            ).ToList();
            GruposCalidad = (
                from G in informeInspeccionNissan.GruposCalidad
                select new GrupoInformeInspeccionCuerpoCompletoNissanViewModel
                {
                    Id = G.Id,
                    DescripcionGrupo = G.Descripcion,
                    TipoGrupo = G.TipoGrupo,
                    Detalles = (
                        from D in G.DetallesActivos
                        select new DetalleInformeInspeccionCuerpoCompletoNissanViewModel
                        {
                            Id = D.Id,
                            Descripcion = D.Descripcion,
                            OpcionesCheckCalidad =
                            (
                                from OCC in D.OpcionesCheckCalidad
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCC.Id,
                                    Descripcion = OCC.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesCheckRevision =
                            (
                                from OCR in D.OpcionesCheckRevision
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCR.Id,
                                    Descripcion = OCR.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesMedicion =
                            (
                                from OM in D.OpcionesMedicion
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OM.Id,
                                    Descripcion = OM.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList()
                        }
                    ).ToList()
                }
            ).ToList();
            Grupos = (
                from G in informeInspeccionNissan.GruposRevision
                select new GrupoInformeInspeccionCuerpoCompletoNissanViewModel
                {
                    Id = G.Id,                    
                    DescripcionGrupo = G.Descripcion,
                    TipoGrupo = G.TipoGrupo,
                    Detalles = (
                        from D in G.DetallesActivos
                        select new DetalleInformeInspeccionCuerpoCompletoNissanViewModel
                        {
                            Id = D.Id,
                            Descripcion = D.Descripcion,
                            OpcionesCheckCalidad =
                            (
                                from OCC in D.OpcionesCheckCalidad
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCC.Id,
                                    Descripcion = OCC.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesCheckRevision =
                            (
                                from OCR in D.OpcionesCheckRevision
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OCR.Id,
                                    Descripcion = OCR.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList(),
                            OpcionesMedicion =
                            (
                                from OM in D.OpcionesMedicion
                                select new OpcionInformeInspeccionCuerpoCompletoNissanViewModel
                                {
                                    Id = OM.Id,
                                    Descripcion = OM.Descripcion,
                                    Valor = string.Empty
                                }
                            ).ToList()
                        }
                    ).ToList()
                }
            ).ToList();
        }
    }

    public class GrupoInformeInspeccionCuerpoCompletoNissanViewModel
    {
        public int Id { get; set; }
        public string DescripcionGrupo { get; set; }
        public string TipoGrupo { get; set; }
        public List<DetalleInformeInspeccionCuerpoCompletoNissanViewModel> Detalles { get; set; }
    }

    public class DetalleInformeInspeccionCuerpoCompletoNissanViewModel
    {
        public int Id { get; set; }
        public string IndicadorEstado { get; set; }
        public string Descripcion { get; set; }
        public List<OpcionInformeInspeccionCuerpoCompletoNissanViewModel> OpcionesCheckCalidad { get; set; }
        public List<OpcionInformeInspeccionCuerpoCompletoNissanViewModel> OpcionesCheckRevision { get; set; }
        public List<OpcionInformeInspeccionCuerpoCompletoNissanViewModel> OpcionesMedicion { get; set; }
    }

    public class OpcionInformeInspeccionCuerpoCompletoNissanViewModel
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Valor { get; set; }
    }
}