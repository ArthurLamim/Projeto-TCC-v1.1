using System.Text.Json;
using System.Text.Json.Serialization;
using AluguelToten.DTO;
using AluguelToten.Repositorios;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;


namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("{id}/aluguel")]
        public async Task<ActionResult<AluguelModel>> GetAlugueisDoUsuario(int id)
        {
            var alugueisDoUsuario = await _usuarioRepositorio.ObterAlugueisDoUsuario(id);
            return Ok(alugueisDoUsuario);
        }

       
        [HttpGet("{id}/carros")]
        public async Task<ActionResult<CarroModel>> GetCarrosDoUsuario(int id )
        {
            var carrosDoUsuario = await _usuarioRepositorio.ObterCarrosDoUsuario(id); 
            return Ok(carrosDoUsuario);
        }

        
        [HttpGet("{id}/compras")]
        public async Task<ActionResult<CompraModel>> GetComprasDoUsuario(int id)
        {
            var comprasDoUsuario = await _usuarioRepositorio.BuscarComprasDoUsuario(id);
            return Ok(comprasDoUsuario);
        }

        
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return (usuario);
        }

        
        [HttpPost("post")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar(UsuarioDto usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        
        [HttpPut("update/{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(UsuarioDto usuarioModel, int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }



    }
}
