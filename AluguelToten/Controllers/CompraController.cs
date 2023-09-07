using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TotenAluguel.Models;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepositorio _compraRepositorio;

        public CompraController(ICompraRepositorio compraRepositorio)
        {
            this._compraRepositorio = compraRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompraModel>>> Getcompras()
        {
            List<CompraModel> compras = await _compraRepositorio.BuscarTodasCompras();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraModel>> BuscarPorId(int id)
        {
            CompraModel compra = await _compraRepositorio.BuscarPorId(id);
            return Ok(compra);
        }

        [HttpPost("/post")]
        public async Task<ActionResult<CompraModel>> Cadastrar(CompraDto compraModel)
        {
            CompraModel compra = await _compraRepositorio.Adicionar(compraModel);
            return Ok(compra);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CompraModel>> Atualizar(CompraDto compraModel, int id)
        {
            CompraModel compra = await _compraRepositorio.Atualizar(compraModel, id);
            return Ok(compra);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _compraRepositorio.Apagar(id);
            return Ok(apagado);
        }



    }
}
