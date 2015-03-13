using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.Factories.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionVolkswagenCompletoFactory
    {
        public  InformeInspeccionVolkswagenCompletoFactory()
        {

        }

        public InformeInspeccionVolkswagenCompleto Crear(InformeInspeccionCompletoPostViewModel informeInspeccionCompletoPostViewModel)
        {
            InformacionVehiculoVolkswagen informacionVehiculoVolkswagen = new InformacionVehiculoVolkswagen
                (informeInspeccionCompletoPostViewModel.OT
                , informeInspeccionCompletoPostViewModel.PLACA
                , informeInspeccionCompletoPostViewModel.VIN
                , informeInspeccionCompletoPostViewModel.KMS
                , informeInspeccionCompletoPostViewModel.LETRADISTRIBUCIONMOTOR
                , informeInspeccionCompletoPostViewModel.IntervaloKilometros
                , informeInspeccionCompletoPostViewModel.CLIENTE);

            InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto = new InformeInspeccionVolkswagenCompleto
                (informacionVehiculoVolkswagen
                , informeInspeccionCompletoPostViewModel.Comentarios
                , informeInspeccionCompletoPostViewModel.NombreTecnico
                , informeInspeccionCompletoPostViewModel.InformeInspeccionId);

            foreach (var detalle in informeInspeccionCompletoPostViewModel.Detalles)
            {
                List<ValorOpcion> valoresOpcionesCondicion = new List<ValorOpcion>();
                foreach (var opcion in detalle.OpcionesCondicion)
                {
                    valoresOpcionesCondicion.Add(new ValorOpcion
                    {
                        OpcionId = opcion.Id,
                        Valor = opcion.Valor
                    });
                }


                List<ValorOpcion> valoresOpcionesInternas = new List<ValorOpcion>();
                foreach (var opcion in detalle.OpcionesInternas)
                {
                    valoresOpcionesInternas.Add(new ValorOpcion
                    {
                        OpcionId = opcion.Id,
                        Valor = opcion.Valor
                    });
                }

                List<ValorOpcion> valoresOpcionesIntervaloKm = new List<ValorOpcion>();
                foreach (var opcion in detalle.OpcionesIntervaloKm)
                {
                    valoresOpcionesIntervaloKm.Add(new ValorOpcion
                    {
                        OpcionId = opcion.Id,
                        Valor = opcion.Valor
                    });
                }
                informeInspeccionVolkswagenCompleto.AgregarDetalle(detalle.Id, valoresOpcionesCondicion, valoresOpcionesIntervaloKm, valoresOpcionesInternas);
            }
            return informeInspeccionVolkswagenCompleto;
        }
    }
}