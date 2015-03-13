using Gnecco.Sigma.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades
{
    public class InformeInspeccionVolkswagenCompleto : InformeInspeccionCompleto
    {
        public int InformeInspeccionId { get; set; }
        public string Comentarios { get; set; }
        public string NombreTecnico { get; set; }
        public InformacionVehiculoVolkswagen InformacionVehiculo { get; set; }
        public List<DetalleInformeInspeccionVolkswagenCompleto> DetallesInformeInspeccionVolkswagenCompleto { get; set; }

        private InformeInspeccionVolkswagenCompleto()
        {

        }

        public InformeInspeccionVolkswagenCompleto(InformacionVehiculoVolkswagen informacionVehiculo, 
            string comentarios, string nombreTecnico, int informeInspeccionId)
            :base()
        {
            DetallesInformeInspeccionVolkswagenCompleto = new List<DetalleInformeInspeccionVolkswagenCompleto>();
            InformacionVehiculo = informacionVehiculo;
            Comentarios = comentarios;
            NombreTecnico = nombreTecnico;
            InformeInspeccionId = informeInspeccionId;
        }

        public void AgregarDetalle(int detalleInformeInspeccionId, 
            List<ValorOpcion> valoresOpcionCondicion, List<ValorOpcion> valoresOpcionIntervaloKm, 
            List<ValorOpcion> valoresOpcionInternas)
        {
            DetalleInformeInspeccionVolkswagenCompleto detalle = new DetalleInformeInspeccionVolkswagenCompleto(
                detalleInformeInspeccionId, valoresOpcionCondicion, valoresOpcionIntervaloKm, valoresOpcionInternas);
            
            DetallesInformeInspeccionVolkswagenCompleto.Add(detalle);
        }
    }

    public class InformacionVehiculoVolkswagen
    {
        public string Orden { get; private set; }
        public string Placa { get; private set; }
        public string Vin { get; private set; }
        public string Km { get; private set; }
        public string LetraDistribucionMotor { get; private set; }
        public string IntervaloKilometros { get; set; }
        public string Cliente { get; set; }

        public InformacionVehiculoVolkswagen()
        {

        }

        public InformacionVehiculoVolkswagen(string orden, string placa, string vin, string km, string letraDistribucionMotor)
        {
            Orden = orden;
            Placa = placa;
            Vin = vin;
            Km = km;
            LetraDistribucionMotor = letraDistribucionMotor;
        }

        public InformacionVehiculoVolkswagen(string orden, string placa, string vin, string km, string letraDistribucionMotor, string intervaloKilometros)
        {
            Orden = orden;
            Placa = placa;
            Vin = vin;
            Km = km;
            LetraDistribucionMotor = letraDistribucionMotor;
            IntervaloKilometros = intervaloKilometros;
        }

        public InformacionVehiculoVolkswagen(string orden, string placa, string vin, string km, string letraDistribucionMotor, string intervaloKilometros, string cliente)
        {
            Orden = orden;
            Placa = placa;
            Vin = vin;
            Km = km;
            LetraDistribucionMotor = letraDistribucionMotor;
            IntervaloKilometros = intervaloKilometros;
            Cliente = cliente;
        }
    }
}
