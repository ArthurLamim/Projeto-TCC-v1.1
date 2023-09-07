using AluguelToten.DTO;
using AluguelToten.Repositorios;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TotenAluguel.Models;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelRepositorio _aluguelRepositorio;

        public AluguelController(IAluguelRepositorio aluguelRepositorio)
        {
            this._aluguelRepositorio = aluguelRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AluguelModel>>> GetAlugueis()
        {
            List<AluguelModel> alugueis = await _aluguelRepositorio.BuscarTodosAlugueis();
            return Ok(alugueis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AluguelModel>> BuscarPorId(int id)
        {
            AluguelModel aluguel = await _aluguelRepositorio.BuscarPorId(id);
            return Ok(aluguel);
        }

        [HttpPost("post")]
        public async Task<ActionResult<AluguelModel>> Cadastrar(AluguelDto aluguelModel)
        {
            AluguelModel aluguel = await _aluguelRepositorio.Adicionar(aluguelModel);
            return Ok(aluguel);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<AluguelModel>> Atualizar(AluguelDto aluguelModel, int id)
        {
            AluguelModel aluguel = await _aluguelRepositorio.Atualizar(aluguelModel, id);
            return Ok(aluguel);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _aluguelRepositorio.Apagar(id);
            return Ok(apagado);
        }



    }
}
