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
    public class ticherController : Controller
    {
        private readonly EscuelaContext _context;

        public ticherController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: ticher
        public async Task<IActionResult> Index()
        {
              return _context.tichers != null ? 
                          View(await _context.tichers.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.tichers'  is null.");
        }

        // GET: ticher/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.tichers == null)
            {
                return NotFound();
            }

            var ticher = await _context.tichers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticher == null)
            {
                return NotFound();
            }

            return View(ticher);
        }

        // GET: ticher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ticher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("email,pass,Permices,Id,name")] ticher ticher)
        {
            if (ModelState.IsValid)
            {
                ticher.Id = Guid.NewGuid();
                _context.Add(ticher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticher);
        }

        // GET: ticher/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.tichers == null)
            {
                return NotFound();
            }

            var ticher = await _context.tichers.FindAsync(id);
            if (ticher == null)
            {
                return NotFound();
            }
            return View(ticher);
        }

        // POST: ticher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("email,pass,Permices,Id,name")] ticher ticher)
        {
            if (id != ticher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ticherExists(ticher.Id))
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
            return View(ticher);
        }

        // GET: ticher/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.tichers == null)
            {
                return NotFound();
            }

            var ticher = await _context.tichers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticher == null)
            {
                return NotFound();
            }

            return View(ticher);
        }

        // POST: ticher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.tichers == null)
            {
                return Problem("Entity set 'EscuelaContext.tichers'  is null.");
            }
            var ticher = await _context.tichers.FindAsync(id);
            if (ticher != null)
            {
                _context.tichers.Remove(ticher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ticherExists(Guid id)
        {
          return (_context.tichers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
