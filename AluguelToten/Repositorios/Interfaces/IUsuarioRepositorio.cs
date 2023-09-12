using AluguelToten.DTO;
using Microsoft.AspNetCore.Mvc;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        
        Task<List<AluguelModel>> ObterAlugueisDoUsuario(int id);
        Task<List<CarroModel>> ObterCarrosDoUsuario(int id);
        Task<List<CompraModel>> BuscarComprasDoUsuario(int id);
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioDto carro);
        Task<UsuarioModel> Atualizar(UsuarioDto carro, int id);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> UsuarioByToken(string token);
    }
}
