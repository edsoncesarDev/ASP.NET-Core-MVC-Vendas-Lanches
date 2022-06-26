using Lanches_Mac1.Context;
using Lanches_Mac1.Models;
using Lanches_Mac1.Repository.Interfaces;

namespace Lanches_Mac1.Repository
{
    
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categoria;
    }

    
}
