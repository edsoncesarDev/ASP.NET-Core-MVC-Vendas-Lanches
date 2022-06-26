using Lanches_Mac1.Context;
using Lanches_Mac1.Models;
using Lanches_Mac1.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac1.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }


        //Consultas LINQ


        //Obtendo todos os lanches e suas respectivas categorias.
        // - Include: Método que permite obter os dados relacionados incluindo-os no resultado da consulta.
        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c => c.Categoria);

        //Obtendo todos os lanchesPreferidos e suas respectivas categorias.
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanche.Where(p => p.IsLanchePreferido).Include(c => c.Categoria);

        //Pegando um lanche especifico pelo Id.
        //Where: permite realizar um filtro usando uma condição em uma expressão lambda.
        //FirstOrDefault: Retorna o primeiro elemento de uma sequência ou um valor padrão caso não seja encontrado nenhum elemento.
        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanche.FirstOrDefault(l => l.LancheId == lancheId);
        }
            
    }
}
