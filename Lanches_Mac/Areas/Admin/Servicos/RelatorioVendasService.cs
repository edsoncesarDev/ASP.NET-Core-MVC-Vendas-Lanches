using Lanches_Mac1.Context;
using Lanches_Mac1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac1.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            //Montando consulta na memoria
            var resultado = from obj in context.Pedido select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(a => a.PedidoEnviado <= maxDate.Value);
            }
            //fim consulta

            return await resultado.Include(l => l.PedidoItens)
                                  .ThenInclude(l => l.Lanche)
                                  .OrderByDescending(x => x.PedidoEnviado)
                                  .ToListAsync();
        }
    }
}
