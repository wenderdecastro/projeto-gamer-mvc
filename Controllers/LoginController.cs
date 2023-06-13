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
        public string Message { get; set; }

        [Route("Login")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [Route("SignIn")]
        public IActionResult Login(IFormCollection form)
        {

            string email = form["Email"].ToString();
            string password = form["Password"].ToString();

            Player foundPlayer = c.Player.First(j => j.Email == email && j.Password == password);

            if (foundPlayer != null)
            {
                HttpContext.Session.SetString("UserName", foundPlayer.Name);

                return LocalRedirect("~/");
            }
            else
            {
                Message = "Dados Invalidos!";
                return LocalRedirect("~/Login/Login");

            }


        }

        [Route("Logout")]
        public IActionResult SignOff()
        {

            HttpContext.Session.Remove("UserName");

            return LocalRedirect("~/");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}