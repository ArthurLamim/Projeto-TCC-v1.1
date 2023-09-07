
using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace Aluguelcompra.Repositorios
{
    public class CompraRepositorio : ICompraRepositorio
    {
        private readonly DataContext _dataContext;

        public CompraRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<CompraModel>> BuscarTodasCompras()
        {
            return await _dataContext.Compras
                .Include(c => c.UsuarioModel)
                
                .Include(c => c.ProdutoModel)
                .Include(c => c.FormaPagamento)
                .ToListAsync();
        }
        public async Task<CompraModel> BuscarPorId(int id)
        {
            return await _dataContext.Compras
                .Include(c => c.UsuarioModel)
                .Include(c => c.ProdutoModel)
                .Include(c => c.FormaPagamento)
                .FirstOrDefaultAsync(compra => compra.Id == id);
        }
        public async Task<CompraModel> Adicionar(CompraDto compra)
        {
            

            CompraModel c = new CompraModel();
            c.quantidadeProduto = compra.quantidadeProduto;
            c.precoFinal = compra.precoFinal;
            c.dataCompra = compra.dataCompra;
            c.ProdutoId = compra.ProdutoId;
            c.FormaPagamentoId = compra.FormaPagamentoId;
            c.UsuarioId = compra.UsuarioId;
            

            await _dataContext.Compras.AddAsync(c);
            await _dataContext.SaveChangesAsync();
            return c;
        }
        public async Task<CompraModel> Atualizar(CompraDto compra, int id)
        {
            CompraModel compraPorId = await BuscarPorId(id);
            if (compraPorId == null)
            {
                throw new Exception($"O compra com o ID: {id} não foi encontrado");
            }
            CompraModel t = new CompraModel();
            compraPorId.quantidadeProduto = compra.quantidadeProduto;
            compraPorId.precoFinal = compra.precoFinal;
            compraPorId.dataCompra = compra.dataCompra;
          

            _dataContext.Compras.Update(compraPorId);
            await _dataContext.SaveChangesAsync();
            return compraPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            CompraModel compraPorId = await BuscarPorId(id);
            if (compraPorId == null)
            {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
            _dataContext.Compras.Remove(compraPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
