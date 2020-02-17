using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bikeshop_Project.Models;

namespace Bikeshop_Project.Data
{
    public class Bikeshop_ProjectContext : DbContext
    {
        public Bikeshop_ProjectContext (DbContextOptions<Bikeshop_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Bikeshop_Project.Models.City> City { get; set; }

        public DbSet<Bikeshop_Project.Models.CommonSizes> CommonSizes { get; set; }

        public DbSet<Bikeshop_Project.Models.BikeTubes> BikeTubes { get; set; }
    }
}
