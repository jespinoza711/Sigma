using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.Factories.InformesInspeccion.Volkswagen
{
    public class InformeInspeccionVolkswagenFactory
    {
        public InformeInspeccionVolkswagen Crear(InformeInspeccionPostViewModel informeInspeccionPostViewModel)
        {
            InformeInspeccionVolkswagen informeInspeccionVolkswagen = new InformeInspeccionVolkswagen
                (
                informeInspeccionPostViewModel.Descripcion,
                informeInspeccionPostViewModel.Nombre
                );

            List<DetalleInformeInspeccionVolkswagen> detallesInformeInspeccion = new List<DetalleInformeInspeccionVolkswagen>();
                        
            foreach (var detalle in informeInspeccionPostViewModel.Detalles)
            {
                DetalleInformeInspeccionVolkswagen detalleInformInspeccion = new DetalleInformeInspeccionVolkswagen();
                detalleInformInspeccion.Descripcion = detalle.Descripcion;

                List<Opcion> opcionesCondicion = new List<Opcion>();
                if (detalle.OpcionesCondicion != null) 
                {
                    foreach (var opcion in detalle.OpcionesCondicion)
                    {
                        opcionesCondicion.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion
                        });
                    }
                }
               
                List<Opcion> opcionesIntervaloKm = new List<Opcion>();
                if (detalle.OpcionesIntervaloKm != null)
                {
                    foreach (var opcion in detalle.OpcionesIntervaloKm)
                    {
                        opcionesIntervaloKm.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm
                        });
                    }
                }
                
                List<Opcion> opcionesInterna = new List<Opcion>();
                if (detalle.OpcionesInternas != null) 
                {
                    foreach (var opcion in detalle.OpcionesInternas)
                    {
                        opcionesInterna.Add(new Opcion
                        {
                            Descripcion = opcion.Descripcion,
                            CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna
                        });
                    }
                }

                //detalleInformInspeccion.OpcionesCondicion = opcionesCondicion;
                //detalleInformInspeccion.OpcionesInternas = opcionesInterna;
                //detalleInformInspeccion.OpcionesIntervaloKm = opcionesIntervaloKm;
                detalleInformInspeccion.AgregarOpciones(opcionesCondicion.Concat(opcionesInterna).Concat(opcionesIntervaloKm).ToList());
                detallesInformeInspeccion.Add(detalleInformInspeccion);
            }

            informeInspeccionVolkswagen.Detalles = detallesInformeInspeccion;
                 
            return informeInspeccionVolkswagen;
        }
    }
}