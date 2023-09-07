using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace TotenAluguel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            this._produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> GetProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);

        }

        [HttpPost("post")]
        public async Task<ActionResult<ProdutoModel>> Cadastrar(ProdutoDto produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar(ProdutoDto produtoModel, int id)
        {
            
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
