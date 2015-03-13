using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Datos.Usuario.Reporsitorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Gnecco.Sigma.Web.Api
{
    public class UsuarioController : ApiController
    {
        UsuarioRepositorio _repo;

        public UsuarioController()
        {
            _repo = new UsuarioRepositorio();
        }

        [HttpPost]
        public void Post()
        {
            var httpRequest = HttpContext.Current.Request;
            string nombreUsuario = httpRequest.Form["NombreUsuario"];
            string pass = httpRequest.Form["Pass"];
            string perfil = null;

            try
            {
                Usuario usuario = _repo.LoginUsuario(nombreUsuario, pass);
                perfil = usuario.Perfil;

                var perfilCookie = new HttpCookie("_perfil", perfil);
                perfilCookie.Expires.AddHours(2);

                var nombreUsuarioCookie = new HttpCookie("_nombreUsuario", nombreUsuario);
                nombreUsuarioCookie.Expires.AddHours(2);

                var nombreCompletoCookie = new HttpCookie("_nombreCompleto", usuario.Apellidos + ", " + usuario.Nombres);
                nombreCompletoCookie.Expires.AddHours(2);

                HttpContext.Current.Response.Cookies.Add(perfilCookie);
                HttpContext.Current.Response.Cookies.Add(nombreUsuarioCookie);
                HttpContext.Current.Response.Cookies.Add(nombreCompletoCookie);

                //var aux = httpRequest.Cookies["_perfil"];            
                HttpContext.Current.Response.Redirect("~/");
            }
            catch (Exception)
            {
                //HttpContext.Current.Response.Redirect("http://localhost:2338/?error=errorlogin");
                HttpContext.Current.Response.Redirect("~/");
            }
        }

        public void Delete(int id) 
        {
            HttpContext.Current.Response.Cookies.Remove("_perfil");
            HttpContext.Current.Response.Cookies.Remove("_nombreUsuario");
            HttpContext.Current.Response.Cookies.Remove("_nombreCompleto");
        }

        public void Get(int id)
        {

        }

        public void Get()
        {
            int id = int.Parse(HttpContext.Current.Session["Id"].ToString());

            if (true)
            {
                
            }
        }
    }
}
