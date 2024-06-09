using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ParteAdmin.Models;

namespace ProyectoFinal_ParteAdmin.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly adminDbContext _context;

        public AsignacionesController(adminDbContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var asignaciones = await _context.Asignaciones
                                             .Include(a => a.Tecnico)
                                             .ThenInclude(t => t.Usuario)
                                             .Include(a => a.Cliente)
                                             .ThenInclude(c => c.Usuario)
                                             .Select(a => new AsignacionViewModel
                                             {
                                                 id_asignaciones = a.id_asignaciones,
                                                 NombreTecnico = a.Tecnico.Usuario.nombre,
                                                 NombreCliente = a.Cliente.Usuario.nombre,
                                                 comentario = a.comentario,
                                                 id_ticket = a.id_ticket,
                                                 estado = a.estado,
                                                 fecha = a.fecha
                                             }).ToListAsync();

            return View(asignaciones);
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                                           .Include(a => a.Tecnico)
                                           .ThenInclude(t => t.Usuario)
                                           .Include(a => a.Cliente)
                                           .ThenInclude(c => c.Usuario)
                                           .FirstOrDefaultAsync(m => m.id_asignaciones == id);

            if (asignacion == null)
            {
                return NotFound();
            }

            var asignacionViewModel = new AsignacionViewModel
            {
                id_asignaciones = asignacion.id_asignaciones,
                NombreTecnico = asignacion.Tecnico.Usuario.nombre,
                NombreCliente = asignacion.Cliente.Usuario.nombre,
                comentario = asignacion.comentario,
                id_ticket = asignacion.id_ticket,
                estado = asignacion.estado,
                fecha = asignacion.fecha
            };

            return View(asignacionViewModel);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asignaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_asignaciones,id_ticket,id_tecnico,fecha,estado,comentario")] Asignaciones asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_asignaciones,id_ticket,id_tecnico,fecha,estado,comentario")] Asignaciones asignacion)
        {
            if (id != asignacion.id_asignaciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.id_asignaciones))
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
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                                           .Include(a => a.Tecnico)
                                           .ThenInclude(t => t.Usuario)
                                           .Include(a => a.Cliente)
                                           .ThenInclude(c => c.Usuario)
                                           .FirstOrDefaultAsync(m => m.id_asignaciones == id);

            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.id_asignaciones == id);
        }
    }
}
