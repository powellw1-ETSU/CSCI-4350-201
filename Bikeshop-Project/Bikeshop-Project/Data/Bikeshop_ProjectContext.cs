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

        public DbSet<Bikeshop_Project.Models.WorkArea> WorkArea { get; set; }

        public DbSet<Bikeshop_Project.Models.TubeMaterial> TubeMaterial { get; set; }

        public DbSet<Bikeshop_Project.Models.TempDateMade> TempDateMade { get; set; }

        public DbSet<Bikeshop_Project.Models.StateTaxRate> StateTaxRate { get; set; }

        public DbSet<Bikeshop_Project.Models.SampleStreet> SampleStreet { get; set; }

        public DbSet<Bikeshop_Project.Models.SampleName> SampleName { get; set; }

        public DbSet<Bikeshop_Project.Models.RevisionHistory> RevisionHistory { get; set; }

        public DbSet<Bikeshop_Project.Models.RetailStore> RetailStore { get; set; }

        public DbSet<Bikeshop_Project.Models.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<Bikeshop_Project.Models.PurchaseItem> PurchaseItem { get; set; }

        public DbSet<Bikeshop_Project.Models.Preference> Preference { get; set; }

        public DbSet<Bikeshop_Project.Models.Paint> Paint { get; set; }

        public DbSet<Bikeshop_Project.Models.ModelType> ModelType { get; set; }

        public DbSet<Bikeshop_Project.Models.BikeParts> BikeParts { get; set; }

        public DbSet<Bikeshop_Project.Models.BicycleTubeUsage> BicycleTubeUsage { get; set; }

        public DbSet<Bikeshop_Project.Models.Bicycle> Bicycle { get; set; }

        public DbSet<Bikeshop_Project.Models.Component> Component { get; set; }

        public DbSet<Bikeshop_Project.Models.ComponentName> ComponentName { get; set; }

        public DbSet<Bikeshop_Project.Models.Customer> Customer { get; set; }

        public DbSet<Bikeshop_Project.Models.CustomerTransaction> CustomerTransaction { get; set; }

        public DbSet<Bikeshop_Project.Models.Employee> Employee { get; set; }

        public DbSet<Bikeshop_Project.Models.GroupComponents> GroupComponents { get; set; }

        public DbSet<Bikeshop_Project.Models.GroupO> GroupO { get; set; }
    }
}
