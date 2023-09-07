using AluguelToten.Models;

namespace AluguelToten.DTO
{
    public class CarroDto
    {
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string mABateria { get; set; } = string.Empty;
        public string tipoConector { get; set; } = string.Empty;
        public int cargaAtual { get; set; }
       
    }
}
