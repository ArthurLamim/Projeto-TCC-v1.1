using System.ComponentModel.DataAnnotations.Schema;
using AluguelToten.Models;

namespace TotenAluguel.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string nomeUsuario { get; set; } = string.Empty;
        public string CPFUsuario { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
        public string emailUsuario { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }
        public string CustomIdentityUserId { get; set; } // FK do AspNetUser

        [ForeignKey("CustomIdentityUserId")]
        public CustomIdentityUser CustomIdentityUser { get; set; } 

        //[ForeignKey("EnderecoId")]
        //public EnderecoModel? endereco { get; set; }
        //public int EnderecoId { get; set; }

        public ICollection<UsuarioCarro> UsuarioCarros { get; set; }
    }
}   