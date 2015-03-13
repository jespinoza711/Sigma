using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Ford.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford;

using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen;

using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Nissan;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnecco.Sigma.Web.Controllers
{
    public class InformesInspeccionController : Controller
    {
        //
        // GET: /InformesInspeccion/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Volkswagen()
        {
            return View();
        }
        public ActionResult Nissan()
        {
            return View();
        }

        public ActionResult Ford()
        {
            return View();
        }

        public ActionResult ReporteFord(int id)
        {
            IInformeInspeccionFordRepositorio _informeInspeccionFordRepositorio = new InformeInspeccionFordRepositorio();
            InformeInspeccionFordCompleto informeInspeccionFordCompleto = _informeInspeccionFordRepositorio.BuscarInformeInspeccionCompleto(id);
            InformeInspeccionFordViewModel informeInspeccionFordViewModel
                = new InformeInspeccionFordViewModel(informeInspeccionFordCompleto);
            return new Rotativa.ViewAsPdf(informeInspeccionFordViewModel);
        }

        public ActionResult ReporteVolkswagen(int id)
        {
            IInformeInspeccionVolkswagenCompletoRepositorio _informeInspeccionVolkswagenCompletoRepositorio = new InformeInspeccionVolkswagenCompletoRepositorio();
            IInformeInspeccionVolkswagenRepositorio _informeInspeccionVolkswagenRepositorio = new InformeInspeccionVolkswagenRepositorio();
            InformeInspeccionCompletoGetViewModel informeInspeccionCompletoGetViewModel = new InformeInspeccionCompletoGetViewModel();

            InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto = _informeInspeccionVolkswagenCompletoRepositorio.GetInformeInspeccionCompletoById(id);
            InformeInspeccionVolkswagen informeInspeccionVolkswagen = _informeInspeccionVolkswagenRepositorio.BuscarInformeInspeccion(informeInspeccionVolkswagenCompleto.InformeInspeccionId);
            informeInspeccionCompletoGetViewModel.MapearDesde(informeInspeccionVolkswagenCompleto, informeInspeccionVolkswagen);

            return new Rotativa.ViewAsPdf(informeInspeccionCompletoGetViewModel);
        }

        public ActionResult ReporteNissan(int id)
        {
            IInformeInspeccionNissanCompletoRepositorio _informeInspeccionNissanCompletoRepositorio = new InformeInspeccionNissanCompletoRepositorio();
            IInformeInspeccionNissanRepositorio _informeInspeccionNissanRepositorio = new InformeInspeccionNissanRepositorio();
            InformeInspeccionCompletoNissanGetViewModel nissanGetViewModel = new InformeInspeccionCompletoNissanGetViewModel();

            InformeInspeccionNissanCompleto informeInspeccionNissanCompleto = _informeInspeccionNissanCompletoRepositorio.BuscarPorId(id);
            InformeInspeccionNissan informeInspeccionNissan = _informeInspeccionNissanRepositorio.BuscarInformeInspeccionPorId(informeInspeccionNissanCompleto.InformeInspeccionId);
            nissanGetViewModel.MapearDesde(informeInspeccionNissanCompleto, informeInspeccionNissan);

            return new Rotativa.ViewAsPdf(nissanGetViewModel);
        }
    }
}
