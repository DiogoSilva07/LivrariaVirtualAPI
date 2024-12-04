using LivrariaVirtualAPI.Models;
using LivrariaVirtualAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaVirtualAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutosService produtosService;

        public ProdutosController()
        {
            produtosService = new ProdutosService();
        }

        [HttpGet]
        public List<Produto> Listar()
        {
            var produtos = produtosService.ObterTodos();

            return produtos;
        }

        [HttpPost]
        public List<Produto> Cadastrar([FromBody] ProdutoRequest request)
        {
            var produtosCadastrados = produtosService.Cadastrar(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Categoria);

            return produtosCadastrados;
        }

        [HttpDelete("{id}")]
        public List<Produto> Deletar([FromRoute]int id)
        {
            produtosService.Remover(id);

            return produtosService.ObterTodos();
        }
        [HttpPut("{id}")]
        public List<Produto> Atualizar(ProdutoRequest request, [FromRoute] int id)
        {
            produtosService.Atualizar(id, request.Nome, request.Descricao, request.Preco, request.Estoque, request.Categoria);

            return produtosService.ObterTodos();
        }
    }
}
