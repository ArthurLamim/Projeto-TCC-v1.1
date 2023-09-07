using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface IFormaPagamentoRepositorio
    {
        Task<List<FormaPagamento>> BuscarTodosPagamentos();
        Task<FormaPagamento> BuscarPorId(int id);
        Task<FormaPagamento> Adicionar(FormaPagamentoDto formaPagamento);
        Task<FormaPagamento> Atualizar(FormaPagamentoDto formaPagamento, int id);
        Task<bool> Apagar(int id);
    }
}
