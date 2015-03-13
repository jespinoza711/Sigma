using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Gnecco.Sigma.Core.Shared;

namespace Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades
{
    public class InformeInspeccionFord : InformeInspeccion
    {
        public List<GrupoInformeInspeccion> Grupos { get; private set; }
        public GrupoArticuloMantenimiento GrupoArticuloMantenimiento { get; set; }
        public GrupoDesgasteFreno GrupoDesgasteFreno { get; set; }
        public GrupoDesgasteLlanta GrupoDesgasteLlanta { get; set; }
        public GrupoSistemaComponente GrupoSistemaComponente { get; set; }

        private InformeInspeccionFord()
        {
            Grupos = new List<GrupoInformeInspeccion>();
        }
        public InformeInspeccionFord(string descripcion
                                    ,string nombre
                                    ,GrupoArticuloMantenimiento grupoArticuloMantenimiento
                                    ,GrupoDesgasteFreno grupoDesgasteFreno
                                    ,GrupoDesgasteLlanta grupoDesgasteLlanta
                                    ,GrupoSistemaComponente grupoSistemaComponente)
            :this()
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Grupos.Add(grupoArticuloMantenimiento);
            Grupos.Add(grupoDesgasteLlanta);
            Grupos.Add(grupoDesgasteFreno);
            Grupos.Add(grupoSistemaComponente);
        }

        public void EditarNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void EditarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }

    }
}
