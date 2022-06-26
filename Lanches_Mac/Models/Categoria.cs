using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac1.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }

        //Definindo 'uma categoria para muitos Lanches'
        public List<Lanche> Lanches { get; set; }
    }
}
