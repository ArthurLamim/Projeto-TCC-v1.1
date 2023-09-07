using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<List<EnderecoModel>> BuscarTodosEnderecos();
        Task<EnderecoModel> BuscarPorId(int id);
        Task<EnderecoModel> Adicionar(EnderecoDto endereco);
        Task<EnderecoModel> Atualizar(EnderecoDto produenderecoto, int id);
        Task<bool> Apagar(int id);
    }
}
