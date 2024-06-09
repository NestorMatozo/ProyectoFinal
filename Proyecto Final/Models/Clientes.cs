using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Clientes
    {
        [Key]
        public int id_cliente { get; set; }
        public int id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuarios Usuario { get; set; }
    }
}
