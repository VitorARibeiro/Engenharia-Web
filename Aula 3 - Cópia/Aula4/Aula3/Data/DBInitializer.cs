using Aula3.Models;

namespace Aula3.Data
{
    public class DBInitializer
    {
        private Aula3Context _context;
        public DBInitializer(Aula3Context context) {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Category.Any())
            {
                return;
            }


            var categorias = new Category[]
            {
                new Category { Name = "Programming", Description = "ALgorithms and programming area courses" },
                new Category { Name = "Administration", Description = "Public administration and business management courses" },
                new Category { Name = "Communication", Description = "Business and institutional communication courses" }

            };

            _context.Category.AddRange(categorias);
           

            _context.SaveChanges();



        }
    }
}   
