using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Usuarios
    {
        [Key]
        public int id_usuario { get; set; } 
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? estado { get; set; }
        public string? password { get; set; }
        public int numero { get; set; }

    }
}
