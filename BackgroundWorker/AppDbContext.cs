using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWoker
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //set the database connection here
        //    optionsBuilder.UseSqlServer(@"server=.\SQLDEVELOPER;database=HashDB;Integrated Security=true");
        //}

        public DbSet<Hash>? Hashes { get; set; }
    }
}
