using Gnecco.Sigma.Core.Inventario;
using Gnecco.Sigma.Core.Inventario.Repositorios;
using Gnecco.Sigma.Datos.Inventario.Repositorios;
using Gnecco.Sigma.Web.ViewModels.Inventario;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnecco.Sigma.Web.Controllers
{
    public class InventarioVehiculosController : Controller
    {
        //
        // GET: /InventarioVehiculos/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReporteInventario(int id)
        {
            IInventarioRepositorio _inventarioRepositorio = new InventarioRepositorio();
            InventarioVehiculo inventario = _inventarioRepositorio.BuscarPorId(id);
            InventarioGetViewModel vm = new InventarioGetViewModel();
            vm.MapearDesde(inventario);

            return new Rotativa.ViewAsPdf(vm);
            //return View(vm);
        }

    }
}
