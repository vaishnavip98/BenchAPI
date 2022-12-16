using Microsoft.EntityFrameworkCore;
using BenchAPI.Models;

namespace Bench.API.Data
{
    public class BenchDbContext : DbContext
    {
        public BenchDbContext(DbContextOptions<BenchDbContext> options) : base(options)
        {

        }
        public DbSet<BenchResource> Benchs { get; set; }
        public DbSet<Partner> Partners { get; set; }


    }
}
