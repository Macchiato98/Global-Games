using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiogoMachadoGlobalGames.Dados;

namespace DiogoMachadoGlobalGames.Controllers
{
    public class ServicosController : Controller
    {
        private readonly DataContext _context;

        public ServicosController(DataContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicos.ToListAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        
        private bool ServicosExists(int id)
        {
            return _context.Servicos.Any(e => e.Id == id);
        }
    }
}
