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
    public class UniversidadesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public UniversidadesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: Universidades
        public async Task<IActionResult> Index()
        {
              return View(await _context.Universidades.ToListAsync());
        }

        // GET: Universidades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades
                .FirstOrDefaultAsync(m => m.UniversidadID == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // GET: Universidades/Create
        public IActionResult Create()
        {
            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversidadID,NombreU")] UniversidadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uni = new Universidad()
                {
                    UniversidadID = model.UniversidadID,
                    NombreU = model.NombreU
                };
               
                _context.Add(uni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Universidades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }

        // POST: Universidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UniversidadID,NombreU")] UniversidadViewModel viewModel)
        {
            if (id != viewModel.UniversidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editUni = new Universidad()
                    {
                        UniversidadID = viewModel.UniversidadID,
                        NombreU = viewModel.NombreU
                    };
                    _context.Update(editUni);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadExists(viewModel.UniversidadID))
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
            return View(viewModel);
        }

        // GET: Universidades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades
                .FirstOrDefaultAsync(m => m.UniversidadID == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Universidades == null)
            {
                return Problem("Entity set 'ProgramaDualContext.Universidades'  is null.");
            }
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad != null)
            {
                _context.Universidades.Remove(universidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadExists(string id)
        {
          return _context.Universidades.Any(e => e.UniversidadID == id);
        }
    }
}
