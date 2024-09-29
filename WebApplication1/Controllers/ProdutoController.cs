using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

using WebApplication1.Repositorio.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosUsuarios()
        {
            List<ProdutoModel> produto = await _produtoRepositorio.BuscarTodosUsuarios();
            return Ok(produto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarUsuarioPorId(id);
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Criar([FromBody] ProdutoModel produto)
        {
            ProdutoModel produtoModel = await _produtoRepositorio.Adcionar(produto);
            return Ok(produtoModel);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produto, int id)
        {
            produto.Id = id;
            ProdutoModel produtoModel = await _produtoRepositorio.Atualizar(produto, id);
            return Ok(produtoModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Remover(id);
            return Ok(apagado);
        }
    }
}