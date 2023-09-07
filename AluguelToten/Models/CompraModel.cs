using System.ComponentModel.DataAnnotations.Schema;

namespace TotenAluguel.Models
{
    public class CompraModel
    {
        public int Id { get; set; } 
        public int quantidadeProduto { get; set; }
        public string precoFinal { get; set; } = string.Empty;
        public DateTime dataCompra { get; set; }


        [ForeignKey("UsuarioId")]
        public UsuarioModel? UsuarioModel { get; set; }
        
        [ForeignKey("FormaPagamentoId")]
        public FormaPagamento? FormaPagamento { get; set; }
        
        [ForeignKey("ProdutoId")]
        public ProdutoModel? ProdutoModel { get; set; }

        public int ProdutoId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int UsuarioId { get; set; }

    }
}
