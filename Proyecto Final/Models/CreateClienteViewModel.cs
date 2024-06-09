using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class CreateClienteViewModel
    {
        [Display(Name = "ID Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "ID Cliente")]
        public int IdCliente { get; set; }
       
        [Required(ErrorMessage = "El cliende debe tener un nombre ")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
      
        [Required(ErrorMessage = "El correo es necesario")]
        [Display(Name = "Correo")]
        public string? Correo { get; set; }
       
        [Required(ErrorMessage = "La contraseña no es opcional")]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }
       
        [Required(ErrorMessage = "S e necesita el numero de telefono")]
        [Display(Name = "Número")]
        public int Numero { get; set; }
    }
}
