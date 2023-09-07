using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface IAluguelRepositorio
    {
        Task<List<AluguelModel>> BuscarTodosAlugueis();
        Task<AluguelModel> BuscarPorId(int id);
        Task<AluguelModel> Adicionar(AluguelDto aluguel);
        Task<AluguelModel> Atualizar(AluguelDto aluguel, int id);
        Task<bool> Apagar(int id);
    }
}
