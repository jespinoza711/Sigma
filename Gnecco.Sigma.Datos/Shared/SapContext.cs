using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gnecco.Sigma.Datos.Shared
{
    public abstract class SapContext : DbContext
    {
         static SapContext()
        {
            Database.SetInitializer<SapContext>(null);
        }

         public SapContext()
             : base("UsigmaCon")
        {

        }
    }
}
