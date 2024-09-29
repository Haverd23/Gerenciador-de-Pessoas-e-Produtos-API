using WebApplication1.Models;

namespace WebApplication1.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosUsuarios();
        Task<ProdutoModel> BuscarUsuarioPorId(int id);
        Task<ProdutoModel> Adcionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);
        Task<bool> Remover(int id);
    }
}
