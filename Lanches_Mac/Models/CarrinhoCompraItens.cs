using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches_Mac1.Models
{
    public class CarrinhoCompraItens
    {   
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CarrinhoCompraItemId { get; set; }
        public virtual Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoCompraId { get; set; }  //Id do carrinho de compra, para identificar onde os itens foram inseridos. //ainda não criamos a classe CarrinhoCompras
    }
}
