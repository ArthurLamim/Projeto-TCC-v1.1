namespace TotenAluguel.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public int CEP { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public int Numero { get; set; }

    }
}
