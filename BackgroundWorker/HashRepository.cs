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
    public abstract class HashRepository
    {
        public abstract Task Save(DbContextOptions<AppDbContext> options, List<Hash>? hashes);
        
    }
}
