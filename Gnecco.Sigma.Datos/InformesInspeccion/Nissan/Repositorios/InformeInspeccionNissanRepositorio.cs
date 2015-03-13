using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Nissan.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Nissan.Repositorios
{
    public class InformeInspeccionNissanRepositorio : IInformeInspeccionNissanRepositorio
    {
        private readonly NissanContext _context;

        public InformeInspeccionNissanRepositorio()
        {
            _context = new NissanContext();
        }

        public List<InformeInspeccionNissan> ListarInformesInspeccion()
        {
            return
                (from II in _context.InformeInspeccionNissan
                 select II
                 ).ToList();
        }

        public InformeInspeccionNissan BuscarInformeInspeccionPorId(int id)
        {
            return
                (from II in _context.InformeInspeccionNissan.Include("GruposDetallesInformeInspeccionNissan.Detalles.Opciones")
                 where II.Id == id
                 select II
                ).First();
        }

        public void GuardarInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan)
        {
            _context.InformeInspeccionNissan.Add(informeInspeccionNissan);
            _context.SaveChanges();        
        }

        public void ModificarInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan)
        {
            foreach (var grupo in informeInspeccionNissan.GruposDetallesInformeInspeccionNissan)
            {
                if (grupo.Id <= 0)
                {
                    _context.Entry(grupo).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(grupo).State = EntityState.Modified;
                }

                foreach (var detalle in grupo.Detalles)
                {
                    if (detalle.Id <= 0)
                    {
                        _context.Entry(detalle).State = EntityState.Added;
                    }
                    else
                    {
                        _context.Entry(detalle).State = EntityState.Modified;
                    }

                    foreach (var opcion in detalle.Opciones)
                    {
                        if (opcion.Id <= 0)
                        {
                            _context.Entry(opcion).State = EntityState.Added;
                        }
                        else
                        {
                            _context.Entry(opcion).State = EntityState.Modified;
                        }
                    }
                }
            }
            //_context.InformeInspeccionNissan.Attach(informeInspeccionNissan);
            _context.Entry(informeInspeccionNissan).State = EntityState.Modified;
            _context.InformeInspeccionNissan.Attach(informeInspeccionNissan);            
            _context.SaveChanges();
        }

        public void AnularInformeInspeccion(InformeInspeccionNissan informeInspeccionNissan)
        {
            _context.Entry(informeInspeccionNissan).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
