using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Volkswagen
{
	public class InformeInspeccionPostViewModel
	{
		public string Descripcion { get; set; }
		public string Nombre { get; set; }
		public List<DetallesPostViewModel> Detalles { get; set; }        
	}

	public class DetallesPostViewModel
	{
		public string Descripcion { get; set; }
		public List<OpcionesPostViewModel> OpcionesCondicion { get; set; }
		public List<OpcionesPostViewModel> OpcionesIntervaloKm { get; set; }
		public List<OpcionesPostViewModel> OpcionesInternas { get; set; }
	}

	public class OpcionesPostViewModel
	{
		public string Descripcion { get; set; }
	}
}