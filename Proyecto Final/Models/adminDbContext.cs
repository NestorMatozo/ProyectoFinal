using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class adminDbContext : DbContext
    {
        public adminDbContext(DbContextOptions options) : base(options) 
        
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set;}
        public DbSet<Tikets> Tikets { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }
        public DbSet<Asignaciones_act> Asignaciones_act { get; set; }
    }
}
