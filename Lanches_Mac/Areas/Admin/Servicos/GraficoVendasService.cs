using Lanches_Mac1.Context;
using Lanches_Mac1.Models;

namespace Lanches_Mac1.Areas.Admin.Servicos
{
    public class GraficoVendasService
    {
        private readonly AppDbContext context;

        public GraficoVendasService(AppDbContext Context)
        {
            context = Context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            //var data = DateTime.Now.AddDays(-dias);

            var data = DateTime.Parse("2022-02-12");

            //Consulta Linq
            var lanches = (from pd in context.PedidoDetalhes
                           join l in context.Lanche on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome }
                          into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGrafico>();
            
            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;

                lista.Add(lanche);
            }

            return lista;
        }
    }
}
