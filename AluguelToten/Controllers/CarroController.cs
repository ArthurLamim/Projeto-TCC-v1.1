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
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepositorio _carroRepositorio;
        public CarroController(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarroModel>>> GetCarros()
        {
            List<CarroModel> carros = await _carroRepositorio.BuscarTodosCarros();
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarroModel>> BuscarPorId(int id)
        {
            CarroModel carro = await _carroRepositorio.BuscarPorId(id);
            return Ok(carro);
        }

        [HttpPost("post")]
        public async Task<ActionResult<CarroModel>> Cadastrar(CarroDto carroModel)
        {
            CarroModel carro = await _carroRepositorio.Adicionar(carroModel);
            return Ok(carro);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<CarroModel>> Atualizar(CarroDto carroModel, int id)
        {
            CarroModel carro = await _carroRepositorio.Atualizar(carroModel, id);
            return Ok(carro);

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _carroRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
