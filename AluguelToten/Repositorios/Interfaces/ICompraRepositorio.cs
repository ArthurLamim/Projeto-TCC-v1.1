using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface ICompraRepositorio
    {
        Task<List<CompraModel>> BuscarTodasCompras();
        Task<CompraModel> BuscarPorId(int id);
        Task<CompraModel> Adicionar(CompraDto compra);
        Task<CompraModel> Atualizar(CompraDto compra, int id);
        Task<bool> Apagar(int id);
    }
}
