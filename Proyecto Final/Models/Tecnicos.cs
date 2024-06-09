using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Tecnicos
    {
        [Key]
        public int id_tecnico { get; set; }
        public int id_usuario { get; set; }
        public string? rol { get; set; }
        public string? area { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuarios Usuario { get; set; }
    }
}
