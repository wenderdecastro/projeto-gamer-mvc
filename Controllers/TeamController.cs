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
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        //instancia do contexto para acessar o banco de dados

        Context c = new Context();

        [Route("List")] //http://localhost/Team/List
        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Team = c.Team.ToList(); //variavel que armazena equipes do db

            //retorna a view de equipe (TELA)
            return View();
        }

        [Route("Register")]
        public IActionResult Register(IFormCollection form)
        {
            Team newTeam = new Team();

            newTeam.Name = form["Name"].ToString();
            // newTeam.Image = form["Image"].ToString();
            //string

            // newTeam.Image = form["Image"]

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Teams");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //gera o caminho completo at[e o caminho do arquivo(imagem - nome da extensao)
                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                newTeam.Image = file.FileName;
            }
            else
            {
                newTeam.Image = "padrao.png";
            }

            c.Team.Add(newTeam);

            c.SaveChanges();

            return LocalRedirect("~/Team/List");
        }


        [Route("Edit/id")]
        public IActionResult Edit(int id)
        {

            ViewBag.Email = HttpContext.Session.GetString("Email");

            Team foundTeam = c.Team.FirstOrDefault(e => e.Id == id)!;

            ViewBag.Team = foundTeam;

            return View("Edit");

        }

        [Route("Update")]
        public IActionResult Update(IFormCollection form)
        {

            Team newTeam = new Team();

            newTeam.Id = int.Parse(form["Id"].ToString());

            newTeam.Name = form["Name"].ToString();

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Teams");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //gera o caminho completo at[e o caminho do arquivo(imagem - nome da extensao)
                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                newTeam.Image = file.FileName;
            }
            else
            {
                newTeam.Image = "padrao.png";
            }

            Team foundTeam = c.Team.First(x => x.Id == newTeam.Id);

            foundTeam.Name = newTeam.Name;
            foundTeam.Image = newTeam.Image;

            c.Team.Update(foundTeam);

            c.SaveChanges();

            return LocalRedirect("~/Team/List");
        }

        [Route("Delete/id")]
        public IActionResult Delete(int id)
        {

            Team foundTeam = c.Team.First(t => t.Id == id);

            c.Remove(foundTeam);

            c.SaveChanges();

            return LocalRedirect("~/Team/List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}