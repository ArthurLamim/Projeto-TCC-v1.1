using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly DataContext _dataContext;

        public FormaPagamentoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<FormaPagamento>> BuscarTodosPagamentos()
        {
            List<FormaPagamento> formaPagamentos = await _dataContext.FormaPagamentos.ToListAsync();
            return formaPagamentos;
        }
        public async Task<FormaPagamento> BuscarPorId(int id)
        {
            return await _dataContext.FormaPagamentos.FirstOrDefaultAsync(pagamento => pagamento.Id == id);
        }
        public async Task<FormaPagamento> Adicionar(FormaPagamentoDto pagamento)
        {
            FormaPagamento f = new FormaPagamento();
            f.tipoFormaPagamento = pagamento.tipoFormaPagamento;

            await _dataContext.FormaPagamentos.AddAsync(f);
            await _dataContext.SaveChangesAsync();
            return f;
        }
        public async Task<FormaPagamento> Atualizar(FormaPagamentoDto formaPagamento, int id)
        {
            FormaPagamento formaPagamentoPorId = await BuscarPorId(id);
            if (formaPagamentoPorId == null)
            {
                throw new Exception($"O compra com o ID: {id} não foi encontrado");
            }
            FormaPagamento f = new FormaPagamento();
            f.tipoFormaPagamento = formaPagamento.tipoFormaPagamento;


            _dataContext.FormaPagamentos.Update(formaPagamentoPorId);
            await _dataContext.SaveChangesAsync();
            return formaPagamentoPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            FormaPagamento formaPagamentoPorId = await BuscarPorId(id);
            if (formaPagamentoPorId == null)
            {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
            _dataContext.FormaPagamentos.Remove(formaPagamentoPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
