using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class LogoutController : ApiController
    {
        [HttpPost]
        public void Post()
        {
            var httpRequest = HttpContext.Current.Request;

            HttpContext.Current.Response.Cookies.Remove("_perfil");
            HttpContext.Current.Response.Cookies.Remove("_nombreUsuario");
            HttpContext.Current.Response.Cookies.Remove("_nombreCompleto");
        }

        [HttpGet]
        public void Get()
        {
            var httpRequest = HttpContext.Current.Request;

            HttpContext.Current.Response.Cookies.Remove("_perfil");
            HttpContext.Current.Response.Cookies.Remove("_nombreUsuario");
            HttpContext.Current.Response.Cookies.Remove("_nombreCompleto");
        }
    }
}
