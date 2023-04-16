using Microsoft.EntityFrameworkCore;
using ObraShalomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObraShalomAPI.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
