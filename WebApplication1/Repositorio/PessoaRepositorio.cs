using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorio.Interfaces;

namespace WebApplication1.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly DbContent _dbContext;
        public PessoaRepositorio(DbContent dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PessoaModel> Adcionar(PessoaModel pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<PessoaModel> Atualizar(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaDb = await BuscarUsuarioPorId(id);
            if (pessoaDb == null) throw new Exception($"Não foi possível encontrar nenhum registro com ID: {id}");
            pessoaDb.Nome = pessoa.Nome;
            pessoaDb.Idade = pessoa.Idade;
            pessoaDb.Cep = pessoa.Cep;

            _dbContext.Update(pessoaDb);
            await _dbContext.SaveChangesAsync();
            return pessoaDb;


        }

        public async Task<List<PessoaModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task<PessoaModel> BuscarUsuarioPorId(int id)
        {
            return await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Remover(int id)
        {
            PessoaModel pessoaDb = await BuscarUsuarioPorId(id);
            if (pessoaDb == null) throw new Exception($"Não foi possível encontrar nenhum registro com ID: {id}");
            _dbContext.Remove(pessoaDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}