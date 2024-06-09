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
    public class Asignaciones_actController : Controller
    {
        private readonly adminDbContext _context;

        public Asignaciones_actController(adminDbContext context)
        {
            _context = context;
        }

        // GET: Asignaciones_act
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asignaciones_act.ToListAsync());
        }

        // GET: Asignaciones_act/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones_act = await _context.Asignaciones_act
                .FirstOrDefaultAsync(m => m.id_asignacionesact == id);
            if (asignaciones_act == null)
            {
                return NotFound();
            }

            return View(asignaciones_act);
        }

        // GET: Asignaciones_act/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asignaciones_act/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_asignacionesact,id_asignaciones,actividad,detalle,estado")] Asignaciones_act asignaciones_act)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaciones_act);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignaciones_act);
        }

        // GET: Asignaciones_act/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones_act = await _context.Asignaciones_act.FindAsync(id);
            if (asignaciones_act == null)
            {
                return NotFound();
            }
            return View(asignaciones_act);
        }

        // POST: Asignaciones_act/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_asignacionesact,id_asignaciones,actividad,detalle,estado")] Asignaciones_act asignaciones_act)
        {
            if (id != asignaciones_act.id_asignacionesact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaciones_act);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Asignaciones_actExists(asignaciones_act.id_asignacionesact))
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
            return View(asignaciones_act);
        }

        // GET: Asignaciones_act/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones_act = await _context.Asignaciones_act
                .FirstOrDefaultAsync(m => m.id_asignacionesact == id);
            if (asignaciones_act == null)
            {
                return NotFound();
            }

            return View(asignaciones_act);
        }

        // POST: Asignaciones_act/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaciones_act = await _context.Asignaciones_act.FindAsync(id);
            if (asignaciones_act != null)
            {
                _context.Asignaciones_act.Remove(asignaciones_act);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Asignaciones_actExists(int id)
        {
            return _context.Asignaciones_act.Any(e => e.id_asignacionesact == id);
        }
    }
}
