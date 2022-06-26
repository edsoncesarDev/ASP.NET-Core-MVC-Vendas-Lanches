using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac1.Models
{
    public class PedidoDetalhe
    {
        [Key]
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public virtual Lanche Lanche { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
