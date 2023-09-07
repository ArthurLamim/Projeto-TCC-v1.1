using AluguelToten.DTO;
using AluguelToten.Models;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class TotenRepositorio : ITotenRepositorio
    {
        private readonly DataContext _dataContext;

        public TotenRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PosicaoModel>> BuscarPosicaoToten()
        {
            List<TotenModel> totens = await BuscarTodosTotens();
            List<PosicaoModel> posicoes = new List<PosicaoModel>();
            foreach (TotenModel toten in totens)
            {
                PosicaoModel posicao = new PosicaoModel();
                posicao.Lat = toten.Lat;
                posicao.Lng = toten.Lng;
                posicao.Id = toten.Id;
                posicoes.Add(posicao);
            }
            return posicoes;

        }

        public async Task<List<AluguelModel>> BuscarTodosAlugueis(int id)
        {
            var alugueisDoToten = await _dataContext.Aluguel.Where(a => a.TotenId == id).Include(a => a.Usuario).ToListAsync();
            return alugueisDoToten;
        }

        public async Task<List<TotenModel>> BuscarTodosTotens()
        {
            return await _dataContext.Totens.ToListAsync();
        }
        public async Task<TotenModel> BuscarPorId(int id)
        {
            return await _dataContext.Totens.Include(t => t.EnderecoModel).FirstOrDefaultAsync(toten => toten.Id == id);
        }
        public async Task<TotenModel> Adicionar(TotenDto toten)
        {
            TotenModel t = new TotenModel();
            t.tipoConector = toten.tipoConector;
            t.cargaUsada = toten.cargaUsada;
            t.tempoUso = toten.tempoUso;
            t.disponivel = toten.disponivel;
            t.voltPorMinuto = toten.voltPorMinuto;
            t.precoVoltagem = toten.precoVoltagem;
            t.Lat = toten.Lat;
            t.Lng = toten.Lng;

            await _dataContext.Totens.AddAsync(t);
            await _dataContext.SaveChangesAsync();
            return t;
        }
        public async Task<TotenModel> Atualizar(TotenDto toten, int id)
        {
            TotenModel totenPorId = await BuscarPorId(id);
            if (totenPorId == null)
            {
                throw new Exception($"O toten com o ID: {id} não foi encontrado");
            }
            TotenModel t = new TotenModel();
            totenPorId.tipoConector = toten.tipoConector;
            totenPorId.cargaUsada = toten.cargaUsada;
            totenPorId.tempoUso = toten.tempoUso;
            totenPorId.disponivel = toten.disponivel;
            totenPorId.voltPorMinuto = toten.voltPorMinuto;
            totenPorId.precoVoltagem = toten.precoVoltagem;
            totenPorId.Lat = toten.Lat;
            totenPorId.Lng = toten.Lng;

            _dataContext.Totens.Update(totenPorId);
            await _dataContext.SaveChangesAsync();
            return totenPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            TotenModel totenPorId = await BuscarPorId(id);
            if (totenPorId == null)
            {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
            _dataContext.Totens.Remove(totenPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }

       

       

        
    }
}
