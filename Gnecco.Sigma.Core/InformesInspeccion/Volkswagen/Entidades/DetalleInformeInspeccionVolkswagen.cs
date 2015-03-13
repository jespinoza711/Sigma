using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Core.Shared.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades
{
    public class DetalleInformeInspeccionVolkswagen : DetalleInformeInspeccion
    {
        private List<Opcion> _opcionesCondicion;
        private List<Opcion> _opcionesInternas;
        private List<Opcion> _opcionesIntervaloKm;

        public int InformeInspeccionId { get; set; }
        public List<Opcion> Opciones { get; set; }
        public List<Opcion> OpcionesCondicion 
        {
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionCondicion && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
            set
            {
                _opcionesCondicion = value;
            }
        }
        public List<Opcion> OpcionesInternas
        {
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionInterna && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
            set
            {
                _opcionesInternas = value;
            }
        }

        public List<Opcion> OpcionesIntervaloKm
        {
            get
            {
                return Opciones.Where(o => o.CodigoAgrupacion == TipoOpcionVolkswagen.OpcionesIntervaloKm && o.IndicadorEstado == EstadoEntidad.Activo).ToList();
            }
            set
            {
                _opcionesIntervaloKm = value;
            }
        }

        public DetalleInformeInspeccionVolkswagen()
        {
            Opciones = new List<Opcion>();

        }

        public void CrearOpciones()
        {
            Opciones.Add(new Opcion { Descripcion = "Ok", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
            Opciones.Add(new Opcion { Descripcion = "No Ok", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
            Opciones.Add(new Opcion { Descripcion = "Corregido", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
            Opciones.Add(new Opcion { Descripcion = "Intervalo en Km", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm });
            //Opciones.Add(new Opcion { Descripcion = "Del. Der.", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
            //Opciones.Add(new Opcion { Descripcion = "Del. Izq.", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
            //Opciones.Add(new Opcion { Descripcion = "Post. Der.", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
            //Opciones.Add(new Opcion { Descripcion = "Post. Izq.", CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
        }

        public void AnularOpciones(int id)
        {
            Opcion op = this.Opciones.Where(o => o.Id == id).First();
            op.Anular();
        }

        public void AnularOpcion()
        {

        }

        public void AgregarOpciones(List<Opcion> opciones)
        {
            this.Opciones = opciones;
        }

        public void AgregrarOpciones(List<Opcion> opcionesCondicion, List<Opcion> opcionesInternas, List<Opcion> opcionesIntervaloKm)
        {
            foreach (var opcion in opcionesCondicion)
            {
                opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion;
                this.Opciones.Add(new Opcion 
                    { 
                        Descripcion = opcion.Descripcion,
                        IndicadorEstado = EstadoEntidad.Activo,
                        CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion
                    });
            }

            foreach (var opcion in opcionesInternas)
            {
                opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna;
                this.Opciones.Add(new Opcion 
                    {
                        Descripcion = opcion.Descripcion,
                        IndicadorEstado = EstadoEntidad.Activo,
                        CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna
                    });
            }

            foreach (var opcion in opcionesIntervaloKm)
            {
                opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm;
                this.Opciones.Add(new Opcion 
                    {
                        Descripcion = opcion.Descripcion,
                        IndicadorEstado = EstadoEntidad.Activo,
                        CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm
                    });
            }  
        }
        
        public void ModificarOpciones(List<Opcion> opcionesCondicion, List<Opcion> opcionesInternas, List<Opcion> opcionesIntervaloKm)
        {
            foreach (var OC in opcionesCondicion)
            {
                if (OC.Id <= 0)
                {
                    this.Opciones.Add(new Opcion { Descripcion = OC.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion });
                }
                else
                {
                    Opcion opcion = this.Opciones.Where(o => o.Id == OC.Id).First();
                    opcion.Descripcion = OC.Descripcion;
                    opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionCondicion;
                }
            }

            foreach (var OI in opcionesInternas)
            {
                if (OI.Id <= 0)
                {
                    this.Opciones.Add(new Opcion { Descripcion = OI.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna });
                }
                else
                {
                    Opcion opcion = this.Opciones.Where(o => o.Id == OI.Id).First();
                    opcion.Descripcion = OI.Descripcion;
                    opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionInterna;
                }
            }

            foreach (var OIK in opcionesIntervaloKm)
            {
                if (OIK.Id <= 0)
                {
                    this.Opciones.Add(new Opcion { Descripcion = OIK.Descripcion, CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm });
                }
                else
                {
                    Opcion opcion = this.Opciones.Where(o => o.Id == OIK.Id).First();
                    opcion.Descripcion = OIK.Descripcion;
                    opcion.CodigoAgrupacion = TipoOpcionVolkswagen.OpcionesIntervaloKm;
                }
            }  
        }
    }

    public class TipoOpcionVolkswagen
    {
        public const int OpcionCondicion = 1;
        public const int OpcionInterna = 2;
        public const int OpcionesIntervaloKm = 3;
    }
}
