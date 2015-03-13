using Gnecco.Sigma.Core.Inventario.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Inventario.Repositorios
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private readonly InventarioContext _context;

        public InventarioRepositorio()
        {
            _context = new InventarioContext();
        }



        public void Guardar(Core.Inventario.InventarioVehiculo inventario)
        {
            _context.Inventario.Add(inventario);
            _context.SaveChanges();
        }


        public List<Core.Inventario.InventarioVehiculo> ListarInventarioVehiculo()
        {
            return
                (from IV in _context.Inventario
                 select IV
                ).ToList();
        }

        public Core.Inventario.InventarioVehiculo BuscarPorId(int id)
        {
            return
                (from IV in _context.Inventario.Include("Coordenadas").Include("Fotos")
                 where IV.Id == id
                 select IV
                ).First();
        }


        public void Modificar(Core.Inventario.InventarioVehiculo inventario)
        {
            _context.Entry(inventario).State = System.Data.Entity.EntityState.Modified;
            foreach (var foto in inventario.Fotos)
            {
                if (foto.Id <= 0)
                {
                    _context.Entry(foto).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    _context.Entry(foto).State = System.Data.Entity.EntityState.Modified;
                }
            }
            _context.SaveChanges();
        }
    }
}
