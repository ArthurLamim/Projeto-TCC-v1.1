using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AluguelToten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TotenAluguel.Data;

namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataContext _dataContext;

        public LoginController(IConfiguration configuration,
                               SignInManager<IdentityUser> signInManager, DataContext dataContext)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            

            if (!result.Succeeded) return BadRequest(new LoginResult
            {
                Successful = false,
                Error = "Usuario ou senha inválidos"
            });

            var user = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.emailUsuario == login.Email);
            user.IsAuthenticated = true;

            _dataContext.Usuarios.Update(user);
            await _dataContext.SaveChangesAsync();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Jwt:JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:JwtIssuer"],
                _configuration["Jwt:JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        /*public async Task<UsuarioModel> Authenticate(string email, string senha)
        {
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.emailUsuario == email);

            // Verificar se o usuário foi encontrado
            if (usuario == null)
            {
                return null; // Credenciais inválidas
            }


            return usuario; // Autenticação bem-sucedida, retorna o usuário
        }*/

        /*[HttpPost("login")]
    public async Task<ActionResult<string>> Login(UsuarioDto usuarioDto)
{
    // Verificar as credenciais do usuário no banco de dados
    var usuario = await _usuarioRepositorio.Authenticate(usuarioDto.emailUsuario, usuarioDto.senhaUsuario);
    if (usuario == null)
    {
        return Unauthorized(); // 401 Unauthorized
    }

    // Autenticação bem-sucedida, gere o token JWT
    var token = _authService.GenerateJwtToken(usuario);
    return Ok(token);
}*/
        /*public async Task<UsuarioModel> Adicionar(UsuarioDto usuario)
        {
            UsuarioModel u = new UsuarioModel();
            u.nomeUsuario = usuario.nomeUsuario;
            u.CPFUsuario = usuario.CPFUsuario;
            u.dataNascimento = usuario.dataNascimento;
            u.emailUsuario = usuario.emailUsuario;
            u.EnderecoId = usuario.EnderecoId;

            // Criar o hash e salt da senha
            CreatePasswordHash(usuario.senhaUsuario, out byte[] passwordHash, out byte[] passwordSalt);
            u.PasswordHash = passwordHash;
            u.PasswordSalt = passwordSalt;

            await _dataContext.Usuarios.AddAsync(u);
            await _dataContext.SaveChangesAsync();
            return u;
        }

        private void CreatePasswordHash(string senha, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public async Task<UsuarioModel> Authenticate(string email, string senha)
        {
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.emailUsuario == email);

            // Verificar se o usuário foi encontrado
            if (usuario == null)
            {
                return null; // Credenciais inválidas
            }

            // Verificar a senha utilizando o método VerifyPasswordHash
            if (!VerifyPasswordHash(senha, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return null; // Credenciais inválidas
            }

            return usuario; // Autenticação bem-sucedida, retorna o usuário
        }

        private bool VerifyPasswordHash(string senha, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true; // A senha é válida
        }*/

    }
}
