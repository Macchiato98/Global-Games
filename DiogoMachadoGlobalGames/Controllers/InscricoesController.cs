using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiogoMachadoGlobalGames.Dados;
using DiogoMachadoGlobalGames.Dados.Entidades;
using DiogoMachadoGlobalGames.Models;
using System.IO;
using System;

namespace DiogoMachadoGlobalGames.Controllers
{
    public class InscricoesController : Controller
    {
        
        private readonly DataContext _context;
        private readonly IInscricoesRepository inscricoesRepository;

        public InscricoesController(DataContext context, IInscricoesRepository inscricoesRepository)
        {
            _context = context;
            this.inscricoesRepository = inscricoesRepository;

        }

        
        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Incricoes.ToListAsync());
        }

        // GET: Inscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Incricoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }
            
        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricoes = await _context.Incricoes.FindAsync(id);
            _context.Incricoes.Remove(inscricoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricoesExists(int id)
        {
            return _context.Incricoes.Any(e => e.Id == id);
        }
    }
}
