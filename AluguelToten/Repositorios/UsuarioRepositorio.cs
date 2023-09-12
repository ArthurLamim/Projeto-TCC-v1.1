using System.Text.Json;
using System.Text.Json.Serialization;
using AluguelToten.DTO;
using AluguelToten.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;
using System.Linq;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AluguelToten.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _dataContext;
        private readonly JsonSerializerOptions _jsonOptions;
        public UsuarioRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<CarroModel>> ObterCarrosDoUsuario(int id)
        {
            var carrosDoUsuario = await _dataContext.UsuarioCarros.Where(uc => uc.UsuarioId == id).Include(uc => uc.Carro).Select(uc => uc.Carro).ToListAsync();
            if (carrosDoUsuario == null)
            {
                throw new NotImplementedException($"Os Carros do usuario com o ID: {id} não forãm encontrados"); // Retorna 404 Not Found caso o usuário não seja encontrado
            }
            return carrosDoUsuario;
        }
        public async Task<List<AluguelModel>> ObterAlugueisDoUsuario(int id)
        {
            var alugueisDoUsuario = await _dataContext.Aluguel.Where(a => a.UsuarioId == id).Include(a => a.Toten).Include(a => a.FormaPagamento).ToListAsync();
            return alugueisDoUsuario;
        }
        public async Task<List<CompraModel>> BuscarComprasDoUsuario(int id)
        {
            var comprasDoUsuario = await _dataContext.Compras.Where(c => c.UsuarioId == id).Include(c => c.ProdutoModel).Include(c => c.FormaPagamento).ToListAsync();
            return comprasDoUsuario;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dataContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            var usuario = _dataContext.Usuarios
            
            .FirstOrDefault(u => u.Id == id);
            return usuario;
        }
        public async Task<UsuarioModel> Adicionar(UsuarioDto usuario)
        {
            UsuarioModel u = new UsuarioModel();
            u.nomeUsuario = usuario.nomeUsuario;
            u.CPFUsuario = usuario.CPFUsuario;
            u.dataNascimento = usuario.dataNascimento;
            u.emailUsuario = usuario.emailUsuario;
            //u.senhaUsuario = usuario.senhaUsuario;
           


            await _dataContext.Usuarios.AddAsync(u);
            await _dataContext.SaveChangesAsync();
            return u;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioDto usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null) {
                throw new Exception($"O Usuário com o ID: {id} não foi encontrado");
            }
            usuarioPorId.nomeUsuario = usuario.nomeUsuario;
            usuarioPorId.CPFUsuario = usuario.CPFUsuario;
            usuarioPorId.dataNascimento = usuario.dataNascimento;
            usuarioPorId.emailUsuario = usuario.emailUsuario;
           // usuarioPorId.senhaUsuario = usuario.senhaUsuario;

            _dataContext.Usuarios.Update(usuarioPorId);
            await _dataContext.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"O produto com o ID: {id} não foi encontrado");
            }
            _dataContext.Usuarios.Remove(usuarioPorId);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> UsuarioByToken(string token)
        {
           
            string jwtToken = token;        
            string chaveSecreta = "0013812738usaidaASIUDHGuia!&¨@#*!@asdhasdi"; 
            var tokenHandler = new JwtSecurityTokenHandler();

            // Configure a validação do JWT
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // Defina como true se desejar validar o emissor (issuer)
                ValidateAudience = false, // Defina como true se desejar validar a audiência (audience)
                ValidateLifetime = true, // Defina como true se desejar validar a validade do token
                ValidateIssuerSigningKey = true, // Defina como true se desejar validar a assinatura
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta)), 
            };

            SecurityToken validatedToken;

          
                // Verifique o JWT
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out _);

                // Acesse o valor do campo "email" da payload
                string email = claimsPrincipal.FindFirst("email")?.Value;

                if (!string.IsNullOrEmpty(email))
                {
                    Console.WriteLine($"Email: {email}");
                }
                else
                {
                    Console.WriteLine("Campo 'email' não encontrado na payload.");
                }
               UsuarioModel usuario =  await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.emailUsuario == email);
                return usuario;
           

        }
    }
}

