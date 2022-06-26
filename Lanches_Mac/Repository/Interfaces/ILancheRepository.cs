using Lanches_Mac1.Models;

namespace Lanches_Mac1.Repository.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get;}
        IEnumerable<Lanche> LanchesPreferidos { get;}
        Lanche GetLancheById(int lancheId);
    }
}
