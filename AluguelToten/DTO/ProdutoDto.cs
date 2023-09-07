namespace AluguelToten.DTO
{
    public class ProdutoDto
    {
        public string nomeProduto { get; set; } = string.Empty;
        public string descricaoProduto { get; set; } = string.Empty;
        public int quantidadeEstoque { get; set; }
        public double precoProduto { get; set; }

    }
}
