using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.Inventario
{
    public class InventarioPostViewModel
    {
        public string OT { get; set; }
        #region DatosInventario
        // Propiedades del SAP
        public string FECHARECEPCION { get; set; }
        public string HORARECEPCION { get; set; }
        public string PLACA { get; set; }
        public string KMLLEGADA { get; set; }
        public string FECHAPROMETIDA { get; set; }
        public string HORAPROMETIDA { get; set; }
        public string FACTURARA { get; set; }
        public string DNIRUC { get; set; }
        public string CLIENTE { get; set; }
        public bool BOLETAFACTURA { get; set; } // True Boleta, False Factura
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
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
        public string Base64Firma { get; set; }
        #endregion
        #region Coordenadas
        public List<CoordenadasPostViewModel> Coordenadas { get; set; }
        public List<CoordenadasPostViewModel> CoordenadasGasolina { get; set; }
        #endregion
    }

    public class CoordenadasPostViewModel
    {
        public decimal PointLeft { get; set; }
        public decimal PointTop { get; set; }
        public decimal PointRight { get; set; }
        public decimal PointBottom { get; set; }
        public int Orden { get; set; }
        public string EstadoAutoparte { get; set; } // Pequeña descripcion
        public string Comentario { get; set; }
    }
}