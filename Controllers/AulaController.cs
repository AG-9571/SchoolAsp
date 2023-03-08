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
    public class AulaController : Controller
    {
        private readonly EscuelaContext _context;

        public AulaController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Aula
        public async Task<IActionResult> Index()
        {
              return _context.Aulas != null ? 
                          View(await _context.Aulas.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.Aulas'  is null.");
        }

        // GET: Aula/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .FirstOrDefaultAsync(m => m.AulaId == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // GET: Aula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AulaId,desctiption,Jornada,and,end,Dirección,Id,name")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                aula.AulaId = Guid.NewGuid();
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aula);
        }

        // GET: Aula/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            return View(aula);
        }

        // POST: Aula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AulaId,desctiption,Jornada,and,end,Dirección,Id,name")] Aula aula)
        {
            if (id != aula.AulaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.AulaId))
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
            return View(aula);
        }

        // GET: Aula/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .FirstOrDefaultAsync(m => m.AulaId == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Aulas == null)
            {
                return Problem("Entity set 'EscuelaContext.Aulas'  is null.");
            }
            var aula = await _context.Aulas.FindAsync(id);
            if (aula != null)
            {
                _context.Aulas.Remove(aula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(Guid id)
        {
          return (_context.Aulas?.Any(e => e.AulaId == id)).GetValueOrDefault();
        }
    }
}
