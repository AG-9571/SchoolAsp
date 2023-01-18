using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.Models;

namespace school.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly EscuelaContext _context;

        public EvaluacionesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Evaluaciones
        public async Task<IActionResult> Index()
        {
              return _context.Evaluaciones != null ? 
                          View(await _context.Evaluaciones.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.Evaluaciones'  is null.");
        }

        // GET: Evaluaciones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluaciones = await _context.Evaluaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            return View(evaluaciones);
        }

        // GET: Evaluaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("promedio,Nota,Id,name")] Evaluaciones evaluaciones)
        {
            if (ModelState.IsValid)
            {
                evaluaciones.Id = Guid.NewGuid();
                _context.Add(evaluaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluaciones);
        }

        // GET: Evaluaciones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluaciones = await _context.Evaluaciones.FindAsync(id);
            if (evaluaciones == null)
            {
                return NotFound();
            }
            return View(evaluaciones);
        }

        // POST: Evaluaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("promedio,Nota,Id,name")] Evaluaciones evaluaciones)
        {
            if (id != evaluaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionesExists(evaluaciones.Id))
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
            return View(evaluaciones);
        }

        // GET: Evaluaciones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Evaluaciones == null)
            {
                return NotFound();
            }

            var evaluaciones = await _context.Evaluaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            return View(evaluaciones);
        }

        // POST: Evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Evaluaciones == null)
            {
                return Problem("Entity set 'EscuelaContext.Evaluaciones'  is null.");
            }
            var evaluaciones = await _context.Evaluaciones.FindAsync(id);
            if (evaluaciones != null)
            {
                _context.Evaluaciones.Remove(evaluaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionesExists(Guid id)
        {
          return (_context.Evaluaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
