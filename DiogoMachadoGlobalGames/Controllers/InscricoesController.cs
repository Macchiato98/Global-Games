using DiogoMachadoGlobalGames.Dados;
using DiogoMachadoGlobalGames.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DiogoMachadoGlobalGames.Controllers
{
    [Authorize]
    public class InscricoesController : Controller
    {

        private readonly DataContext _context;
        private readonly IInscricoesRepository inscricoesRepository;
        private readonly IUserHelper userHelper;

        public InscricoesController(DataContext context, IInscricoesRepository inscricoesRepository, IUserHelper userHelper)
        {
            _context = context;
            this.inscricoesRepository = inscricoesRepository;
            this.userHelper = userHelper;
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
