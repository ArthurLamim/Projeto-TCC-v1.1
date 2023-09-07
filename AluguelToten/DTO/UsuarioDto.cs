using AluguelToten.Models;
using System.ComponentModel.DataAnnotations.Schema;
using TotenAluguel.Models;

namespace AluguelToten.DTO
{
    public class UsuarioDto
    {
        public string nomeUsuario { get; set; } = string.Empty;
        public string CPFUsuario { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
        public string emailUsuario { get; set; } = string.Empty;
       

        
    }
}
