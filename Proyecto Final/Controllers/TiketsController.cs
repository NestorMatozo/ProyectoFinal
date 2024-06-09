using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ParteAdmin.Models;

namespace ProyectoFinal_ParteAdmin.Controllers
{
    public class TiketsController : Controller
    {
        private readonly adminDbContext _context;

        public TiketsController(adminDbContext context)
        {
            _context = context;
        }

        // GET: Tikets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tikets.ToListAsync());
        }

        // GET: Tikets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikets = await _context.Tikets
                .FirstOrDefaultAsync(m => m.id_ticket == id);
            if (tikets == null)
            {
                return NotFound();
            }

            return View(tikets);
        }

        // GET: Tikets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tikets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_ticket,nombre_aplicativo,descripcion,archivos,prioridad,id_cliente,comentario")] Tikets tikets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tikets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tikets);
        }

        // GET: Tikets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikets = await _context.Tikets.FindAsync(id);
            if (tikets == null)
            {
                return NotFound();
            }
            return View(tikets);
        }

        // POST: Tikets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_ticket,nombre_aplicativo,descripcion,archivos,prioridad,id_cliente,comentario")] Tikets tikets)
        {
            if (id != tikets.id_ticket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tikets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiketsExists(tikets.id_ticket))
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
            return View(tikets);
        }

        // GET: Tikets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tikets = await _context.Tikets
                .FirstOrDefaultAsync(m => m.id_ticket == id);
            if (tikets == null)
            {
                return NotFound();
            }

            return View(tikets);
        }

        // POST: Tikets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tikets = await _context.Tikets.FindAsync(id);
            if (tikets != null)
            {
                _context.Tikets.Remove(tikets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiketsExists(int id)
        {
            return _context.Tikets.Any(e => e.id_ticket == id);
        }
    }
}
