using AluguelToten.Models;
using AluguelToten.Repositorios.Interfaces;
using AluguelToten.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Data;
using TotenAluguel.Models;


namespace AluguelToten.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private static UsuarioModel LoggedOutUser = new UsuarioModel { IsAuthenticated = false };

        private readonly IEmailService _emailService;
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        
        public AcessoController(UserManager<IdentityUser> userManager, DataContext dataContext, IEmailService emailService)
        {
            _userManager = userManager;
            _dataContext = dataContext;
            _emailService = emailService;
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }


            var usuario = new UsuarioModel
            {
                CPFUsuario = model.CPFUsuario,
                nomeUsuario = model.nomeUsuario,
                CustomIdentityUserId = newUser.Id,
                
                emailUsuario = newUser.Email,   
                dataNascimento = model.dataNascimento
                // Preencha outras propriedades personalizadas se necessário
            };
            

                _dataContext.Usuarios.Add(usuario);
                await _dataContext.SaveChangesAsync();

            EmailDTO email = new EmailDTO();

            email.To = model.Email;
            email.Body = "Conta criada com sucesso!" + " Bem vindo, " + model.nomeUsuario;
            email.Subject = "Boas Vindas ao" + model.nomeUsuario;
            _emailService.SendEmail(email);

            return Ok(new RegisterResult { Successful = true });
        }
    }
}
