using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schools2.Models;

namespace Schools2.Data
{
    public class Schools2Context : DbContext
    {
        public Schools2Context (DbContextOptions<Schools2Context> options)
            : base(options)
        {
        }

        public DbSet<Schools2.Models.City> City { get; set; } = default!;

        public DbSet<Schools2.Models.County>? County { get; set; }

        public DbSet<Schools2.Models.Country>? Country { get; set; }

        public DbSet<Schools2.Models.School>? School { get; set; }
    }
}
