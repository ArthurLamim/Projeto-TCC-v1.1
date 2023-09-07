using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface IProdutoRepositorio 
    {

        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoDto produto);
        Task<ProdutoModel> Atualizar(ProdutoDto produto, int id);
        Task<bool> Apagar(int id);

    }
}
