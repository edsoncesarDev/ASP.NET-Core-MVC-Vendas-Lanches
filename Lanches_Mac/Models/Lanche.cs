using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac1.Models
{
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        //Definindo relacionamento entre lanche e categoria
        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }//Criando chave foreign key

        public virtual Categoria Categoria { get; set; } //Relacionamento com a tabela Lanche
    }
}
