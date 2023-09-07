using AluguelToten.DTO;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface ICarroRepositorio
    {
        Task<List<CarroModel>> BuscarTodosCarros();
        Task<CarroModel> BuscarPorId(int id);
        Task<CarroModel> Adicionar(CarroDto carro);
        Task<CarroModel> Atualizar(CarroDto carro, int id);
        Task<bool> Apagar(int id);
       
    }
}
