using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Repositorios
{
    public class InformeInspeccionVolkswagenRepositorio : IInformeInspeccionVolkswagenRepositorio
    {

        private readonly VolkswagenContext _context;


        public InformeInspeccionVolkswagenRepositorio()
        {
            _context = new VolkswagenContext();
        }


        public List<InformeInspeccionVolkswagen> ListarInformesInspeccion()
        {           
            return
                (from II in _context.InformeInspeccionVolkswagen
                 select II
                 ).ToList();
        }


        public InformeInspeccionVolkswagen BuscarInformeInspeccion(int id)
        {
            return
                (from II in _context.InformeInspeccionVolkswagen.Include("Detalles.Opciones")
                 where II.Id == id
                 select II
                ).First();
        }


        public void Guardar(InformeInspeccionVolkswagen informeInspeccionVolkswagen)
        {
            _context.InformeInspeccionVolkswagen.Add(informeInspeccionVolkswagen);
            _context.SaveChanges();
        }


        public void Modificar(InformeInspeccionVolkswagen informeInspeccionVolkswagen)
        {
            _context.Entry(informeInspeccionVolkswagen).State = EntityState.Modified;
            foreach (var detalle in informeInspeccionVolkswagen.Detalles)
            {
                if (detalle.Id <= 0)
                {
                    _context.Entry(detalle).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(detalle).State = EntityState.Modified;
                }
            }
            _context.SaveChanges();
        }


        public InformeInspeccionVolkswagen BuscarId(int id)
        {
            return
                (
                    from II in _context.InformeInspeccionVolkswagen.Include("Detalles.Opciones")
                    where II.Id == id
                    select II
                ).First();
        }


        public void Anular(InformeInspeccionVolkswagen informeInspeccionVolkswagen)
        {            
            _context.Entry(informeInspeccionVolkswagen).State = EntityState.Modified;
            //_context.InformeInspeccionVolkswagen.Attach(informeInspeccionVolkswagen);
            //informeInspeccionVolkswagen.Anular();
            _context.SaveChanges();            
        }
    }
}
