using System.ComponentModel.DataAnnotations.Schema;

namespace TotenAluguel.Models
{
    public class AluguelModel
    {
        public int Id { get; set; }
        public float QtdVoltzUsada { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public float PrecoFinal { get; set; }
        public bool Finalizado { get; set; }

        // Chave estrangeira para CarroModel
        public int CarroId { get; set; }
        public CarroModel Carro { get; set; }

        // Chave estrangeira para FormaPagamento
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        // Chave estrangeira para UsuarioModel
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        // Chave estrangeira para TotenModel
        public int TotenId { get; set; }
        public TotenModel Toten { get; set; }
    }
}   