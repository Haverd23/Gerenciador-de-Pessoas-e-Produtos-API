using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Integracao.Interface;
using WebApplication1.Models;

using WebApplication1.Repositorio.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IViaCepIntegracao _viaCepIntegracao;
        public PessoaController(IPessoaRepositorio pessoaRepositorio, IViaCepIntegracao viaCepIntegracao)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _viaCepIntegracao = viaCepIntegracao;
        }
        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodosUsuarios()
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarTodosUsuarios();
            return Ok(pessoas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(int id)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarUsuarioPorId(id);
            return Ok(pessoa);
        }
        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Criar([FromBody] PessoaModel pessoa)
        {
            var endereco = await _viaCepIntegracao.ObterDadosViaCep(pessoa.Cep);
            if (endereco == null)
                return NotFound("Endereço não encontrado.");

           
            pessoa.Localidade = endereco.Localidade;
            pessoa.Bairro = endereco.Bairro;
            pessoa.Uf = endereco.Uf;
            PessoaModel pessoaModel = await _pessoaRepositorio.Adcionar(pessoa);
            return Ok(pessoaModel);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel pessoa, int id)
        {
            pessoa.Id = id;
            PessoaModel pessoaModel = await _pessoaRepositorio.Atualizar(pessoa, id);
            return Ok(pessoaModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> Apagar(int id)
        {
            bool apagado = await _pessoaRepositorio.Remover(id);
            return Ok(apagado);
        }
    }
}