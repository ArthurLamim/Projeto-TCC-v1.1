using System.ComponentModel.DataAnnotations.Schema;
using TotenAluguel.Models;

namespace AluguelToten.DTO
{
    public class CompraDto
    {
        public int quantidadeProduto { get; set; }
        public string precoFinal { get; set; } = string.Empty;
        public DateTime dataCompra { get; set; }

        public int ProdutoId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
