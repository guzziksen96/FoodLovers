using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodLovers.Persistence
{
    public class FoodLoversDbContext : DbContext
    {
        public FoodLoversDbContext(DbContextOptions<FoodLoversDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodLoversDbContext).Assembly);
            //modelBuilder.SeedData(); 
            //todo
        }
    }
}
