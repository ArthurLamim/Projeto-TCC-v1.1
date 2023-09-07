using AluguelToten.DTO;
using AluguelToten.Models;
using Microsoft.AspNetCore.Mvc;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface ITotenRepositorio
    {
        Task<List<PosicaoModel>> BuscarPosicaoToten();
        Task<List<AluguelModel>> BuscarTodosAlugueis(int id);
        Task<List<TotenModel>> BuscarTodosTotens();
        Task<TotenModel> BuscarPorId(int id);
        Task<TotenModel> Adicionar(TotenDto toten);
        Task<TotenModel> Atualizar(TotenDto toten, int id);
        Task<bool> Apagar(int id);
    }
}
