using LivrariaVirtualAPI.Data;
using LivrariaVirtualAPI.Models.Produtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaVirtualAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly LivrariaVirtualContext _context;

        public ProdutosController(LivrariaVirtualContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<Produto>> Listar()
        {

            return Ok(_context.Produto.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Listar([FromRoute] int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Cadastrar([FromBody] ProdutoRequest request)
        {
            var produto = new Produto()
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Status = request.Status,
                Estoque = request.Estoque,
                Categoria = request.Categoria,
            };

            _context.Produto.Add(produto);
            _context.SaveChanges();


            return Ok(produto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, Funcionário")]
        public ActionResult<Produto> Atualizar([FromRoute] int id, [FromBody] ProdutoRequest request)
        {
            var produto = new Produto()
            {
                Id = id,
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Status = request.Status,
                Estoque = request.Estoque,
                Categoria = request.Categoria,
            };

            if (id <= 0) return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<Produto> Deletar([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            var produto = _context.Produto.Find(id);
            if (produto == null) return NotFound();


            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
