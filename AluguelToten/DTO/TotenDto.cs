using System.ComponentModel.DataAnnotations.Schema;
using TotenAluguel.Models;

namespace AluguelToten.DTO
{
    public class TotenDto
    {
        public string tipoConector { get; set; } = string.Empty;
        public string cargaUsada { get; set; } = string.Empty;
        public string tempoUso { get; set; } = string.Empty;
        public bool disponivel { get; set; }
        public double voltPorMinuto { get; set; }
        public double precoVoltagem { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
      
        public int EnderecoId { get; set; }
    }
}
