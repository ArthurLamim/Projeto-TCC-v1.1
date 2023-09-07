
using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class AluguelRepositorio : IAluguelRepositorio
    {
        private readonly DataContext _dataContext;
        public AluguelRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AluguelModel>> BuscarTodosAlugueis()
        {
            return await _dataContext.Aluguel
                .Include(a => a.Carro)
                .Include(a => a.FormaPagamento)
                
                .Include(a => a.Toten)
                .ToListAsync();
        }

        public async Task<AluguelModel> BuscarPorId(int id)
        {
            return await _dataContext.Aluguel
                .Include(a => a.Carro)
                .Include(a => a.FormaPagamento)
               
                .Include(a => a.Toten)
                .FirstOrDefaultAsync(aluguel => aluguel.Id == id);
        }

        public async Task<AluguelModel> Adicionar(AluguelDto aluguel)
        {
            AluguelModel a = new AluguelModel();
            a.QtdVoltzUsada = aluguel.QtdVoltzUsada;
            a.Data = aluguel.Data;
            a.HorarioInicio = aluguel.HorarioInicio;
            a.HorarioFim = aluguel.HorarioFim;
            a.PrecoFinal = aluguel.PrecoFinal;
            a.Finalizado = aluguel.Finalizado;
            a.CarroId = aluguel.CarroId;
            a.FormaPagamentoId = aluguel.FormaPagamentoId;
            a.TotenId = aluguel.TotenId;
            a.UsuarioId = aluguel.UsuarioId;

            await _dataContext.Aluguel.AddAsync(a);
            await _dataContext.SaveChangesAsync();
            return a;
        }

        public async Task<AluguelModel> Atualizar(AluguelDto aluguel, int id)
        {
            AluguelModel aluguelPorId = await BuscarPorId(id);
            if (aluguelPorId == null)
            {
                throw new Exception($"O aluguel com o ID: {id} não foi encontrado");
            }
            aluguelPorId.QtdVoltzUsada = aluguel.QtdVoltzUsada;
            aluguelPorId.Data = aluguel.Data;
            aluguelPorId.HorarioInicio = aluguel.HorarioInicio;
            aluguelPorId.HorarioFim = aluguel.HorarioFim;
            aluguelPorId.PrecoFinal = aluguel.PrecoFinal;
            aluguelPorId.Finalizado = aluguel.Finalizado;

            _dataContext.Aluguel.Update(aluguelPorId);
            await _dataContext.SaveChangesAsync();
            return aluguelPorId;

        }

        public async Task<bool> Apagar(int id)
        {
            AluguelModel aluguelPorId = await BuscarPorId(id);
            if (aluguelPorId == null)
            {
                throw new Exception($"O aluguel com o ID: {id} não foi encontrado");
            }
            _dataContext.Aluguel.Remove(aluguelPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }


    }
}
