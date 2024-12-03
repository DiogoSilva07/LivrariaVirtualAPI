using LivrariaVirtualAPI.Models;

namespace LivrariaVirtualAPI.Services
{
    public class ProdutosService
    {
        private List<Produto> Produtos { get; set; } = new List<Produto>();

        public List<Produto> ObterTodos()
        {
            Produto produto = new Produto()
            {
                Id = 1,
                Nome = "O Peregrino",
                Estoque = 738,
                Categoria = "Aventura",
            };

            Produtos.Add(produto);

            return Produtos;
        }

    }
}
