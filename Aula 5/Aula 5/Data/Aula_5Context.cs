using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula_5.Models;

namespace Aula_5.Data
{
    public class Aula_5Context : DbContext
    {
        public Aula_5Context (DbContextOptions<Aula_5Context> options)
            : base(options)
        {
        }

        public DbSet<Aula_5.Models.Books> Books { get; set; } = default!;
    }
}
