using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ParteAdmin.Models;

namespace ProyectoFinal_ParteAdmin.Controllers
{
    public class TecnicosController : Controller
    {
        private readonly adminDbContext _context;

        public TecnicosController(adminDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var tecnicos = await _context.Tecnicos
                                         .Include(t => t.Usuario) 
                                         .ToListAsync();
            return View(tecnicos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                                         .Include(t => t.Usuario) 
                                         .FirstOrDefaultAsync(m => m.id_tecnico == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // GET: Tecnicos/Create
        public IActionResult Create()
        {
            var model = new CreateTecnicoViewModel();
            return View(model);
        }

        // POST: Tecnicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTecnicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuarios
                {
                    nombre = model.Nombre,
                    correo = model.Correo,
                    password = model.Password,
                    numero = model.Numero
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                var tecnico = new Tecnicos
                {
                    id_usuario = usuario.id_usuario,
                    rol = model.Rol,
                    area = model.Area
                };
                _context.Tecnicos.Add(tecnico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private int GenerateNextTecnicoId()
        {
            return _context.Tecnicos.Any() ? _context.Tecnicos.Max(t => t.id_tecnico) + 1 : 1;
        }

        // GET: Tecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                                         .Include(t => t.Usuario) // Incluir los detalles del usuario
                                         .FirstOrDefaultAsync(m => m.id_tecnico == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            var model = new CreateTecnicoViewModel
            {
                Rol = tecnicos.rol,
                Area = tecnicos.area,
                Nombre = tecnicos.Usuario.nombre,
                Correo = tecnicos.Usuario.correo,
                Password = tecnicos.Usuario.password,
                Numero = tecnicos.Usuario.numero
            };

            return View(model);
        }

        // POST: Tecnicos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateTecnicoViewModel model)
        {
            if (id != model.IdTecnico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = await _context.Usuarios.FindAsync(model.IdUsuario);
                    if (usuario != null)
                    {
                        usuario.nombre = model.Nombre;
                        usuario.correo = model.Correo;
                        usuario.password = model.Password;
                        usuario.numero = model.Numero;
                        _context.Update(usuario);
                    }

                    var tecnico = await _context.Tecnicos.FindAsync(id);
                    if (tecnico != null)
                    {
                        tecnico.rol = model.Rol;
                        tecnico.area = model.Area;
                        _context.Update(tecnico);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicosExists(id))
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
            return View(model);
        }

        // GET: Tecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                                         .Include(t => t.Usuario) // Incluir los detalles del usuario
                                         .FirstOrDefaultAsync(m => m.id_tecnico == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnicos = await _context.Tecnicos.FindAsync(id);
            if (tecnicos != null)
            {
                var usuario = await _context.Usuarios.FindAsync(tecnicos.id_usuario);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                }
                _context.Tecnicos.Remove(tecnicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicosExists(int id)
        {
            return _context.Tecnicos.Any(e => e.id_tecnico == id);
        }
    }
}
