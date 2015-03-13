using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Repositorios;
using Gnecco.Sigma.Core.InformesInspeccion.Volkswagen.Entidades;
using System.Data.Entity;

namespace Gnecco.Sigma.Datos.InformesInspeccion.Volkswagen.Repositorios
{
    public class InformeInspeccionVolkswagenCompletoRepositorio :  IInformeInspeccionVolkswagenCompletoRepositorio
    {

        private readonly VolkswagenContext _context;


        public InformeInspeccionVolkswagenCompletoRepositorio()
        {
            _context = new VolkswagenContext();
        }


        public void GuardarCompleto(InformeInspeccionVolkswagenCompleto informeInspeccionVolkswagenCompleto)
        {
            _context.InformeInspeccionVolkswagenCompleto.Add(informeInspeccionVolkswagenCompleto);
            _context.SaveChanges();
        }


        public InformeInspeccionVolkswagenCompleto GetInformeInspeccionCompletoById(int id)
        {
            return
                (from IIVC in _context.InformeInspeccionVolkswagenCompleto
                    .Include("DetallesInformeInspeccionVolkswagenCompleto.Valores.Opcion")
                    .Include("DetallesInformeInspeccionVolkswagenCompleto.DetalleInformeInspeccionVolkswagen")
                 where IIVC.Id == id
                 select IIVC
                ).First();
        }


        public List<InformeInspeccionVolkswagenCompleto> ListarInformesInspeccionCompletosPorInformeInspeccion(int id)
        {
            return
                (
                    from IIC in _context.InformeInspeccionVolkswagenCompleto
                    where IIC.InformeInspeccionId == id
                    select IIC
                ).ToList();
        }


        public void AnularInformeInspeccionCompleto(InformeInspeccionVolkswagenCompleto informInspeccionVolkswagenCompleto)
        {
            _context.Entry(informInspeccionVolkswagenCompleto).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
