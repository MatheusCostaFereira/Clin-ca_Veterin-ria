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
    public class ConsultasController : Controller
    {
        private readonly ClinicaVeterinariaContext _context;


        public ConsultasController(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index(DateTime? minDate, DateTime? maxDate)
        {
            var clinicaVeterinariaContext = from c in _context.Consulta.Include(c => c.Pet)
                                            .Include(c => c.Veterinario).Include(c => c.Pet.Proprietario)
                                            select c;
            if (minDate.HasValue)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.Data_Consulta >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.Data_Consulta <= maxDate.Value);
            }
            return View(await clinicaVeterinariaContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Pet)
                .Include(c => c.Veterinario)
                .Include(c => c.Pet.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome");
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data_Consulta,PetId,VeterinarioId,Receita,Motivo,Descricao,ExamesRealizados")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", consulta.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", consulta.VeterinarioId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", consulta.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", consulta.VeterinarioId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data_Consulta,PetId,VeterinarioId,Receita,Motivo,Descricao,ExamesRealizados")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Nome", consulta.PetId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinario, "Id", "Nome", consulta.VeterinarioId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Pet)
                .Include(c => c.Veterinario)
                .Include(c => c.Pet.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consulta.Any(e => e.Id == id);
        }



       
    }
}
