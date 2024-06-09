using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ParteAdmin.Models;

namespace ProyectoFinal_ParteAdmin.Controllers
{
    public class ClientesController : Controller
    {
        private readonly adminDbContext _context;

        public ClientesController(adminDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes
                                         .Include(c => c.Usuario)
                                         .ToListAsync();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                                        .Include(c => c.Usuario)
                                        .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var model = new CreateClienteViewModel();
            return View(model);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClienteViewModel model)
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

                var cliente = new Clientes
                {
                    id_usuario = usuario.id_usuario
                };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                                        .Include(c => c.Usuario)
                                        .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var model = new CreateClienteViewModel
            {
                IdUsuario = cliente.id_usuario,
                IdCliente = cliente.id_cliente,
                Nombre = cliente.Usuario.nombre,
                Correo = cliente.Usuario.correo,
                Password = cliente.Usuario.password,
                Numero = cliente.Usuario.numero
            };

            return View(model);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateClienteViewModel model)
        {
            if (id != model.IdCliente)
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

                    var cliente = await _context.Clientes.FindAsync(id);
                    if (cliente != null)
                    {
                        _context.Update(cliente);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(id))
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

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                                        .Include(c => c.Usuario)
                                        .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                var usuario = await _context.Usuarios.FindAsync(cliente.id_usuario);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                }
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.id_cliente == id);
        }
    }
}
