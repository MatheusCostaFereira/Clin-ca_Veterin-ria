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
    public class ProprietariosController : Controller
    {
        private readonly ClinicaVeterinariaContext _context;

        public ProprietariosController(ClinicaVeterinariaContext context)
        {
            _context = context;
        }

        // GET: Proprietarios
        public async Task<IActionResult> Index(string nomeProprietario)
        {
            var clinicaVeterinariaContext = from c in _context.Proprietario select c;
            if (!String.IsNullOrEmpty(nomeProprietario))
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(s => s.Nome == nomeProprietario);
            }
            return View(await clinicaVeterinariaContext.OrderByDescending(x=> x.Nome).ToListAsync());
        }

        // GET: Proprietarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }

        // GET: Proprietarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proprietarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Rg,Telefone,Email,Endereco")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proprietario);
        }

        // GET: Proprietarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario.FindAsync(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);
        }

        // POST: Proprietarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Rg,Telefone,Email,Endereco")] Proprietario proprietario)
        {
            if (id != proprietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietarioExists(proprietario.Id))
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
            return View(proprietario);
        }

        // GET: Proprietarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }

        // POST: Proprietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proprietario = await _context.Proprietario.FindAsync(id);
            _context.Proprietario.Remove(proprietario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietarioExists(int id)
        {
            return _context.Proprietario.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Historico(int? id)
        {
            var clinicaVeterinariaContext = from a in _context.Consulta.Include(a => a.Pet).Include(a => a.Veterinario)
                .Include(a => a.Pet.Proprietario).OrderByDescending(X => X.Data_Consulta)
                                            select a;

            if (id != null)
            {
                clinicaVeterinariaContext = clinicaVeterinariaContext.Where(x => x.Pet.Proprietario.Id == id);
            }


            if (clinicaVeterinariaContext == null)
            {
                return NotFound();
            }

            return View(await clinicaVeterinariaContext.OrderByDescending(d => d.Data_Consulta).ToListAsync());
        }
    }
}
