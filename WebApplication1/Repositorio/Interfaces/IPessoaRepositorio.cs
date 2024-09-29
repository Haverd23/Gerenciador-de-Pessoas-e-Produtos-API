using WebApplication1.Models;

namespace WebApplication1.Repositorio.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodosUsuarios();
        Task<PessoaModel> BuscarUsuarioPorId(int id);
        Task<PessoaModel> Adcionar(PessoaModel pessoa);
        Task<PessoaModel> Atualizar(PessoaModel pessoa, int id);
        Task<bool> Remover(int id);
    }
}