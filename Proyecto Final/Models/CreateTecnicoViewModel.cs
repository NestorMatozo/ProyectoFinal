using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class CreateTecnicoViewModel
    {
        internal readonly object?[]? IdUsuario;

        [Display(Name = "ID Técnico")]
        [Required]
        public int IdTecnico { get; set; }

        [Display(Name = "Rol")]

        public List<string> RolOptions { get; } = new List<string> { "Soporte", "Técnico" };
        public string Rol { get; set; } = "Técnico";
        [Required(ErrorMessage ="El Area de el Tecnico no es opcional")]
        [Display(Name = "Área")]
        public string? Area { get; set; }
        [Required(ErrorMessage = "El Tecnico debe tener un nombre")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo no es opcional")]

        [Display(Name = "Correo")]

        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Tecnico necesita una contraseña")]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }
    }
}
