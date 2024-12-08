using System.ComponentModel.DataAnnotations;

namespace LivrariaVirtualAPI.Models.Produtos
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [Required]
        public int Estoque { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }


    }

}

