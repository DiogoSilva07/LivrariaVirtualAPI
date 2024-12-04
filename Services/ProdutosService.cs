using LivrariaVirtualAPI.Models;

namespace LivrariaVirtualAPI.Services
{
    public class ProdutosService
    {
        private static List<Produto> Produtos { get; set; } = new List<Produto>()
        {
            new Produto()
            {
                Id = 1,
                Nome = "O Peregrino",
                Descricao = "Livro sobre aventura",
                Estoque = 520,
                Preco = 130,
                Categoria = "Aventura"
            },
            new Produto()
            {
                Id = 2,
                Nome = "As Crônicas de Nárnia",
                Descricao = "Livro sobre ação e Aventura",
                Estoque = 340,
                Preco = 98,
                Categoria = "Suspense"
            }

        };

        public List<Produto> ObterTodos()
        {
            return Produtos;
        }

        public List<Produto> Cadastrar (string nome, string descricao, decimal preco, int estoque, string categoria)
        {
            Produto produto = new Produto()
            {
                Id = Produtos.Count() + 1,
                Nome = nome,
                Descricao = descricao,
                Estoque = estoque,
                Preco = preco,
                Categoria = categoria

            };

            Produtos.Add(produto);

            return ObterTodos();
        }

        public void Remover(int id)
        {
            var produto = Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
                return;

            Produtos.Remove(produto);
        }

        public void Atualizar(int id, string nome, string descricao, decimal preco, int estoque, string categoria)
        {
            var produto = Produtos.FirstOrDefault(x => x.Id == id); 
            produto.Nome = nome;
            produto.Descricao = descricao;
            produto.Preco = preco;
            produto.Estoque = estoque;
            produto.Categoria = categoria;

            Produtos.Remove(produto);
            Produtos.Add(produto);

        }

    }
}
