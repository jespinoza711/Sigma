using System;
using System.Collections.Generic;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.ObjetosValor;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class InformeInspeccionFordCompleto : InformeInspeccionCompleto
    {
        public int InformeInspeccionId { get; set; }
        public ClienteFord Cliente { get; private set; }
        public InformacionVehiculoFord InformacionVehiculoFord { get; private set; }
        public string Comentarios { get; private set; }
        public string AsesorServicio { get; private set; }
        public string Tecnico { get; private set; }
        public string RoTag { get; set; }
        public string MesInspeccionEstatal { get; set; }
        public List<DetalleInformeInspeccionFordCompleto> DetalleCompleto { get; set; }
        public InformeInspeccionFord InformeInspeccionFord { get; set; }

        private InformeInspeccionFordCompleto()
        {
            DetalleCompleto = new List<DetalleInformeInspeccionFordCompleto>();
        }
        public InformeInspeccionFordCompleto(ClienteFord cliente
                                            , InformacionVehiculoFord informacionVehiculoFord
                                            , DateTime fecha
                                            , string comentarios
                                            , string asesorServicio
                                            , string tecnico
                                            , string roTag
                                            , string mesInspeccionEstatal)
            :this()
        {
            Cliente = cliente;
            InformacionVehiculoFord = informacionVehiculoFord;
            Comentarios = comentarios;
            AsesorServicio = asesorServicio;
            Tecnico = tecnico;
            Fecha = fecha;
            RoTag = roTag;
            MesInspeccionEstatal = mesInspeccionEstatal;
        }

        public void AgregarDetalle(int detalleInformeInspeccionId,List<ValorOpcion> valores)
        {
            DetalleInformeInspeccionFordCompleto detalleInformeInspeccionCompleto
                = new DetalleInformeInspeccionFordCompleto(
                        detalleInformeInspeccionId
                        , valores
                    );
            DetalleCompleto.Add(detalleInformeInspeccionCompleto);
        }
    }
}
