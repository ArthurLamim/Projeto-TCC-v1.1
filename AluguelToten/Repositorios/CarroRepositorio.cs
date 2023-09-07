using AluguelToten.Controllers;
using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly DataContext _dataContext;
        public CarroRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<CarroModel>> BuscarTodosCarros()
        {
            return await _dataContext.Carros.ToListAsync();
        }

        public async Task<CarroModel> BuscarPorId(int id)
        {
            return await _dataContext.Carros.FirstOrDefaultAsync(carro => carro.Id == id);
        }

        public async Task<CarroModel> Adicionar(CarroDto carro)
        {
            CarroModel c = new CarroModel();
            c.Marca = carro.Marca;
            c.Modelo = carro.Modelo;
            c.mABateria = carro.mABateria;
            c.tipoConector = carro.tipoConector;
            c.cargaAtual = carro.cargaAtual;

            await _dataContext.Carros.AddAsync(c);
            await _dataContext.SaveChangesAsync();
            return c;
        }

        public async Task<CarroModel> Atualizar(CarroDto carro, int id)
        {
            CarroModel carroPorId = await BuscarPorId(id);
            if(carroPorId == null)
            {
                throw new Exception($"O carro com o ID: {id} não foi encontrado");
            }
            
            carroPorId.Marca = carro.Marca;
            carroPorId.Modelo = carro.Modelo;
            carroPorId.tipoConector = carro.tipoConector;
            carroPorId.mABateria = carro.mABateria;
            carroPorId.cargaAtual = carro.cargaAtual;

            _dataContext.Carros.Update(carroPorId);
            await _dataContext.SaveChangesAsync();
            return carroPorId;

        }

        public async Task<bool> Apagar(int id)
        {
            CarroModel carroPorId = await BuscarPorId(id);
            if (carroPorId == null)
            {
                throw new Exception($"O carro com o ID: {id} não foi encontrado");
            }
            _dataContext.Carros.Remove(carroPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }


    }
}
