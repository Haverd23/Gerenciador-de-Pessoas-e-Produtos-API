using WebApplication1.Enuns;

namespace WebApplication1.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Quantidade { get; set; }

        public StatusEnum Status { get; set; }
        public int? PessoaId { get; set; }
        public virtual PessoaModel? Pessoa { get; set; }
    }
}