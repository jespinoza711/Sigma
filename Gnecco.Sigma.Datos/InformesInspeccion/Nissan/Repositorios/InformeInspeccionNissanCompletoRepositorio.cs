using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios
{
	public class InformeInspeccionNissanCompletoRepositorio : IInformeInspeccionNissanCompletoRepositorio
	{

		private readonly NissanContext _context;

		public InformeInspeccionNissanCompletoRepositorio ()
		{
			_context = new NissanContext();
		}

		public void GuardarInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto)
		{
			_context.InformeInspeccionNissanCompleto.Add(informeInspeccionNissanCompleto);
			_context.SaveChanges();        
		}


		public InformeInspeccionNissanCompleto BuscarPorId(int id)
		{
			return
				(from II in _context.InformeInspeccionNissanCompleto
					//.Include("GruposInformeInspeccionNissanCompleto")
                    //.Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.Valores")
					.Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.Valores.Opcion")
					.Include("GruposInformeInspeccionNissanCompleto.GrupoinformeInspeccionNissan")
					.Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.DetalleInformeInspeccionNissan")
				 where II.Id == id
				 select II
				).FirstOrDefault();
		}

		public List<InformeInspeccionNissanCompleto> ListarInformesInspeccion(int informeInspeccionId)
		{
			return
				(from II in _context.InformeInspeccionNissanCompleto
                     //.Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.Valores")
                     .Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.Valores.Opcion")
					 .Include("GruposInformeInspeccionNissanCompleto.GrupoinformeInspeccionNissan")
					 .Include("GruposInformeInspeccionNissanCompleto.DetallesInformeInspeccionNissanCompleto.DetalleInformeInspeccionNissan")                 
				 where II.InformeInspeccionId == informeInspeccionId
				 select II
				).ToList();
		}

		public void ModificarInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto)
		{
			throw new NotImplementedException();
		}

		public void AnularInformeInspeccionCompleto(InformeInspeccionNissanCompleto informeInspeccionNissanCompleto)
		{
			throw new NotImplementedException();
		}
	}
}
