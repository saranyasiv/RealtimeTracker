using MOdals;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRepository
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext() : base("VehicleConnectionstring")
        {

        }
        public DbSet<Login> Login { get; set; }
        public DbSet<Locationinfo> location { get; set; }
    }
}
