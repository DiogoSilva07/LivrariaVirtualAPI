namespace LivrariaVirtualAPI.Models.Produtos
{
    public class ProdutoRequest
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Status { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; set; }

    }
}
