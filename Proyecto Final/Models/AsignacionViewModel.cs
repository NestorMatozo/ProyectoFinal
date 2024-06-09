using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class AsignacionViewModel
    {
        [Display(Name = "ID Asignaciones")]
        public int id_asignaciones { get; set; }
        [Display(Name = "Nombre del Tecnico")]
        public string? NombreTecnico { get; set; }
        [Display(Name = "Comentarios")]
        public string? comentario { get; set; }
        [Display(Name = "ID del Ticket")]
        public int id_ticket { get; set; }
        [Required(ErrorMessage = "Se necesita el nombre ")]
        [Display(Name = "Nombre del cliente")]

        public string? NombreCliente { get; set; }
        [Required(ErrorMessage = "La asignacion debe tener un estado")]
        [Display(Name = "Estado")]
        public string? estado { get; set; }
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; } 
    }
}
