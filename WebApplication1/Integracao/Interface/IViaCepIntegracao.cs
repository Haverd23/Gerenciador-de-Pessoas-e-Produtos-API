using WebApplication1.Integracao.Response;

namespace WebApplication1.Integracao.Interface
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}