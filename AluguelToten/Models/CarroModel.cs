using AluguelToten.Models;

namespace TotenAluguel.Models
{
    public class CarroModel
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string mABateria { get; set; } = string.Empty;
        public string tipoConector { get; set; } = string.Empty;
        public int cargaAtual { get; set; }
        public ICollection<UsuarioCarro> UsuarioCarros { get; set; }

    }
}
