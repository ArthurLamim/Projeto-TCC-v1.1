using TotenAluguel.Models;

namespace AluguelToten.DTO
{
    public class AluguelDto
    {
        public float QtdVoltzUsada { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public float PrecoFinal { get; set; }
        public bool Finalizado { get; set; }
        public int CarroId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int UsuarioId { get; set; }
        public int TotenId { get; set; }
        
    }
}
