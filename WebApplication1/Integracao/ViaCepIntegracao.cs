using WebApplication1.Integracao.Interface;
using WebApplication1.Integracao.Response;
using WebApplication1.Integracao.Response.Refit;

namespace WebApplication1.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _integracao; // Corrigido aqui
        public ViaCepIntegracao(IViaCepIntegracaoRefit integracao)
        {
            _integracao = integracao;
        }

        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _integracao.ObterDadosViaCep(cep);
            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }
            return null;
        }
    }
}