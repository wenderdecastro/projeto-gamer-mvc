using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projeto_gamer.Infra;
using projeto_gamer.Models;

namespace projeto_gamer.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();


        [Route("List")] //http://localhost/Team/List
        public IActionResult Index()
        {
           ViewBag.Player = c.Player.ToList();
            ViewBag.Team = c.Team.ToList(); //variavel que armazena equipes e players do db

            //retorna a view de equipe (TELA)
            return View();
        }

        [Route("Register")]
        public IActionResult Register(IFormCollection form)
        {
            Player newPlayer = new Player();

            newPlayer.Name = form["Name"].ToString();

            newPlayer.Email = form["Email"].ToString();

            newPlayer.Password = form["Password"].ToString();

            c.Player.Add(newPlayer);

            c.SaveChanges();

            return LocalRedirect("~/Player/List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}