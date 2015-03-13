using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Inventario
{
    public class InventarioVehiculo
    {
        public int Id { get; set; }
        // Propiedades del SAP
        public string NumeroOT { get; set; }
        // Filtro SAP
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
        // Propiedades del Usuario
        public string ManifestoCliente { get; set; } // no default
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
        // Mas Propiedades
        public bool ObjetosValor { get; set; } 
        public bool VehiculoSucioRayaduras { get; set; }
        public string Asesor { get; set; } // no default
        public string Observaciones { get; set; } // no default
        // Objetos para Guardar
        public string RutaFirma { get; set; } // no default
        public List<CoordenadasInventario> Coordenadas { get; set; } // no default
        public List<InventarioFoto> Fotos { get; set; }


        public InventarioVehiculo()
        {
            this.Placa = "Placa Default";
            this.KilometrajeLlegada = "Kilometraje Llegada Default";
            this.FacturarA = "Factura Default";
            this.Ruc = "RUC Default";
            this.Propietario = "Propietario Default";
            this.BoletaFactura = true;
            this.Direccion = "Direccion Default";
            this.TelefonoMovil = "Telefono Default";
            this.CorreoElectronico = "Corre@Default";
            this.Dni = "12345678";
        }

        public void AgregarCoordenadas(decimal pointLeft, decimal pointTop, decimal pointRight, decimal pointBottom, string estadoAutoparte, int orden)
        {
            CoordenadasInventario coordenadas = new CoordenadasInventario();
            coordenadas.PointLeft = pointLeft;
            coordenadas.PointTop = pointTop;
            coordenadas.PointRight = pointRight;
            coordenadas.PointBottom = pointBottom;
            coordenadas.EstadoAutoparte = estadoAutoparte;
            coordenadas.Orden = orden;
            coordenadas.Tipo = true;
            this.Coordenadas.Add(coordenadas);
        }

        public void AgregarCoordenadasGasolina(decimal pointLeft, decimal pointTop, decimal pointRight, decimal pointBottom, string estadoAutoparte, int orden)
        {
            CoordenadasInventario coordenadas = new CoordenadasInventario();
            coordenadas.PointLeft = pointLeft;
            coordenadas.PointTop = pointTop;
            coordenadas.PointRight = pointRight;
            coordenadas.PointBottom = pointBottom;
            coordenadas.EstadoAutoparte = estadoAutoparte;
            coordenadas.Orden = orden;
            coordenadas.Tipo = false;
            this.Coordenadas.Add(coordenadas);
        }
    }
}
