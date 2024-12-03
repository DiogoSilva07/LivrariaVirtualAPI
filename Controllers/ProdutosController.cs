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
        public List<Produto> Get()
        {
            var produtos = produtosService.ObterTodos();

            return produtos;
        }

    }
}
