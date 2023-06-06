using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projeto_gamer.Infra;
using projeto_gamer.Models;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace projeto_gamer.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {

        Context c = new Context();

        private readonly ILogger<LoginController> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;
        IHttpContextAccessor httpContextAccessor;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("SignIn")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string senha)
        {

            bool Logged = LogUser(email, senha);

            if (Logged)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Email", email);

                return LocalRedirect("~/Team/List");
            }
            else
            {
                return View();
            }

        }


        [Route("LogUser")]
        public bool LogUser(string email, string password)
        {

            Login newLogin = c.Login.First(l => l.Email == email);

            if (newLogin.Email == email && newLogin.Password == password)
            {
                return true;
            }

            return false;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}