using System.ComponentModel.DataAnnotations;

namespace TotenAluguel.Models
{
    public class ProdutoModel
    {
        
        public int Id { get; set; }
        public string nomeProduto { get; set; } = string.Empty;
        public string descricaoProduto { get; set; } = string.Empty;
        public int quantidadeEstoque { get; set; }
        public double precoProduto { get; set; }

    }
}
