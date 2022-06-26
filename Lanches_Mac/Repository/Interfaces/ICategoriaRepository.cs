using Lanches_Mac1.Models;

namespace Lanches_Mac1.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
