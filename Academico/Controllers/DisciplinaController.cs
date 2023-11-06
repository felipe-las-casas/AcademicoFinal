using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly AcademicoContext _context;

        public DisciplinaController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: disciplina
        public async Task<IActionResult> Index()
        {
            return _context.Disciplinas != null ?
            View(await _context.Disciplinas.ToListAsync()) :
            Problem("Entity set 'AcademicoContext.Disciplinas'  is null.");
        }

        // GET: disciplina/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.Include(d => d.CursosDisciplinas)
                .SingleOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: disciplina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: disciplina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CargaHoraria")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // GET: disciplina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        // POST: disciplina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DisciplinaId,Nome,CargaHoraria")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(disciplina);
        }

        // GET: disciplina/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Disciplinas == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Disciplinas == null)
            {
                return Problem("Entity set 'AcademicoContext.Disciplinas' is null.");
            }

            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(long? id)
        {
            return (_context.Disciplinas?.Any(e => e.DisciplinaId == id)).GetValueOrDefault();
        }
    }
}