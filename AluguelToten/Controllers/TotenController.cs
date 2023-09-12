using AluguelToten.DTO;
using AluguelToten.Models;
using AluguelToten.Repositorios;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotenController : ControllerBase
    {
        private readonly ITotenRepositorio _totenRepoitorio;
        private readonly DataContext _dataContext;

        public TotenController(ITotenRepositorio totenRepoitorio, DataContext dataContext)
        {
            _totenRepoitorio = totenRepoitorio;
            _dataContext = dataContext;
        }

        [HttpGet("posicao")]
        public async Task<ActionResult<List<PosicaoModel>>> GetPosicaoToten()
        {
            List<PosicaoModel> posicaoTotens = await _totenRepoitorio.BuscarPosicaoToten();
            return Ok(posicaoTotens);
        }
            

        [HttpGet("{id}/alugueis")]
        public async Task<ActionResult<AluguelModel>> GetAlugueisToten(int id)
        {
            var alugueisDoToten = await _totenRepoitorio.BuscarTodosAlugueis(id);
            return Ok(alugueisDoToten);
        }

        [HttpGet]
        public async Task<ActionResult<List<TotenModel>>> GetTotens()
        {
            List<TotenModel> totens = await _totenRepoitorio.BuscarTodosTotens();
            return Ok(totens);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TotenModel>> BuscarPorId(int id)
        {
            TotenModel toten = await _totenRepoitorio.BuscarPorId(id);
            return Ok(toten);
        }

        [HttpPost("post")]
        public async Task<ActionResult<TotenModel>> Cadastrar(TotenDto TotenModel)
        {
            TotenModel toten = await _totenRepoitorio.Adicionar(TotenModel);
            return Ok(toten);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<TotenModel>> Atualizar(TotenDto TotenModel, int id)
        {
            TotenModel toten = await _totenRepoitorio.Atualizar(TotenModel, id);
            return Ok(toten);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _totenRepoitorio.Apagar(id);
            return Ok(apagado);
        }

        [HttpGet("BuscarPorEndereco")]
        public IActionResult BuscarTotensPorTexto([FromQuery] string texto = null)
        {
            try
            {
                int teste = 0;
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    try
                    {
                        teste = int.Parse(texto);
                    }
                    catch { }
                }

                // Defina a consulta base sem incluir o relacionamento
                var totensQuery = _dataContext.Totens.AsQueryable();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    // Aplica os filtros
                    totensQuery = totensQuery.Where(t => t.EnderecoModel.Rua.Contains(texto) ||
                                                        t.EnderecoModel.Cidade.Contains(texto) ||
                                                        t.EnderecoModel.Bairro.Contains(texto) ||
                                                        t.EnderecoModel.CEP == teste);
                }

                // Inclui o relacionamento com EnderecoModel
                totensQuery = totensQuery.Include(t => t.EnderecoModel);

                var totens = totensQuery.ToList();

                return Ok(totens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


    }
}
