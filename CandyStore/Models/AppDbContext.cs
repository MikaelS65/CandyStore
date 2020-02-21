using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Models
{
    public class AppDbContext : DbContext    //Must inherit from DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Candy> Candies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
