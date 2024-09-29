
namespace WebApplication1.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cep { get; set; }

        public string? Localidade { get; set; }
        public string? Bairro { get; set; }
        public string? Uf { get; set; }
    }
}