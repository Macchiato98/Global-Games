using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DiogoMachadoGlobalGames.Models;
using System.Threading.Tasks;
using System.IO;
using System;
using DiogoMachadoGlobalGames.Dados.Entidades;
using DiogoMachadoGlobalGames.Dados;

namespace GlobalGamesCET50.Controllers
{    
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Servicos()
        {
            return View();
        }

        public IActionResult Inscricoes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apelido,Morada,CC,Localidade,DataNascimento,ImageFile")] InscricoesUploadViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Avatar",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Avatar/{view.ImageFile.FileName}";

                }

                var avatar = this.ToInscricoes(view, path);

                _context.Add(avatar);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Inscricoes ToInscricoes(InscricoesUploadViewModel view, string path)
        {
            return new Inscricoes
            {
                Id = view.Id,
                Nome = view.Nome,
                Apelido = view.Apelido,
                Morada = view.Morada,
                CC = view.CC,
                Localidade = view.Localidade,
                DataNascimento = view.DataNascimento,
                ImageUrl = path,
                /*User = view.User,*/

            };
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
