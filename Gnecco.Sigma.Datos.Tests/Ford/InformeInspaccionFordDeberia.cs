using System.Diagnostics;
using System.Linq.Expressions;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios;
using NUnit.Framework;

namespace Gnecco.Sigma.Datos.Tests.Ford
{
    
    public class InformeInspaccionFordDeberia
    {
        private IInformeInspeccionFordRepositorio _informeInspeccionFordRepositorio;
        public int IdGeneradoGuardar = 0;

        [SetUp]
        public void InicializarTest()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }

        [Test]
        public void a_GuardarInformeInspeccionFordCompleto()
        {
            _informeInspeccionFordRepositorio = new InformeInspeccionFordRepositorio();
            int cantidadInformesInspeccionFord = _informeInspeccionFordRepositorio.BuscarInformesInspeccionFord().Count;

            GrupoArticuloMantenimiento grupoArticuloMantenimiento = new GrupoArticuloMantenimiento();
            grupoArticuloMantenimiento.AgregarModificarDetalle(0,"Detalle Grupo Articulo Mantenimiento");

            GrupoDesgasteFreno grupoDesgasteFreno = new GrupoDesgasteFreno();
            SubGrupoDesgasteFreno subGrupoDesgasteFreno = new SubGrupoDesgasteFreno("SubGrupo del Grupo Desgaste Freno");
            subGrupoDesgasteFreno.AgregarModificarDetalle(0,"Detalle del SubGrupo del Grupo Desgaste Freno");
            grupoDesgasteFreno.AgregarSubGrupo(subGrupoDesgasteFreno);

            GrupoDesgasteLlanta grupoDesgasteLlanta = new GrupoDesgasteLlanta();
            grupoDesgasteLlanta.AgregarModificarDetalle(0,"Detalle Grupo Desgaste Llanta");

            GrupoSistemaComponente grupoSistemaComponente = new GrupoSistemaComponente();
            SubGrupoSistemaComponente subGrupoSistemaComponente = new SubGrupoSistemaComponente("SubGrupo del Grupo Sistema Componente");
            subGrupoSistemaComponente.AgregarModificarDetalle(0,"Detalle Grupo Sistema Componente");
            grupoSistemaComponente.AgregarSubGrupo(subGrupoSistemaComponente);

            InformeInspeccionFord informeInspeccionFord 
                = new InformeInspeccionFord
                    (
                        "Informe Inspeccion Ford Test"
                        ,"Nombre Informe Inspeccion Ford Test"
                        ,grupoArticuloMantenimiento
                        ,grupoDesgasteFreno
                        ,grupoDesgasteLlanta
                        ,grupoSistemaComponente
                    );
            _informeInspeccionFordRepositorio.Guardar(informeInspeccionFord);

            int nuevaCantidadInformesInspeccionFord = _informeInspeccionFordRepositorio.BuscarInformesInspeccionFord().Count;

            IdGeneradoGuardar = informeInspeccionFord.Id;

            Assert.That(nuevaCantidadInformesInspeccionFord, Is.EqualTo(++cantidadInformesInspeccionFord));
        }

        [Test]
        public void b_ObtenerInformeInspeccionFordPorId()
        {
            InformeInspeccionFord informeInspeccionFord = _informeInspeccionFordRepositorio.Buscar(IdGeneradoGuardar);
            Assert.That(informeInspeccionFord, Is.Not.Null);
            Assert.That(informeInspeccionFord.GrupoArticuloMantenimiento, Is.Not.Null);
            Assert.That(informeInspeccionFord.GrupoArticuloMantenimiento.Detalle.Count
                        , Is.EqualTo(1));

            Assert.That(informeInspeccionFord.GrupoDesgasteFreno, Is.Not.Null);
            Assert.That(informeInspeccionFord.GrupoDesgasteFreno.SubGrupos.Count
                        , Is.EqualTo(1));
            Assert.That(informeInspeccionFord.GrupoDesgasteFreno.SubGrupos[0].Detalle.Count
                        , Is.EqualTo(1));

            Assert.That(informeInspeccionFord.GrupoDesgasteLlanta, Is.Not.Null);
            Assert.That(informeInspeccionFord.GrupoDesgasteLlanta.Detalle.Count
                        , Is.EqualTo(1));

            Assert.That(informeInspeccionFord.GrupoSistemaComponente, Is.Not.Null);
            Assert.That(informeInspeccionFord.GrupoSistemaComponente.SubGrupos.Count
                        , Is.EqualTo(1));
            Assert.That(informeInspeccionFord.GrupoSistemaComponente.SubGrupos[0].Detalle.Count
                        , Is.EqualTo(1));
        }

        [Test]
        public void c_ModificarInformeInspeccionFord()
        {
            InformeInspeccionFord informeInspeccionFord = _informeInspeccionFordRepositorio.Buscar(IdGeneradoGuardar);
            informeInspeccionFord.GrupoArticuloMantenimiento.AgregarModificarDetalle(0,"Detalle Grupo Articulo Mantenimiento 2");
            _informeInspeccionFordRepositorio.Guardar(informeInspeccionFord);

            InformeInspeccionFord informeInspeccionFordModificado = _informeInspeccionFordRepositorio.Buscar(IdGeneradoGuardar);
            Assert.That(informeInspeccionFordModificado, Is.Not.Null);
            Assert.That(informeInspeccionFordModificado.GrupoArticuloMantenimiento, Is.Not.Null);
            Assert.That(informeInspeccionFordModificado.GrupoArticuloMantenimiento.Detalle.Count
                        , Is.EqualTo(2));
        }
    }
}
