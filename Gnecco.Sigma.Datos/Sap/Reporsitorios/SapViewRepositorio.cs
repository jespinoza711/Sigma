using Gnecco.Sigma.Core.Shared.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Sap.Reporsitorios
{
    public class SapViewRepositorio
    {
        private readonly SapViewContext _context;

        public SapViewRepositorio()
        {
            _context = new SapViewContext();
        }

        public List<ViewSap> ListarByOT(int ot)
        {
            //return _context.Database.SqlQuery(typeof(ViewSap), "SELECT * FROM STR_SIGMA_CONSULTA WHERE OT = @OT", ot).AsQueryable(); 
            return (
                from V in _context.ViewSap
                where V.OT == ot
                select V
                ).ToList();
        }
    }
}
