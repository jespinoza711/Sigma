using Gnecco.Sigma.Core.Inventario;
using Gnecco.Sigma.Core.Inventario.Repositorios;
using Gnecco.Sigma.Datos.Inventario.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class InventarioFotoController : ApiController
    {

        IInventarioRepositorio _inventarioRepositorio;

        public InventarioFotoController()
        {
            _inventarioRepositorio = new InventarioRepositorio();
        }

        [HttpPost]
        public void Post()
        {
            // Resultado Http
            //HttpResponseMessage result = null;
            // Request HTTP
            var httpRequest = HttpContext.Current.Request;
            // Path de las FOTOS
            string PathFotos = "~/Uploads/Fotos/";
            // Inventario ID
            string InventarioId = httpRequest.Form[0];
            int InventarioIdParse = int.Parse(InventarioId);
            // Obtenemos el Inventario Completo por ID
            InventarioVehiculo inventario = _inventarioRepositorio.BuscarPorId(InventarioIdParse);
            // Path de FOTOS + InventarioId
            string PathFotosInventario = PathFotos + InventarioId;

            if (httpRequest.Files.Count > 0)
            {
                bool existsPath = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(PathFotosInventario));
                // Si existe el path lo creamos
                if(!existsPath)
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(PathFotosInventario));
                }

                // Lista de files
                var docfiles = new List<string>();
                // Recorremos la lista
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    if (postedFile.ContentLength > 0)
                    {
                        var filePath = HttpContext.Current.Server.MapPath(PathFotosInventario + "/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);
                        // Añadimos la rutas
                        inventario.Fotos.Add(new InventarioFoto { Ruta = postedFile.FileName, InventarioId = InventarioIdParse });
                    }
                }

                _inventarioRepositorio.Modificar(inventario);

                //result = Request.CreateResponse(HttpStatusCode.Created, docfiles);                            
            }
            else
            {
                //result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            //return result;            
        }
    }
}
