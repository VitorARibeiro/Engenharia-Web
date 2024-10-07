using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula3.Models;

namespace Aula3.Data
{
    public class Aula3Context : DbContext
    {
        public Aula3Context (DbContextOptions<Aula3Context> options)
            : base(options)
        {
        }

        public DbSet<Aula3.Models.Category> Category { get; set; } = default!;
        public DbSet<Aula3.Models.Course> Course { get; set; }
    }
}
