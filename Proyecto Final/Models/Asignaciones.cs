using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Asignaciones
    {
        [Key]
        public int id_asignaciones { get; set; }
        public int id_ticket { get; set; }
        public int id_tecnico { get; set; }
        public DateTime fecha { get; set; }
        public string? estado { get; set; }
        public string? comentario { get; set; }

        [ForeignKey("id_tecnico")]
        public virtual Tecnicos Tecnico { get; set; }

        [ForeignKey("id_ticket")]
        public virtual Clientes Cliente { get; set; }
    }
}
