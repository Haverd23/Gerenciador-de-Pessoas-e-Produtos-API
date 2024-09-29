using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorio.Interfaces;

namespace WebApplication1.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DbContent _dbContext;
        public ProdutoRepositorio(DbContent dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutoModel> Adcionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoDb = await BuscarUsuarioPorId(id);
            if (produtoDb == null) throw new Exception($"Não foi possível encontrar nenhum registro com ID: {id}");
            produtoDb.Nome = produto.Nome;
            produtoDb.Modelo = produto.Modelo;
            produtoDb.Quantidade = produto.Quantidade;
            produtoDb.Status = produto.Status;
            produtoDb.PessoaId = produto.PessoaId;
            


            _dbContext.Update(produtoDb);
            await _dbContext.SaveChangesAsync();
            return produtoDb;


        }

        public async Task<List<ProdutoModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Produtos.Include(x => x.Pessoa).ToListAsync();
        }

        public async Task<ProdutoModel> BuscarUsuarioPorId(int id)
        {

            
            return await _dbContext.Produtos.Include(x => x.Pessoa).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Remover(int id)
        {
            ProdutoModel produtosDB = await BuscarUsuarioPorId(id);
            if (produtosDB == null) throw new Exception($"Não foi possível encontrar nenhum registro com ID: {id}");
            _dbContext.Remove(produtosDB);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}