using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Core.Inventario.Repositorios
{
    public interface IInventarioRepositorio
    {
        void Guardar(InventarioVehiculo inventario);
        void Modificar(InventarioVehiculo inventario);
        List<InventarioVehiculo> ListarInventarioVehiculo();
        InventarioVehiculo BuscarPorId(int id);
    }
}
