using System.ComponentModel.DataAnnotations.Schema;
using TotenAluguel.Models;

namespace AluguelToten.Models
{
    public class UsuarioCarro
    {
        // Chave estrangeira para UsuarioModel
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        // Chave estrangeira para CarroModel
        [ForeignKey("CarroId")]
        public int CarroId { get; set; }
        public CarroModel Carro { get; set; }

    }
}
