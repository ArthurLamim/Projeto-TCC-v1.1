using AluguelToten.DTO;
using AluguelToten.Repositorios;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TotenAluguel.Models;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            this._enderecoRepositorio = enderecoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnderecoModel>>> GetEnderecos()
        {
            List<EnderecoModel> enderecos = await _enderecoRepositorio.BuscarTodosEnderecos(); 
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoModel>> BuscarPorId(int id)
        {
            EnderecoModel endereco = await _enderecoRepositorio.BuscarPorId(id);
            return Ok(endereco);
        }

        [HttpPost("post")]
        public async Task<ActionResult<EnderecoModel>> Cadastrar(EnderecoDto enderecoModel)
        {
            EnderecoModel endereco = await _enderecoRepositorio.Adicionar(enderecoModel);
            return Ok(endereco);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<EnderecoModel>> Atualizar(EnderecoDto enderecoModel, int id)
        {
            EnderecoModel endereco = await _enderecoRepositorio.Atualizar(enderecoModel, id);
            return Ok(endereco);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _enderecoRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
