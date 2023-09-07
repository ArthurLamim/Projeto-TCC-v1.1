using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly DataContext _dataContext;
        public EnderecoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<EnderecoModel>> BuscarTodosEnderecos()
        {
            return await _dataContext.Enderecos.ToListAsync();
        }
        public async Task<EnderecoModel> BuscarPorId(int id)
        {
            return await _dataContext.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);
        }
        public async Task<EnderecoModel> Adicionar(EnderecoDto endereco)
        {
            EnderecoModel e = new EnderecoModel();
            e.CEP = endereco.CEP;
            e.Pais = endereco.Pais;
            e.Estado = endereco.Estado;
            e.Cidade = endereco.Cidade;
            e.Bairro = endereco.Bairro;
            e.Rua = endereco.Rua;
            e.Numero = endereco.Numero;

            await _dataContext.Enderecos.AddAsync(e);
            await _dataContext.SaveChangesAsync();
            return e;
        }
        public async Task<EnderecoModel> Atualizar(EnderecoDto endereco, int id)
        {
            EnderecoModel enderecoPorId = await BuscarPorId(id);
            if(enderecoPorId == null)
            {
                throw new Exception($"O endereco com o ID: {id} não foi encontrado");
            }
            enderecoPorId.CEP = endereco.CEP;
            enderecoPorId.Pais = endereco.Pais;
            enderecoPorId.Estado = endereco.Estado;
            enderecoPorId.Cidade = endereco.Cidade;
            enderecoPorId.Bairro = endereco.Bairro;
            enderecoPorId.Rua = endereco.Rua;
            enderecoPorId.Numero = endereco.Numero;

            _dataContext.Enderecos.Update(enderecoPorId);
            await _dataContext.SaveChangesAsync();
            return enderecoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            EnderecoModel enderecoPorId = await BuscarPorId(id);
            if (enderecoPorId == null)
            {
                throw new Exception($"O endereco com o ID: {id} não foi encontrado");
            }
            _dataContext.Enderecos.Remove(enderecoPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }

    }
}
