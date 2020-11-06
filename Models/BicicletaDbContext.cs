using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bike.Models
{
    public class BicicletaDbContext : DbContext
    {
        public BicicletaDbContext(DbContextOptions<BicicletaDbContext> options):base (options)
        {
        }

        public DbSet<Bicicleta> Bicicletas { get; set; }

    }
}
