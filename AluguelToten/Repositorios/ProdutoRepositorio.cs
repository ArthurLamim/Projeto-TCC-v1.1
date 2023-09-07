using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DataContext _dataContext;
        public ProdutoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dataContext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dataContext.Produtos.FirstOrDefaultAsync(produto => produto.Id == id);
        }

        public async Task<ProdutoModel> Adicionar(ProdutoDto produto)
        {
            
            ProdutoModel p = new ProdutoModel();
            p.nomeProduto = produto.nomeProduto;
            p.precoProduto = produto.precoProduto;
            p.descricaoProduto = produto.descricaoProduto;
            p.quantidadeEstoque = produto.quantidadeEstoque;

            await _dataContext.Produtos.AddAsync(p);
            await _dataContext.SaveChangesAsync();
            return p;
        }
        public async Task<ProdutoModel> Atualizar(ProdutoDto produto, int id)
        {

            ProdutoModel produtoPorId = await BuscarPorId(id);
            if(produtoPorId == null) {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
          
            produtoPorId.nomeProduto = produto.nomeProduto;
            produtoPorId.precoProduto = produto.precoProduto;
            produtoPorId.descricaoProduto = produto.descricaoProduto;
            produtoPorId.quantidadeEstoque = produto.quantidadeEstoque;

            _dataContext.Produtos.Update(produtoPorId);
            await _dataContext.SaveChangesAsync();
            return produtoPorId;
            
        }
        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
            _dataContext.Produtos.Remove(produtoPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        

      
        
    }
}
