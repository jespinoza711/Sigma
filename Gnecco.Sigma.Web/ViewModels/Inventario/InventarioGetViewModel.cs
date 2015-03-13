using Gnecco.Sigma.Core.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.Inventario
{
    public class InventarioGetViewModel
    {       
        public int Id { get; set; }
        public string OT { get; set; }
        #region DatosInventario
        // Propiedades del SAP
        public string FechaRecepcion { get; set; }
        public string HoraRecepcion { get; set; }
        public string Placa { get; set; }
        public string KilometrajeLlegada { get; set; }
        public string FechaPrometida { get; set; }
        public string HoraPrometida { get; set; }
        public string FacturarA { get; set; }
        public string Ruc { get; set; }
        public string Propietario { get; set; }
        public bool BoletaFactura { get; set; } // True Boleta, False Factura
        public string Direccion { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Dni { get; set; }
        #endregion
        // Propiedades del Usuario
        public string ManifestoCliente { get; set; }
        #region InventarioRecepcion
        // Propiedades Inventario Recepcion
        public bool Cenicero { get; set; }
        public bool Encendedor { get; set; }
        public bool Radio { get; set; }
        public bool MascaraRadio { get; set; }
        public bool Antena { get; set; }
        public bool TarjetaPropiedad { get; set; }
        public bool Soat { get; set; }
        public bool SeguroRueda { get; set; }
        public bool VasosRueda { get; set; }
        public bool LucesBajas { get; set; }
        public bool TapaSol { get; set; }
        public bool PlumillasDuchas { get; set; }
        public bool Escapines { get; set; }
        public bool EmblMascara { get; set; }
        public bool TapaAceite { get; set; }
        public bool TapaTanqueComb { get; set; }
        public bool TapaRadiador { get; set; }
        public bool TapaDepRefrg { get; set; }
        public bool TapaDepLiqFren { get; set; }
        public bool LlantaRepuesto { get; set; }
        public bool LucesAltas { get; set; }
        public bool Neblineros { get; set; }
        public bool Claxon { get; set; }
        public bool Espejos { get; set; }
        public bool PisosJebeAlfombra { get; set; }
        public bool CorteCorriente { get; set; }
        public bool LunasElectricasDelt { get; set; }
        public bool LunasElectricasPost { get; set; }
        public bool SistVentilador { get; set; }
        public bool Tacometro { get; set; }
        public bool GataPalanca { get; set; }
        public bool LlaveRueda { get; set; }
        public bool EmblMaletera { get; set; }
        public bool Herramientas { get; set; }
        public bool CajaCd { get; set; }
        public bool Botiquin { get; set; }
        public bool Extintor { get; set; }
        public bool Triangulo { get; set; }
        public bool CableBateria { get; set; }
        public bool CableRemolque { get; set; }
        #endregion
        // Mas Propiedades
        public bool ObjetosValor { get; set; }
        public bool VehiculoSucioRayaduras { get; set; }
        // Parte baja del Formulario
        public string Asesor { get; set; }
        public string Observaciones { get; set; }
        #region DatosFirma
        public string RutaFirma { get; set; }        
        #endregion
        #region Coordenadas
        public List<CoordenadasGetViewModel> Coordenadas { get; set; }
        public List<CoordenadasGetViewModel> CoordenadasGasolina { get; set; }
        public List<InventarioFotoGetViewModel> Fotos { get; set; }
        //public List<Circle> Coordenadas { get; set; }        
        #endregion

        public void MapearDesde(InventarioVehiculo inventarioVehiculo) 
        {
            string RutaFisicaFotos = "/Uploads/Fotos/";

            this.Id = inventarioVehiculo.Id;
            this.OT = inventarioVehiculo.NumeroOT;
            this.FechaRecepcion = inventarioVehiculo.FechaRecepcion;
            this.HoraRecepcion = inventarioVehiculo.HoraRecepcion;
            this.Placa = inventarioVehiculo.Placa;
            this.KilometrajeLlegada = inventarioVehiculo.KilometrajeLlegada;
            this.FechaPrometida = inventarioVehiculo.FechaPrometida;
            this.HoraPrometida = inventarioVehiculo.HoraPrometida;
            this.FacturarA = inventarioVehiculo.FacturarA;
            this.Ruc = inventarioVehiculo.Ruc;
            this.Propietario = inventarioVehiculo.Propietario;
            this.BoletaFactura = inventarioVehiculo.BoletaFactura;
            this.Direccion = inventarioVehiculo.Direccion;
            this.TelefonoMovil = inventarioVehiculo.TelefonoMovil;
            this.CorreoElectronico = inventarioVehiculo.CorreoElectronico;
            this.Dni = inventarioVehiculo.Dni;

            this.ManifestoCliente = inventarioVehiculo.ManifestoCliente;

            this.Cenicero = inventarioVehiculo.Cenicero;
            this.Encendedor = inventarioVehiculo.Encendedor;
            this.Radio = inventarioVehiculo.Radio;
            this.MascaraRadio = inventarioVehiculo.MascaraRadio;
            this.Antena = inventarioVehiculo.Antena;
            this.TarjetaPropiedad = inventarioVehiculo.TarjetaPropiedad;
            this.Soat = inventarioVehiculo.Soat;
            this.SeguroRueda = inventarioVehiculo.SeguroRueda;
            this.VasosRueda = inventarioVehiculo.VasosRueda;
            this.LucesBajas = inventarioVehiculo.LucesBajas;
            this.TapaSol = inventarioVehiculo.TapaSol;
            this.PlumillasDuchas = inventarioVehiculo.PlumillasDuchas;
            this.Escapines = inventarioVehiculo.Escapines;
            this.EmblMascara = inventarioVehiculo.EmblMascara;
            this.TapaAceite = inventarioVehiculo.TapaAceite;
            this.TapaTanqueComb = inventarioVehiculo.TapaTanqueComb;
            this.TapaRadiador = inventarioVehiculo.TapaRadiador;
            this.TapaDepRefrg = inventarioVehiculo.TapaDepRefrg;
            this.TapaDepLiqFren = inventarioVehiculo.TapaDepLiqFren;
            this.LlantaRepuesto = inventarioVehiculo.LlantaRepuesto;
            this.LucesAltas = inventarioVehiculo.LucesAltas;
            this.Neblineros = inventarioVehiculo.Neblineros;
            this.Claxon = inventarioVehiculo.Claxon;
            this.Espejos = inventarioVehiculo.Espejos;
            this.PisosJebeAlfombra = inventarioVehiculo.PisosJebeAlfombra;
            this.CorteCorriente = inventarioVehiculo.CorteCorriente;
            this.LunasElectricasDelt = inventarioVehiculo.LunasElectricasDelt;
            this.LunasElectricasPost = inventarioVehiculo.LunasElectricasPost;
            this.SistVentilador = inventarioVehiculo.SistVentilador;
            this.Tacometro = inventarioVehiculo.Tacometro;
            this.GataPalanca = inventarioVehiculo.GataPalanca;
            this.LlaveRueda = inventarioVehiculo.LlaveRueda;
            this.EmblMaletera = inventarioVehiculo.EmblMaletera;
            this.Herramientas = inventarioVehiculo.Herramientas;
            this.CajaCd = inventarioVehiculo.CajaCd;
            this.Botiquin = inventarioVehiculo.Botiquin;
            this.Extintor = inventarioVehiculo.Extintor;
            this.Triangulo = inventarioVehiculo.Triangulo;
            this.CableBateria = inventarioVehiculo.CableBateria;
            this.CableRemolque = inventarioVehiculo.CableRemolque;

            this.ObjetosValor = inventarioVehiculo.ObjetosValor;
            this.VehiculoSucioRayaduras = inventarioVehiculo.VehiculoSucioRayaduras;
            this.Asesor = inventarioVehiculo.Asesor;
            this.Observaciones = inventarioVehiculo.Observaciones;
            this.RutaFirma = inventarioVehiculo.RutaFirma;
            this.Coordenadas = (
                from C in inventarioVehiculo.Coordenadas
                where C.Tipo == true
                select new CoordenadasGetViewModel
                    {
                            Id = C.Id,
                            InventarioId = C.InventarioId,
                            Orden = C.Orden,
                            EstadoAutoparte = C.EstadoAutoparte,
                            PointLeft = C.PointLeft,
                            PointRight = C.PointRight,
                            PointBottom = C.PointBottom,
                            PointTop = C.PointTop,
                            Comentario = C.Comentario,
                    }
                ).ToList();
            this.CoordenadasGasolina = (
                from C in inventarioVehiculo.Coordenadas
                where C.Tipo == false
                select new CoordenadasGetViewModel
                {
                    Id = C.Id,
                    InventarioId = C.InventarioId,
                    Orden = C.Orden,
                    EstadoAutoparte = C.EstadoAutoparte,
                    PointLeft = C.PointLeft,
                    PointRight = C.PointRight,
                    PointBottom = C.PointBottom,
                    PointTop = C.PointTop,
                    Comentario = C.Comentario
                }
                ).ToList();
            this.Fotos = (
                    from F in inventarioVehiculo.Fotos
                    select new InventarioFotoGetViewModel
                    {
                        Id = F.Id,
                        Ruta = ReemplazaContrabarras(RutaFisicaFotos + F.InventarioId + "/" + F.Ruta),
                        InventarioId = F.InventarioId
                    }
                ).ToList();  
        }

        public string ReemplazaContrabarras(string v)
        {
            return v.Replace("\\", "/");
        }
    }

    public class CoordenadasGetViewModel
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public decimal PointLeft { get; set; }
        public decimal PointTop { get; set; }
        public decimal PointRight { get; set; }
        public decimal PointBottom { get; set; }
        public int Orden { get; set; }
        public string EstadoAutoparte { get; set; }
        public string Comentario { get; set; }
    }

    public class InventarioFotoGetViewModel
    {
        // Ruta Fisica
        public int Id { get; set; }
        public string Ruta { get; set; }
        public int InventarioId { get; set; }
    }

    public class Circle
    {
        public int Id { get; set; }
        public int InventarioId { get; set; }
        public decimal PointLeft { get; set; }
        public decimal PointTop { get; set; }
        public decimal PointRight { get; set; }
        public decimal PointBottom { get; set; }
        public int Orden { get; set; }
        public string EstadoAutoparte { get; set; }
    }
}