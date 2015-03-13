using Gnecco.Sigma.Core.Inventario;
using Gnecco.Sigma.Core.Inventario.Repositorios;
using Gnecco.Sigma.Datos.Inventario.Repositorios;
using Gnecco.Sigma.Web.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InventarioController : ApiController
    {
        IInventarioRepositorio _inventarioRepositorio;

        public InventarioController()
        {
            _inventarioRepositorio = new InventarioRepositorio();
        }

        [HttpGet]
        public IEnumerable<InventarioListadoViewModel> Get()
        {
            List<InventarioVehiculo> inventarios = _inventarioRepositorio.ListarInventarioVehiculo();
            InventarioListadoViewModelHanlder vmHandler = new InventarioListadoViewModelHanlder();
            vmHandler.MapearDesde(inventarios);
            return vmHandler.Inventarios;
        }

        [HttpGet]
        public object Get(int id)
        {
            InventarioVehiculo inventario = _inventarioRepositorio.BuscarPorId(id);
            InventarioGetViewModel vm = new InventarioGetViewModel();
            vm.MapearDesde(inventario);
            return vm;
        }
        
        [HttpPost]
        public object Post([FromBody]InventarioPostViewModel vm)
        {
            InventarioVehiculo inventarioVehiculo = new InventarioVehiculo();
            string mensajeTransaccion = "Ok!";

            try
            {
                //// Ruta fisica
                //var filePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                //// Ruta de la Firma
                //string RutaFirma = filePath + vm.Dni.ToString() +  vm.Propietario.ToString() + ".png";
                //// Convercion de base64 a string
                //byte[] data = Convert.FromBase64String(vm.Base64Firma);
                //// Creacion de la imagen 
                //using (var stream = new MemoryStream(data, 0, data.Length))
                //{
                //    Image image = Image.FromStream(stream);
                //    image.Save(RutaFirma);
                //}

                #region DatosSAP
                inventarioVehiculo.NumeroOT = vm.OT;
                inventarioVehiculo.FechaRecepcion = vm.FECHARECEPCION;
                inventarioVehiculo.HoraRecepcion = vm.HORARECEPCION;
                inventarioVehiculo.Placa = vm.PLACA;
                inventarioVehiculo.KilometrajeLlegada = vm.KMLLEGADA;
                inventarioVehiculo.FechaPrometida = vm.FECHAPROMETIDA;
                inventarioVehiculo.HoraPrometida = vm.HORAPROMETIDA;
                inventarioVehiculo.FacturarA = vm.FACTURARA;
                inventarioVehiculo.Ruc = vm.DNIRUC;
                inventarioVehiculo.Propietario = vm.CLIENTE;
                inventarioVehiculo.BoletaFactura = vm.BOLETAFACTURA;
                inventarioVehiculo.Direccion = vm.DIRECCION;
                inventarioVehiculo.TelefonoMovil = vm.TELEFONO;
                inventarioVehiculo.CorreoElectronico = vm.EMAIL;
                inventarioVehiculo.Dni = vm.DNIRUC;
                #endregion
                inventarioVehiculo.ManifestoCliente = vm.ManifestoCliente;
                #region InventarioRecepcion
                inventarioVehiculo.Cenicero = vm.Cenicero;
                inventarioVehiculo.Encendedor = vm.Encendedor;
                inventarioVehiculo.Radio = vm.Radio;
                inventarioVehiculo.MascaraRadio = vm.MascaraRadio;
                inventarioVehiculo.Antena = vm.Antena;
                inventarioVehiculo.TarjetaPropiedad = vm.TarjetaPropiedad;
                inventarioVehiculo.Soat = vm.Soat;
                inventarioVehiculo.SeguroRueda = vm.SeguroRueda;
                inventarioVehiculo.VasosRueda = vm.VasosRueda;
                inventarioVehiculo.LucesBajas = vm.LucesBajas;
                inventarioVehiculo.TapaSol = vm.TapaSol;
                inventarioVehiculo.PlumillasDuchas = vm.PlumillasDuchas;
                inventarioVehiculo.Escapines = vm.Escapines;
                inventarioVehiculo.EmblMascara = vm.EmblMascara;
                inventarioVehiculo.TapaAceite = vm.TapaAceite;
                inventarioVehiculo.TapaTanqueComb = vm.TapaTanqueComb;
                inventarioVehiculo.TapaRadiador = vm.TapaRadiador;
                inventarioVehiculo.TapaDepRefrg = vm.TapaDepRefrg;
                inventarioVehiculo.TapaDepLiqFren = vm.TapaDepLiqFren;
                inventarioVehiculo.LlantaRepuesto = vm.LlantaRepuesto;
                inventarioVehiculo.LucesAltas = vm.LucesAltas;
                inventarioVehiculo.Neblineros = vm.Neblineros;
                inventarioVehiculo.Claxon = vm.Claxon;
                inventarioVehiculo.Espejos = vm.Espejos;
                inventarioVehiculo.PisosJebeAlfombra = vm.PisosJebeAlfombra;
                inventarioVehiculo.CorteCorriente = vm.CorteCorriente;
                inventarioVehiculo.LunasElectricasDelt = vm.LunasElectricasDelt;
                inventarioVehiculo.LunasElectricasPost = vm.LunasElectricasPost;
                inventarioVehiculo.SistVentilador = vm.SistVentilador;
                inventarioVehiculo.Tacometro = vm.Tacometro;
                inventarioVehiculo.GataPalanca = vm.GataPalanca;
                inventarioVehiculo.LlaveRueda = vm.LlaveRueda;
                inventarioVehiculo.EmblMaletera = vm.EmblMaletera;
                inventarioVehiculo.Herramientas = vm.Herramientas;
                inventarioVehiculo.CajaCd = vm.CajaCd;
                inventarioVehiculo.Botiquin = vm.Botiquin;
                inventarioVehiculo.Extintor = vm.Extintor;
                inventarioVehiculo.Triangulo = vm.Triangulo;
                inventarioVehiculo.CableBateria = vm.CableBateria;
                inventarioVehiculo.CableRemolque = vm.CableRemolque;
                #endregion
                inventarioVehiculo.ObjetosValor = vm.ObjetosValor;
                inventarioVehiculo.VehiculoSucioRayaduras = vm.VehiculoSucioRayaduras;
                inventarioVehiculo.Asesor = vm.Asesor;
                inventarioVehiculo.Observaciones = vm.Observaciones;
                inventarioVehiculo.RutaFirma = vm.Base64Firma;

                List<CoordenadasInventario> grupoCoordenadas = new List<CoordenadasInventario>();

                if (vm.Coordenadas != null)
                {
                    foreach (var C in vm.Coordenadas)
                    {
                        //inventarioVehiculo.AgregarCoordenadas(C.PointLeft, C.PointTop, C.PointRight, C.PointBottom, C.EstadoAutoparte, C.Orden);
                        CoordenadasInventario coordenadas = new CoordenadasInventario();
                        coordenadas.PointLeft = C.PointLeft;
                        coordenadas.PointTop = C.PointTop;
                        coordenadas.PointRight = C.PointRight;
                        coordenadas.PointBottom = C.PointBottom;
                        //coordenadas.PointLeft = C.Circle.PointLeft;
                        //coordenadas.PointTop = C.Circle.PointTop;
                        //coordenadas.PointRight = C.Circle.PointRight;
                        //coordenadas.PointBottom = C.Circle.PointBottom;
                        coordenadas.EstadoAutoparte = C.EstadoAutoparte;
                        coordenadas.Orden = C.Orden;
                        coordenadas.Comentario = C.Comentario;
                        coordenadas.Tipo = true;
                        grupoCoordenadas.Add(coordenadas);
                    }
                }
                else
                {
                    mensajeTransaccion = "Sin Coordenadas";
                }

                if (vm.CoordenadasGasolina != null)
                {
                    foreach (var C in vm.CoordenadasGasolina)
                    {
                        //inventarioVehiculo.AgregarCoordenadas(C.PointLeft, C.PointTop, C.PointRight, C.PointBottom, C.EstadoAutoparte, C.Orden);
                        CoordenadasInventario coordenadas = new CoordenadasInventario();
                        coordenadas.PointLeft = C.PointLeft;
                        coordenadas.PointTop = C.PointTop;
                        coordenadas.PointRight = C.PointRight;
                        coordenadas.PointBottom = C.PointBottom;
                        //coordenadas.PointLeft = C.Circle.PointLeft;
                        //coordenadas.PointTop = C.Circle.PointTop;
                        //coordenadas.PointRight = C.Circle.PointRight;
                        //coordenadas.PointBottom = C.Circle.PointBottom;
                        coordenadas.EstadoAutoparte = C.EstadoAutoparte;
                        coordenadas.Orden = C.Orden;
                        coordenadas.Comentario = C.Comentario;
                        coordenadas.Tipo = false;
                        grupoCoordenadas.Add(coordenadas);
                    }
                }
                else
                {
                    mensajeTransaccion = "Sin Coordenadas Gasolina";
                }

                inventarioVehiculo.Coordenadas = grupoCoordenadas;
                _inventarioRepositorio.Guardar(inventarioVehiculo);
            }
            catch (Exception e)
            {
                return new
                {
                    Status = 500,
                    Mensaje = "Error!",
                    Error = e.Message
                };
            }

            return new 
            {
                Status = 200,
                Mensaje = mensajeTransaccion
            };
        }
    }
}
