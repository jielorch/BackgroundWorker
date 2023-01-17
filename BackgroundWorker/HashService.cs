using BackgroundWoker;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class HashService : HashRepository
    { 
        public async override Task Save(DbContextOptions<AppDbContext> options, List<Hash>? hashes)
        {
            using var context = new AppDbContext(options);
            if(hashes!= null)
            {
                context.AddRange(hashes);
                await context.SaveChangesAsync();
            }
            
        }
    }
}
