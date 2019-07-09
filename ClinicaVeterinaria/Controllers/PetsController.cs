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
    public class PetsController : Controller
    {
        private readonly ClinicaVeterinariaContext _context;

        public PetsController(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(string nome)
        {
            var clinicaVeterinariaContext = from b in _context.Pet.Include(p => p.Proprietario) select b;
            if (!String.IsNullOrEmpty(nome))
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(s => s.Nome==nome);
            }
            return View(await clinicaVeterinariaContext.ToListAsync());
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Raca,Idade,Peso,ProprietarioId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", pet.ProprietarioId);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", pet.ProprietarioId);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Raca,Idade,Peso,ProprietarioId")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
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
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", pet.ProprietarioId);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Prontuario(int? id)
        {
            var clinicaVeterinariaContext = from a in _context.Consulta.Include(a => a.Pet).Include(a => a.Veterinario)
                .Include(a => a.Pet.Proprietario).OrderByDescending(X => X.Data_Consulta) select a;

            if (id != null)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.Pet.Id == id);
            }
            

            if (clinicaVeterinariaContext == null)
            {
                return NotFound();
            }
            
            return View(await clinicaVeterinariaContext.ToListAsync());
        }

    }
}
