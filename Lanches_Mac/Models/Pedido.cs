using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac1.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Telefone {get; set;}
        public string Email { get; set; }
        public decimal PedidoTotal { get; set; }
        public int TotalItensPedido { get; set; }
        public DateTime PedidoEnviado { get; set; }
        public DateTime? PedidoEntregueEm { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }


    }
}
