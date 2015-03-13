using System;
using System.Collections.Generic;
using System.Linq;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using System.Data.Entity;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios
{
    public class InformeInspeccionFordRepositorio : IInformeInspeccionFordRepositorio
    {
        private FordContext _fordContext;

        public InformeInspeccionFordRepositorio(FordContext fordContext)
        {
            _fordContext = fordContext;
        }

        public InformeInspeccionFordRepositorio()
        {
            _fordContext = new FordContext();
        }

        public void Guardar(InformeInspeccionFord informeInspeccionFord)
        {
            int codigoTemporal = 0;

            foreach (var grupo in informeInspeccionFord.Grupos)
            {
                grupo.InformeInspeccionId = informeInspeccionFord.Id;
                if (grupo.Id <= 0)
                {
                    grupo.Id = --codigoTemporal;
                }
                if (grupo is GrupoDesgasteFreno)
                {
                    codigoTemporal = GuardarGrupoDesgasteFreno(codigoTemporal, grupo);
                }
                else if (grupo is GrupoArticuloMantenimiento)
                {
                    codigoTemporal = GuardarGrupoArticuloMantenimiento(codigoTemporal, grupo);
                }
                else if (grupo is GrupoSistemaComponente)
                {
                    codigoTemporal = GuardarGrupoSistemaComponente(codigoTemporal, grupo);
                }
                else if (grupo is GrupoDesgasteLlanta)
                {
                    codigoTemporal = GuardarDesgasteLlanta(codigoTemporal, grupo);
                }
            }

            if(informeInspeccionFord.Id <= 0)
            {
                _fordContext.InformeInspeccionFord.Attach(informeInspeccionFord);
            }

            _fordContext.SaveChanges();
        }

        private int GuardarDesgasteLlanta(int codigoTemporal, Core.Shared.GrupoInformeInspeccion grupo)
        {
            foreach (var detalle in (grupo as GrupoDesgasteLlanta).Detalle)
            {
                if (detalle.Id <= 0)
                {
                    detalle.Id = --codigoTemporal;
                    detalle.GrupoInformeInspeccionId = grupo.Id;
                }

                foreach (var opcion in detalle.Opciones)
                {
                    if (opcion.Id <= 0)
                    {
                        opcion.Id = --codigoTemporal;
                        opcion.DetalleInformeInspeccionId = detalle.Id;
                    }
                }
            }
            return codigoTemporal;
        }

        private int GuardarGrupoSistemaComponente(int codigoTemporal, Core.Shared.GrupoInformeInspeccion grupo)
        {
            foreach (var subGrupo in (grupo as GrupoSistemaComponente).SubGrupos)
            {
                if (subGrupo.Id <= 0)
                {
                    subGrupo.Id = --codigoTemporal;
                    subGrupo.GrupoInformeInspeccionId = grupo.Id;
                }
                foreach (var detalle in subGrupo.Detalle)
                {
                    if (detalle.Id <= 0)
                    {
                        detalle.GrupoInformeInspeccionId = subGrupo.Id;
                        detalle.Id = --codigoTemporal;
                    }
                    foreach (var opcion in detalle.Opciones)
                    {
                        if (opcion.Id <= 0)
                        {
                            opcion.DetalleInformeInspeccionId = detalle.Id;
                            opcion.Id = --codigoTemporal;
                        }
                    }
                }

            }
            return codigoTemporal;
        }

        private int GuardarGrupoArticuloMantenimiento(int codigoTemporal, Core.Shared.GrupoInformeInspeccion grupo)
        {
            foreach (var detalle in (grupo as GrupoArticuloMantenimiento).Detalle)
            {
                if (detalle.Id <= 0)
                {
                    detalle.Id = --codigoTemporal;
                    detalle.GrupoInformeInspeccionId = grupo.Id;
                }

                foreach (var opcion in detalle.Opciones)
                {
                    if (opcion.Id <= 0)
                    {
                        opcion.Id = --codigoTemporal;
                        opcion.DetalleInformeInspeccionId = detalle.Id;
                    }
                }
            }
            return codigoTemporal;
        }

        private int GuardarGrupoDesgasteFreno(int codigoTemporal, Core.Shared.GrupoInformeInspeccion grupo)
        {
            foreach (var subGrupo in (grupo as GrupoDesgasteFreno).SubGrupos)
            {
                if (subGrupo.Id <= 0)
                {
                    subGrupo.GrupoInformeInspeccionId = grupo.Id;
                    subGrupo.Id = --codigoTemporal;
                }

                foreach (var detalle in subGrupo.Detalle)
                {
                    if (detalle.Id <= 0)
                    {
                        detalle.Id = --codigoTemporal;
                        detalle.GrupoInformeInspeccionId = subGrupo.Id;
                    }
                    foreach (var opcion in detalle.Opciones)
                    {
                        if (opcion.Id <= 0)
                        {
                            opcion.DetalleInformeInspeccionId = detalle.Id;
                            opcion.Id = --codigoTemporal;
                        }
                    }
                }
            }
            return codigoTemporal;
        }

        public List<InformeInspeccionFord> BuscarInformesInspeccionFord()
        {
            return _fordContext.InformeInspeccionFord.ToList();
        }

        public InformeInspeccionFord Buscar(int id)
        {
            InformeInspeccionFord informeInspeccionFord =
                _fordContext.InformeInspeccionFord
                    .First(i => i.Id == id);

            informeInspeccionFord.GrupoArticuloMantenimiento =
                _fordContext.GrupoArticuloMantenimiento
                    .Include("Detalle.Opciones")
                    .First(g => g.InformeInspeccionId == id);

            informeInspeccionFord.GrupoDesgasteFreno =
                _fordContext.GrupoDesgasteFreno
                    .Include("SubGrupos.Detalle.Opciones")
                    .First(g => g.InformeInspeccionId == id);

            informeInspeccionFord.GrupoDesgasteLlanta =
                _fordContext.GrupoDesgasteLlanta
                    .Include("Detalle.Opciones")
                    .First(g => g.InformeInspeccionId == id);

            informeInspeccionFord.GrupoSistemaComponente =
                _fordContext.GrupoSistemaComponente
                    .Include("SubGrupos.Detalle.Opciones")
                    .First(g => g.InformeInspeccionId == id);

            return informeInspeccionFord;
        }

        public InformeInspeccionFordCompleto BuscarInformeInspeccionCompleto(int id)
        {
            InformeInspeccionFordCompleto informeInspeccionFordCompleto =
                _fordContext.InformeInspeccionFordCompleto.Include("DetalleCompleto.Valores")
                    .First(i => i.Id == id);

            InformeInspeccionFord informeInspeccionFord = Buscar(informeInspeccionFordCompleto.InformeInspeccionId);

            return informeInspeccionFordCompleto;
        }
    }
}
