using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TotenAluguel.Models;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public FormaPagamentoController(IFormaPagamentoRepositorio FormaPagamentoRepositorio)
        {
            this._formaPagamentoRepositorio = FormaPagamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormaPagamento>>> GetPagamentos()
        {
            List<FormaPagamento> pagamentos = await _formaPagamentoRepositorio.BuscarTodosPagamentos();
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPagamento>> BuscarPorId(int id)
        {
            FormaPagamento pagamento = await _formaPagamentoRepositorio.BuscarPorId(id);
            return Ok(pagamento);
        }

        [HttpPost("post")]
        public async Task<ActionResult<FormaPagamento>> Cadastrar(FormaPagamentoDto formaPagamento)
        {
            FormaPagamento pagamento = await _formaPagamentoRepositorio.Adicionar(formaPagamento);
            return Ok(pagamento);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<FormaPagamento>> Atualizar(FormaPagamentoDto formaPagamento, int id)
        {
            FormaPagamento pagamento = await _formaPagamentoRepositorio.Atualizar(formaPagamento, id);
            return Ok(pagamento);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _formaPagamentoRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
