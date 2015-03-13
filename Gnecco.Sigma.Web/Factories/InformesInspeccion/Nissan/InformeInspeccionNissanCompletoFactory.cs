using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.Factories.InformesInspeccion.Nissan
{
    public class InformeInspeccionNissanCompletoFactory
    {
        public InformeInspeccionNissanCompleto Crear(InformeInspeccionCompletoPostNissanViewModel viewModel)
        {
            InformeInspeccionNissanCompleto informeInspeccionNissanCompleto = new InformeInspeccionNissanCompleto();            
            List<GrupoInformeInspeccionNissanCompleto> gruposInformeInspeccion = new List<GrupoInformeInspeccionNissanCompleto>();

            foreach (var grupo in viewModel.GruposEspeciales)
            {
                GrupoInformeInspeccionNissanCompleto grupoInformeInspeccion = new GrupoInformeInspeccionNissanCompleto();
                List<DetalleInformeInspeccionNissanCompleto> detallesInformeInspeccionNissanCompleto = new List<DetalleInformeInspeccionNissanCompleto>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissanCompleto detalleInformeInspeccionNissanCompleto = new DetalleInformeInspeccionNissanCompleto();

                    List<ValorOpcion> valorOpcionesCheckCalidad = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesCheckRevision = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesMedicion = new List<ValorOpcion>();

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckCalidad)
                        {
                            valorOpcionesCheckCalidad.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckRevision)
                        {
                            valorOpcionesCheckRevision.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var valor in detalle.OpcionesMedicion)
                        {
                            valorOpcionesMedicion.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    detalleInformeInspeccionNissanCompleto.AgregarDetalleValores(
                        detalle.Id,
                        valorOpcionesCheckCalidad.Concat(valorOpcionesCheckRevision).Concat(valorOpcionesMedicion).ToList());
                    // Añadimos a la coleccion de detalles
                    detallesInformeInspeccionNissanCompleto.Add(detalleInformeInspeccionNissanCompleto);
                }

                grupoInformeInspeccion.GrupoInformeInspeccionId = grupo.Id;
                grupoInformeInspeccion.DetallesInformeInspeccionNissanCompleto = detallesInformeInspeccionNissanCompleto;
                grupoInformeInspeccion.Tipo = "Nissan";
                // Añadimos a la coleccion de grupos
                gruposInformeInspeccion.Add(grupoInformeInspeccion);
            }

            foreach (var grupo in viewModel.GruposCalidad)
            {
                GrupoInformeInspeccionNissanCompleto grupoInformeInspeccion = new GrupoInformeInspeccionNissanCompleto();
                List<DetalleInformeInspeccionNissanCompleto> detallesInformeInspeccionNissanCompleto = new List<DetalleInformeInspeccionNissanCompleto>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissanCompleto detalleInformeInspeccionNissanCompleto = new DetalleInformeInspeccionNissanCompleto();

                    List<ValorOpcion> valorOpcionesCheckCalidad = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesCheckRevision = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesMedicion = new List<ValorOpcion>();

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckCalidad)
                        {
                            valorOpcionesCheckCalidad.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckRevision)
                        {
                            valorOpcionesCheckRevision.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var valor in detalle.OpcionesMedicion)
                        {
                            valorOpcionesMedicion.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    detalleInformeInspeccionNissanCompleto.AgregarDetalleValores(
                        detalle.Id,
                        valorOpcionesCheckCalidad.Concat(valorOpcionesCheckRevision).Concat(valorOpcionesMedicion).ToList());
                    // Añadimos a la coleccion de detalles
                    detallesInformeInspeccionNissanCompleto.Add(detalleInformeInspeccionNissanCompleto);
                }

                grupoInformeInspeccion.GrupoInformeInspeccionId = grupo.Id;
                grupoInformeInspeccion.DetallesInformeInspeccionNissanCompleto = detallesInformeInspeccionNissanCompleto;
                grupoInformeInspeccion.Tipo = "Nissan";
                // Añadimos a la coleccion de grupos
                gruposInformeInspeccion.Add(grupoInformeInspeccion);
            }

            foreach (var grupo in viewModel.Grupos)
            {
                GrupoInformeInspeccionNissanCompleto grupoInformeInspeccion = new GrupoInformeInspeccionNissanCompleto();
                List<DetalleInformeInspeccionNissanCompleto> detallesInformeInspeccionNissanCompleto = new List<DetalleInformeInspeccionNissanCompleto>();

                foreach (var detalle in grupo.Detalles)
                {
                    DetalleInformeInspeccionNissanCompleto detalleInformeInspeccionNissanCompleto = new DetalleInformeInspeccionNissanCompleto();

                    List<ValorOpcion> valorOpcionesCheckCalidad = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesCheckRevision = new List<ValorOpcion>();
                    List<ValorOpcion> valorOpcionesMedicion = new List<ValorOpcion>();

                    if (detalle.OpcionesCheckCalidad != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckCalidad)
                        {
                            valorOpcionesCheckCalidad.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesCheckRevision != null)
                    {
                        foreach (var valor in detalle.OpcionesCheckRevision)
                        {
                            valorOpcionesCheckRevision.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    if (detalle.OpcionesMedicion != null)
                    {
                        foreach (var valor in detalle.OpcionesMedicion)
                        {
                            valorOpcionesMedicion.Add(new ValorOpcion
                            {
                                OpcionId = valor.Id,
                                Valor = valor.Valor
                            });
                        }
                    }

                    detalleInformeInspeccionNissanCompleto.AgregarDetalleValores(
                        detalle.Id, 
                        valorOpcionesCheckCalidad.Concat(valorOpcionesCheckRevision).Concat(valorOpcionesMedicion).ToList());
                    // Añadimos a la coleccion de detalles
                    detallesInformeInspeccionNissanCompleto.Add(detalleInformeInspeccionNissanCompleto);
                }

                grupoInformeInspeccion.GrupoInformeInspeccionId = grupo.Id;
                grupoInformeInspeccion.DetallesInformeInspeccionNissanCompleto = detallesInformeInspeccionNissanCompleto;                
                grupoInformeInspeccion.Tipo = "Nissan";
                // Añadimos a la coleccion de grupos
                gruposInformeInspeccion.Add(grupoInformeInspeccion);
            }

            informeInspeccionNissanCompleto.InformeInspeccionId = viewModel.InformeInspeccionId;
            informeInspeccionNissanCompleto.Cliente = viewModel.CLIENTE;
            informeInspeccionNissanCompleto.Correctivo = viewModel.CORRECTIVO;
            informeInspeccionNissanCompleto.Kms = viewModel.KM;
            informeInspeccionNissanCompleto.NumeroOT = viewModel.OT;
            informeInspeccionNissanCompleto.Placa = viewModel.PLACA;
            informeInspeccionNissanCompleto.Preventivo = viewModel.PREVENTIVO;
            informeInspeccionNissanCompleto.ResultadosMantenimiento = viewModel.ResultadosMantenimiento;
            informeInspeccionNissanCompleto.Tecnico = viewModel.Tecnico;
            informeInspeccionNissanCompleto.GruposInformeInspeccionNissanCompleto = gruposInformeInspeccion;

            return informeInspeccionNissanCompleto;
        }
    }
}