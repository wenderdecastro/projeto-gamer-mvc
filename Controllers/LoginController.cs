using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using projeto_gamer.Infra;
using projeto_gamer.Models;

namespace projeto_gamer.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {

        Context c = new Context();

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [TempData]
        public string Message {get; set;}

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {

            string email = form["email"].ToString();
            string password = form["password"].ToString();

            Player foundPlayer = c.Player.First(j => j.Email == email && j.Password == password);

            if (foundPlayer != null)
            {
                HttpContext.Session.SetString("Email", foundPlayer.Email);

                return LocalRedirect("~/");
            }

            Message = "Dados Invalidos!";
            return View();
            


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}