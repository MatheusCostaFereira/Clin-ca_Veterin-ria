using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ClinicaVeterinariaContext _context;

        public AgendaController(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index(DateTime? minDate,DateTime? maxDate)
        {
            var clinicaVeterinariaContext = from a in _context.Agenda.Include(a => a.Pet).Include(a => a.Veterinario)
                .Include(a => a.Pet.Proprietario).OrderByDescending(X => X.DataConsulta) select a;
            if (minDate.HasValue)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.DataConsulta >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.DataConsulta <= maxDate.Value);
            }
            return View(await clinicaVeterinariaContext.ToListAsync());
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.Pet)
                .Include(a => a.Veterinario)
                .Include(a => a.Pet.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome");
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,PetId,VeterinarioId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", agenda.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", agenda.VeterinarioId);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", agenda.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", agenda.VeterinarioId);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataConsulta,PetId,VeterinarioId")] Agenda agenda)
        {
            if (id != agenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.Id))
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
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", agenda.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", agenda.VeterinarioId);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.Pet)
                .Include(a => a.Veterinario)
                .Include(a => a.Pet.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.Id == id);
        }
    }
}
