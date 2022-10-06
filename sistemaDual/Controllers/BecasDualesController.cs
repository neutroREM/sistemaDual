using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;

namespace sistemaDual.Controllers
{
    public class BecasDualesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public BecasDualesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: BecaDuals
        public async Task<IActionResult> Index()
        {
              return View(await _context.BecasDuales.ToListAsync());
        }

        // GET: BecaDuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BecasDuales == null)
            {
                return NotFound();
            }

            var becaDual = await _context.BecasDuales
                .FirstOrDefaultAsync(m => m.BecaDUalID == id);
            if (becaDual == null)
            {
                return NotFound();
            }

            return View(becaDual);
        }

        // GET: BecaDuals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BecaDuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BecaDUalID,Fuente,TipoBeca,Periocidad,Duracion")] BecaDualViewModel model)
        {
            if (ModelState.IsValid)
            {
                var becaD = new BecaDual()
                {
                    BecaDUalID = model.BecaDUalID,
                    Fuente = model.Fuente,
                    TipoBeca = model.TipoBeca,
                    Periocidad = model.Periocidad,
                    Duracion = model.Duracion,
                };
                _context.Add(becaD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: BecaDuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BecasDuales == null)
            {
                return NotFound();
            }

            var becaDual = await _context.BecasDuales.FindAsync(id);
            if (becaDual == null)
            {
                return NotFound();
            }
            return View(becaDual);
        }

        // POST: BecaDuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BecaDUalID,Fuente,TipoBeca,Periocidad,Duracion")] BecaDual becaDual)
        {
            if (id != becaDual.BecaDUalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(becaDual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BecaDualExists(becaDual.BecaDUalID))
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
            return View(becaDual);
        }

        // GET: BecaDuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BecasDuales == null)
            {
                return NotFound();
            }

            var becaDual = await _context.BecasDuales
                .FirstOrDefaultAsync(m => m.BecaDUalID == id);
            if (becaDual == null)
            {
                return NotFound();
            }

            return View(becaDual);
        }

        // POST: BecaDuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BecasDuales == null)
            {
                return Problem("Entity set 'ProgramaDualContext.BecasDuales'  is null.");
            }
            var becaDual = await _context.BecasDuales.FindAsync(id);
            if (becaDual != null)
            {
                _context.BecasDuales.Remove(becaDual);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BecaDualExists(int id)
        {
          return _context.BecasDuales.Any(e => e.BecaDUalID == id);
        }
    }
}
