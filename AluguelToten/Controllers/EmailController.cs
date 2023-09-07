using AluguelToten.Services;
using Microsoft.AspNetCore.Mvc;


namespace AluguelToten.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {

            this._emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO email){
            _emailService.SendEmail(email);
            return Ok();
        }

    }
}
